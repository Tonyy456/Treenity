using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;

    private float time = 0f;
    public Action resetTimer;
    private bool stop = false;
    public void Awake()
    {
        GameEventManager.PlayerDied += () =>
        {
            stop = true;
        };
        resetTimer += () =>
        {
            time = 0f;
        };
    }
    public void Start()
    {
        resetTimer?.Invoke();
    }

    public void Update()
    {
        if (stop) return;
        time += Time.deltaTime;
        UpdateClock();
    }

    //https://stackoverflow.com/questions/463642/how-can-i-convert-seconds-into-hourminutessecondsmilliseconds-time
    private void UpdateClock()
    {
        float seconds = time;
        TimeSpan t = TimeSpan.FromSeconds(seconds);
        string answer = string.Format("{0:D2}:{1:D2}",
                t.Minutes,
                t.Seconds);
        text.text = answer;
    }
}
