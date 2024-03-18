using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    { 
        MainMenu,
        GamePlay,
        Pause,
        Options,
        GameOver,
        GameWin,
    }

    public GameState gameState;

    public UIManager _uiManager;
    public LevelManager _levelManager;
    public TMP_Text currentState; // used to show state on GUI
    public TMP_Text sceneText;
    public GameObject spawnPoint;
    public GameObject player;
    
    private Vector2 playerLastPos; // last player position? (not sure if i need this yet)
    public string beforeOptions;

    private void Start()
    {
        gameState = GameState.MainMenu;
        currentState.text = $"State: {gameState.ToString()}";
        sceneText.text = $"Scene: {SceneManager.GetActiveScene().name}";
        beforeOptions = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        sceneText.text = $"Scene: {SceneManager.GetActiveScene().name}";
        if (currentState.text != gameState.ToString())
            currentState.text = $"State: {gameState.ToString()}";
        if(SceneManager.GetActiveScene().name != "Options")
        {
            if(SceneManager.GetActiveScene().name != beforeOptions)
                beforeOptions = SceneManager.GetActiveScene().name;
        }

        switch (gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.GamePlay: GamePlay(); break;
            case GameState.Pause: Pause(); break;
            case GameState.Options: Options(); break;
            case GameState.GameWin: GameWin(); break;
            case GameState.GameOver: GameOver(); break;
        }
    }

    void MainMenu()
    {
        _uiManager.UI_MainMenu();
    }

    void GamePlay()
    {
        _uiManager.UI_GamePlay();
        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.Pause;
    }

    void Pause()
    {
        _uiManager.UI_Pause();
        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.GamePlay;
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
        if (Input.GetKeyDown(KeyCode.Escape))
            _levelManager.LoadScene(beforeOptions); // need to figure this out?\
    }

    public void MovePlayerToSpawnLocation()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
    }
}