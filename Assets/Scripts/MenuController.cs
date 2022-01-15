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
    [SerializeField] private InputActionReference welcomeScreenInputActionReference;
    private VisualElement _root;
    private VisualElement _lastMenu;

    private VisualElement _mainMenuPage;
    private VisualElement _howToPlayPage;
    private VisualElement _settingsPage;
    private Button _showRulesBackButton;
    private Button _settingsBackButton;
    
    private bool _gameIsRunning;
    private void Start()
    {
        _root = menu.rootVisualElement;
        _mainMenuPage = _root.Q<VisualElement>("mainmenu-page");
        _howToPlayPage = _root.Q<VisualElement>("rules-page");
        _settingsPage = _root.Q<VisualElement>("settings-page");
        _showRulesBackButton = _root.Q<Button>("showrulesback-button");
        _settingsBackButton = _root.Q<Button>("settingsback-button");
        
        _lastMenu = _howToPlayPage;
        
        playerInputRef.action.actionMap.Disable();
        
        backToGameInputActionReference.action.Enable();
        backToMenuInputActionReference.action.Enable();

        backToGameInputActionReference.action.performed += ctx => BackToGame();
        backToMenuInputActionReference.action.performed += ctx => BackToMenu();

        _root.Q<Button>("startgame-button").clicked += StartGame;
        _root.Q<Button>("rules-button").clicked += ShowRules;
        _root.Q<Button>("settings-button").clicked += OpenSettings;
        _root.Q<Button>("quitgame-button").clicked += QuitApplication;
        _showRulesBackButton.clicked += BackInMenu;
        _settingsBackButton.clicked += BackInMenu;

        welcomeScreenInputActionReference.action.Enable();
        welcomeScreenInputActionReference.action.performed += ctx =>
        {
            _root.Q<VisualElement>("welcome-page").style.display = DisplayStyle.None;
            ShowRules();        
            welcomeScreenInputActionReference.action.Disable();
        };
    }

    private void ShowRules()
    {
        _lastMenu.style.display = DisplayStyle.None;
        _howToPlayPage.style.display = DisplayStyle.Flex;
        _lastMenu = _howToPlayPage;
    }
    public void OpenSettings()
    {
        _lastMenu.style.display = DisplayStyle.None;
        _settingsPage.style.display = DisplayStyle.Flex;
        _lastMenu = _settingsPage;

    }

    private void BackInMenu()
    {
        _lastMenu.style.display = DisplayStyle.None;
        _mainMenuPage.style.display = DisplayStyle.Flex;
        _lastMenu = _mainMenuPage;
    }
    private void BackToMenu()
    {
        if (_gameIsRunning)
        {
            _root.style.visibility = Visibility.Visible;
            playerInputRef.action.actionMap.Disable();
            backToGameInputActionReference.action.Enable();
            GameManager.State = GameManager.GameState.Paused;
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
        GameManager.State = GameManager.GameState.Running;
    }

    public void GameOver()
    {
        backToGameInputActionReference.action.Disable();
        backToMenuInputActionReference.action.Disable();
        

    }


    public void QuitApplication()
    {
        Application.Quit();
    }
}
