using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Manager")]
    public GameManager _gameManager;

    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (sceneName.StartsWith("MainMenu"))
            _gameManager.LoadState(sceneName);
        else if (sceneName.StartsWith("Gameplay"))
            _gameManager.LoadState("Gameplay");

        // Can load one of two panels with the game end scene.
        else if (sceneName.StartsWith("GameEnd"))
        {
            if (sceneName.EndsWith("GameOver"))
                _gameManager.LoadState("GameOver");
            else if (sceneName.EndsWith("GameWin"))
                _gameManager.LoadState("GameWin");

            sceneName = "GameEnd";
        }
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager.MovePlayerToSpawnLocation();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}