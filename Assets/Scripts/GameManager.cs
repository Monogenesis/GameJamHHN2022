using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        State = GameState.Paused;
    }

    public static GameState State { get;  set; }
    public enum GameState
    {
        Paused,
        Running
    }
}
