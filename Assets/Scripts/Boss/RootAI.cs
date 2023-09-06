using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAI : MonoBehaviour
{
    [SerializeField] private float timeAlive = 3f;
    [SerializeField] private float attackDelay = 0.5f;

    private bool damagable = false;
    private Animator anim;
    private void Start()
    {
        damagable = false;
        anim = GetComponent<Animator>();
        StartCoroutine(SpawnIn());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (damagable && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage();
        }
    }

    private IEnumerator SpawnIn()
    {
        anim.Play("RootAttack");
        yield return new WaitForSeconds(attackDelay);
        damagable = true;
        yield return new WaitForSeconds(timeAlive - attackDelay);
        Destroy(this.gameObject);
        yield return null;
    }
}
