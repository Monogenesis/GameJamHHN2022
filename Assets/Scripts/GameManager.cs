using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        State = GameState.Menu;
    }

    public static GameState State { get;  set; }
    public enum GameState
    {
        Menu,
        Running,
        RunningPaused,
        GameOver
    }
}
