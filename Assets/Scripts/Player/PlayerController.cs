using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Treenity.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private TreenityInput input;
    // Start is called before the first frame update
    void Start()
    {
        input = new TreenityInput();
        input.Player.Move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 keyPressDir = input.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(keyPressDir.x, keyPressDir.y, 0);
        this.transform.position += moveDir * speed * Time.deltaTime;
    }
}
