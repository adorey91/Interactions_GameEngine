using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Gameplay,
        Pause,
        Options,
        GameOver,
        GameWin,
        Dialogue,
    }

    public GameState gameState;
    GameState currentState;
    internal GameState stateBeforeOptions;

    [Header("Other Managers")]
    public UIManager _uiManager;
    public LevelManager _levelManager;

    public GameObject spawnPoint;
    public GameObject player;
    [SerializeField] GameObject infoUI;


    public void Start()
    {
        gameState = GameState.MainMenu;
        StateSwitch();
        infoUI.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EscapeState();

        if (gameState != currentState)
            StateSwitch();

    }

    public void StateSwitch()
    {
        switch (gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.Gameplay: GamePlay(); break;
            case GameState.Pause: Pause(); break;
            case GameState.Options: Options(); break;
            case GameState.GameWin: GameWin(); break;
            case GameState.GameOver: GameOver(); break;
            case GameState.Dialogue: Dialogue(); break;
        }
        currentState = gameState;
    }

    void EscapeState()
    {
        if (currentState == GameState.Gameplay)
            LoadState("Pause");
        else if (currentState == GameState.Pause)
            LoadState("Gameplay");
        else if (currentState == GameState.Options)
            LoadState(stateBeforeOptions.ToString());
    }

    #region LoadState/Quit
    public void LoadState(string state)
    {
        if (state == "Options")
        {
            stateBeforeOptions = currentState;
            gameState = GameState.Options;
        }
        else if (state == "MainMenu")
            gameState = GameState.MainMenu;
        else if (state == "Pause")
            gameState = GameState.Pause;
        else if (state == "Gameplay")
            gameState = GameState.Gameplay;
        else if (state == "GameOver")
            gameState = GameState.GameOver;
        else if (state == "GameWin")
            gameState = GameState.GameWin;
        else if (state == "BeforeOptions")
            gameState = stateBeforeOptions;
        else if(state == "Dialogue")
            gameState = GameState.Dialogue;
        else
            Debug.Log("State doesnt exist");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Quittin Game");
    }
    #endregion

    #region StateUI-Update
    void MainMenu()
    {
        _uiManager.UI_MainMenu();
    }

    void GamePlay()
    {
        _uiManager.UI_GamePlay();
    }

    void Pause()
    {
        _uiManager.UI_Pause();
    }

    void GameWin()
    {
        _uiManager.UI_GameWin();
    }

    void GameOver()
    {
        _uiManager.UI_GameOver();
    }

    void Options()
    {
        _uiManager.UI_Options();
    }

    void Dialogue()
    {
        _uiManager.UI_Dialogue();
    }
    #endregion


    public void ExitSign()
    {
        infoUI.SetActive(false);
        LoadState("Gameplay");
    }

    public void MovePlayerToSpawnLocation()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
    }
}