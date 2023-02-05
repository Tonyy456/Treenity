using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAI : MonoBehaviour
{
    [SerializeField] private float timeAlive = 3f;
    [SerializeField] private float attackDelay = 0.5f;

    private bool damagable = false;
    private void Start()
    {
        damagable = false;
        StartCoroutine(SpawnIn());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damagable)
        {
        }
        else
        {
        }
    }

    private IEnumerator SpawnIn()
    {
        yield return new WaitForSeconds(attackDelay);
        damagable = true;
        yield return new WaitForSeconds(timeAlive - attackDelay);
        Destroy(this.gameObject);
        yield return null;
    }
}
