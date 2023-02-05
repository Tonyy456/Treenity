using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpookyAI : MonoBehaviour
{
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float spawnInTime;
    [SerializeField] private float timeAlive;
    [SerializeField] private float spawnOutTime;

    private bool damagable = false;

    public void Start()
    {
        damagable = false;
        StartCoroutine(SpawnIn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damagable) Debug.Log("L");
    }

    public IEnumerator SpawnIn()
    {
        yield return new WaitForSeconds(spawnInTime);
        damagable = true;
        yield return new WaitForSeconds(timeAlive - spawnInTime - spawnOutTime);
        yield return new WaitForSeconds(spawnOutTime);
        Destroy(this.gameObject);
        yield return null;
    }
}
