using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    private List<Action> ActionSelection = new List<Action>();

    [SerializeField] private Transform player;
    [SerializeField] private float TimeBetweenDiffAttacks;

    [Header("ATTACK #1 - ROOT MOLE")]
    [SerializeField] private GameObject rootPrefab;
    [SerializeField] private float secondsBetweenRootAttacks;
    [SerializeField] private int rootCount;

    [Header("ATTACK #2 - SPOOKY PARLAE")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float secondsBetweenSpawns;
    [SerializeField] private int enemyCount;
    [SerializeField] private float DistanceVariation = 3f;

    public Action OnEnemySpawn;

    void Start()
    {
        GameEventManager.PlayerDied += () =>
        {
            this.gameObject.SetActive(false);
        };
        StartCoroutine(WaitAndAttack());

        //Add attack 1 to action selection
        
        ActionSelection.Add(() => {
            StartCoroutine(SpawnRoots());
        });
        

        //add attack 2 to action selection
        ActionSelection.Add(() => {
            StartCoroutine(SpawnEnemies());
        });
    }

    private IEnumerator WaitAndAttack()
    {
        yield return new WaitForSeconds(TimeBetweenDiffAttacks);
        if (ActionSelection.Count > 0)
        {
            Action attack = ActionSelection[UnityEngine.Random.Range(0, ActionSelection.Count)];
            attack?.Invoke();
        } else
        {
            StartCoroutine(WaitAndAttack());
        }
    }

    private IEnumerator SpawnRoots()
    {
        for(int i = 0; i < rootCount; i++)
        {
            yield return new WaitForSeconds(secondsBetweenRootAttacks);
            var go = Instantiate(rootPrefab);
            OnEnemySpawn?.Invoke();
            go.transform.position = player.transform.position;
        }
        StartCoroutine(WaitAndAttack());
        yield return null;
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);

            //spawn mf in
            var go = Instantiate(enemyPrefab);
            go.GetComponent<SpookyAI>().Init(player);
            OnEnemySpawn?.Invoke();
            float dp = DistanceVariation;
            Vector3 offset = new Vector3(
                UnityEngine.Random.Range(-dp, dp),
                UnityEngine.Random.Range(-dp, dp),
                0
                );
            go.transform.position = player.transform.position + offset;
        }
        StartCoroutine(WaitAndAttack());
        yield return null;
    }
}
