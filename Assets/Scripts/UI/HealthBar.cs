using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Scrollbar bar;
    [SerializeField] private GameObject toScale;


    private Vector3 currentScale;
    public void Start()
    {
        GameEventManager.PlayerDied += () =>
        {
            this.gameObject.SetActive(false);
        };
        currentScale = toScale.transform.localScale;
    }

    public void Update()
    {
        var value = (PlayerController.health) / 10f;
        toScale.transform.localScale = new Vector3(currentScale.x * value, currentScale.y, currentScale.z);
    }
}
