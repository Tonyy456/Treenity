using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BossAttackManager manager;
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.PlayerDied += () =>
        {
            this.gameObject.SetActive(false);
        };
        animator.Play("TreeIdle");
        if (manager == null) return;
        if (manager.OnEnemySpawn != null)
        {
            manager.OnEnemySpawn += () =>
            {
                animator.Play("TreeShoot");
            };
        }
    }
}
