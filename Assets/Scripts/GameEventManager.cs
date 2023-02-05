using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public Action OnLoad;
    public Action OnPrompt;
    public Action OnSurvive;
    public Action OnDeath;
    public Action OnEnd;
    public Action OnWin;

    public Action EndLoadEvent;
    public Action EndPromptEvent;
    public Action EndSurviveEvent;
    public Action EndDeathEvent;
    public Action EndEndEvent;
    public Action EndWinEvent;

    void Awake()
    {
        OnLoad = new Action(() =>
        {
            //turn menus on and initialize input
        });
        OnPrompt = new Action(() =>
        {
            //turn a canvas element on and wait for it to be closed
        });
        OnSurvive = new Action(() =>
        {
            //begin survival elements
        });
        OnDeath = new Action(() =>
        {

        });
        OnEnd = new Action(() =>
        {

        });
        OnWin = new Action(() =>
        {

        });

        EndLoadEvent = new Action(() => { OnPrompt?.Invoke(); });
        EndPromptEvent = new Action(() => { OnSurvive?.Invoke(); });
        EndSurviveEvent = new Action(() => { OnDeath?.Invoke(); });
        EndDeathEvent = new Action(() => { OnEnd?.Invoke(); });
        EndEndEvent = new Action(() => { OnWin?.Invoke(); });
        EndWinEvent = new Action(() => { });
    }
}
