using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameSound;
    private void Start()
    {
        State = GameState.Menu;
        gameSound.Play();
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
