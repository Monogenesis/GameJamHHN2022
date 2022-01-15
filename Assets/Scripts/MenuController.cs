using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UIDocument menu;
    [SerializeField] private InputActionReference playerInputRef;
    [SerializeField] private InputActionReference backToMenuInputActionReference;
    [SerializeField] private InputActionReference backToGameInputActionReference;
    private VisualElement _root;

    private bool _gameIsRunning;
    private void Start()
    {
        _root = menu.rootVisualElement;
        playerInputRef.action.actionMap.Disable();
        
        backToGameInputActionReference.action.Enable();
        backToMenuInputActionReference.action.Enable();

        backToGameInputActionReference.action.performed += ctx => BackToGame();
        backToMenuInputActionReference.action.performed += ctx => BackToMenu();

        _root.Q<Button>("startgame-button").clicked += StartGame;
        _root.Q<Button>("rules-button").clicked += ShowRules;
        _root.Q<Button>("settings-button").clicked += OpenSettings;
        _root.Q<Button>("quitgame-button").clicked += QuitApplication;
    }

    private void ShowRules()
    {
        
    }
    private void BackToMenu()
    {
        if (_gameIsRunning)
        {
            _root.style.visibility = Visibility.Visible;
            playerInputRef.action.actionMap.Disable();
            backToGameInputActionReference.action.Enable();

        }
    }
    private void BackToGame()
    {
            _root.style.visibility = Visibility.Hidden;
            playerInputRef.action.actionMap.Enable();
            
            backToGameInputActionReference.action.Disable();
            backToMenuInputActionReference.action.Enable();
    }

    public void StartGame()
    {
        _root.style.visibility = Visibility.Hidden;
        playerInputRef.action.actionMap.Enable();
        backToMenuInputActionReference.action.Enable();

        _gameIsRunning = true;
    }

    public void GameOver()
    {
        backToGameInputActionReference.action.Disable();
        backToMenuInputActionReference.action.Disable();
        

    }

    public void OpenSettings()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
