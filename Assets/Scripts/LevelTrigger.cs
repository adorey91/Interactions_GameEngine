using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    public string levelName;

    private void Start()
    {
        _gameManager = ScriptableObject.FindAnyObjectByType<GameManager>();
    }

    private void Load()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(levelName);

        switch(levelName)
        {
            case "GameWin": _gameManager.gameState = GameManager.GameState.GameWin; break;
            case "GameOver": _gameManager.gameState = GameManager.GameState.GameOver; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Load();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager.MovePlayerToSpawnLocation();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
