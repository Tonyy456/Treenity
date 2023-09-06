using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Treenity.Input;

public class PlayerController : MonoBehaviour
{
    public static int health = 10;
    [SerializeField] private float speed = 5f;
    [Header("Start with south and go clock wise")]
    [SerializeField] private List<Sprite> directionalWalk;
    [SerializeField] private Color hurtColor;

    private TreenityInput input;
    private SpriteRenderer sprite;
    private bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.PlayerDied += () =>
        {
            this.gameObject.SetActive(false);
        };
        input = new TreenityInput();
        input.Player.Move.Enable();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Damage()
    {
        if (damaged) return;
        damaged = true;
        if (!GameEventManager.gameRunning) return;
        StartCoroutine(DamageSelf());
    }

    private IEnumerator DamageSelf()
    {
        health -= 1;
        if (health <= 0) GameEventManager.PlayerDied?.Invoke();
        sprite.color = hurtColor;
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1, 1);
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 keyPressDir = input.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(keyPressDir.x, keyPressDir.y, 0);
        UpdateDirectionalWalk(moveDir);
        this.transform.position += moveDir * speed * Time.deltaTime;
    }

    private void UpdateDirectionalWalk(Vector2 direction)
    {
        if(direction.x == 0 && direction.y < 0)
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
