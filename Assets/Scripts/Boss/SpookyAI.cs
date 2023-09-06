using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpookyAI : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float spawnInTime;
    [SerializeField] private float timeAlive;
    [SerializeField] private float spawnOutTime;
    [SerializeField] private float randomScale;
    [SerializeField] private List<Sprite> directionalWalk;

    private bool damagable = false;
    private SpriteRenderer sprite;
    private float t = 0f;
    public void Start()
    {
        damagable = false;
        StartCoroutine(SpawnIn());
        sprite = GetComponent<SpriteRenderer>();
    }
    public void OnDisable()
    {
    }
    public void Init(Transform player)
    {
        playerPosition = player;
    }
    public void Update()
    {
        if (!damagable) return;
        t += Time.deltaTime;
        Vector3 direction = playerPosition.position - this.transform.position;
        Vector3 delta = new Vector3(
            direction.x + Mathf.Cos(t) * randomScale,
            direction.y + Mathf.Sin(t) * randomScale,
            0
            );
        delta.Normalize();
        delta *= walkingSpeed * Time.deltaTime;
        this.transform.position += delta;
        UpdateDirectionalWalk(delta);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (damagable && collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name);
            var comp = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log(comp);
            if (comp != null)
            {
                
                comp.Damage();
            }
        }
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

    private void UpdateDirectionalWalk(Vector2 direction)
    {
        if (direction.x == 0 && direction.y < 0)
        {
            sprite.sprite = directionalWalk[0];
        }
        else if (direction.x < 0 && direction.y < 0)
        {
            sprite.sprite = directionalWalk[1];
        }
        else if (direction.x < 0 && direction.y == 0)
        {
            sprite.sprite = directionalWalk[2];
        }
        else if (direction.x < 0 && direction.y > 0)
        {
            sprite.sprite = directionalWalk[3];
        }
        else if (direction.x == 0 && direction.y > 0)
        {
            sprite.sprite = directionalWalk[4];
        }
        else if (direction.x > 0 && direction.y > 0)
        {
            sprite.sprite = directionalWalk[5];
        }
        else if (direction.x > 0 && direction.y == 0)
        {
            sprite.sprite = directionalWalk[6];
        }
        else if (direction.x > 0 && direction.y < 0)
        {
            sprite.sprite = directionalWalk[7];
        }
    }
}
