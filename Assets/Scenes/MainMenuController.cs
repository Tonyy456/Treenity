using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button btn;
    public void Start()
    {

        btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
