using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameManager _gameManager;
    public string beforeOptions;
    
    public void LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);

        switch(sceneName)
        {
            case "MainMenu": _gameManager.gameState = GameManager.GameState.MainMenu; break;
            case "Gameplay_field": _gameManager.gameState = GameManager.GameState.GamePlay; break;
            case "Gameplay_Scene2": _gameManager.gameState = GameManager.GameState.GamePlay; break;
            case "GameWin": _gameManager.gameState = GameManager.GameState.GameWin; break;
            case "GameOver": _gameManager.gameState = GameManager.GameState.GameOver; break;
            case "Options": 
                _gameManager.gameState = GameManager.GameState.Options; break;
        }
    }

    public void ExitOptions()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(_gameManager.beforeOptions.ToString());
        if (_gameManager.beforeOptions == "MainMenu")
            _gameManager.gameState = GameManager.GameState.MainMenu;
        else
            _gameManager.gameState = GameManager.GameState.Pause;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}