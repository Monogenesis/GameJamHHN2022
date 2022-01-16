using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UIDocument menu;
    [SerializeField] private InputActionReference playerInputRef;
    [SerializeField] private InputActionReference backToMenuInputActionReference;
    // [SerializeField] private InputActionReference backToGameInputActionReference;
    [SerializeField] private InputActionReference welcomeScreenInputActionReference;
    private VisualElement _root;
    private VisualElement _lastMenu;

    private VisualElement _mainMenuPage;
    private VisualElement _howToPlayPage;
    private VisualElement _settingsPage;
    private VisualElement _gameOverPage;
    private Button _showRulesBackButton;
    private Button _settingsBackButton;
    
    private void Start()
    {
        _root = menu.rootVisualElement;
        _mainMenuPage = _root.Q<VisualElement>("mainmenu-page");
        _howToPlayPage = _root.Q<VisualElement>("rules-page");
        _settingsPage = _root.Q<VisualElement>("settings-page");
        _gameOverPage = _root.Q<VisualElement>("gameover-page");
        _showRulesBackButton = _root.Q<Button>("showrulesback-button");
        _settingsBackButton = _root.Q<Button>("settingsback-button");
        
        _lastMenu = _howToPlayPage;
        
        playerInputRef.action.actionMap.Disable();
        
        // backToGameInputActionReference.action.Disable();
        backToMenuInputActionReference.action.Disable();

        // backToGameInputActionReference.action.performed += ctx => BackToGame();
        backToMenuInputActionReference.action.performed += ctx => ToggleMenu();

        _root.Q<Button>("startgame-button").clicked += StartGame;
        _root.Q<Button>("rules-button").clicked += ShowRules;
        _root.Q<Button>("settings-button").clicked += OpenSettings;
        _root.Q<Button>("quitgame-button").clicked += QuitApplication;
        _root.Q<Button>("gameover-quitgame-button").clicked += QuitApplication;
        _root.schedule.Execute((() =>
        {
            _root.Q<Label>("welcomescreen-label").ToggleInClassList("welcome-spawn");
            _root.Q<Label>("welcomescreen-clickany-label").style.opacity = 1;
        })).ExecuteLater(100);
       
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

    public void ShowGameOverScreen()
    {
        _root.style.display = DisplayStyle.Flex;
        _gameOverPage.style.display = DisplayStyle.Flex;
    }
    public void ToggleMenu()
    {
        switch (GameManager.State)
        {
            case GameManager.GameState.Menu:
                break;
            case GameManager.GameState.Running:
                _root.style.display = DisplayStyle.Flex;
                playerInputRef.action.actionMap.Disable();
                GameManager.State = GameManager.GameState.RunningPaused;
                break;
            case GameManager.GameState.RunningPaused:
                _root.style.display = DisplayStyle.None;
                playerInputRef.action.actionMap.Enable();
                GameManager.State = GameManager.GameState.Running;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
       
    }
    // private void BackToMenu()
    // {
    //     if (GameManager.State == GameManager.GameState.Running)
    //     {
    //         _root.style.display = DisplayStyle.Flex;
    //         backToGameInputActionReference.action.Disable();
    //         backToMenuInputActionReference.action.Enable();
    //         playerInputRef.action.actionMap.Disable();
    //         GameManager.State = GameManager.GameState.RunningPaused;
    //     }
    // }
    // private void BackToGame()
    // {
    //     if (GameManager.State == GameManager.GameState.RunningPaused)
    //     {
    //         _root.style.display = DisplayStyle.None;
    //         playerInputRef.action.actionMap.Enable();
    //         backToGameInputActionReference.action.Disable();
    //         backToMenuInputActionReference.action.Enable();
    //         GameManager.State = GameManager.GameState.Running;
    //     }
    //      
    // }

    public void StartGame()
    {
        _root.style.display = DisplayStyle.None;
        playerInputRef.action.actionMap.Enable();
        GameManager.State = GameManager.GameState.Running;
        backToMenuInputActionReference.action.Enable();
    }

    public void GameOver()
    {


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
    public void QuitApplication()
    {
        Application.Quit();
    }
}
