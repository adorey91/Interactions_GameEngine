using UnityEngine;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager _gameManager;

    [Header("UI Objects")]
    public GameObject menuUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject optionsUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public TMP_Text returnOptions;

    [Header("Player Settings")]
    public GameObject player;
    public GameObject playerSprite;
    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    public void UI_MainMenu()
    {
        PlayerNGame(false, false, CursorLockMode.None, true, 0f);
        SetUIActive(menuUI);
    }

    public void UI_GamePlay()
    {
        PlayerNGame(true, true, CursorLockMode.Locked, false, 1f);
        SetUIActive(gameUI); 
    }

    public void UI_Pause()
    {
        PlayerNGame(false, false, CursorLockMode.None, true, 0f);
        SetUIActive(pauseUI);
    }

    public void UI_GameOver()
    {
        PlayerNGame(false, false, CursorLockMode.None, true, 0f);
        SetUIActive (gameOverUI);
    }

    public void UI_GameWin()
    {
        PlayerNGame(false, false, CursorLockMode.None, true, 0f);
        SetUIActive(gameWinUI);
    }

    public void UI_Options()
    {
        PlayerNGame(false, false, CursorLockMode.None, true, 0f);
        SetUIActive(optionsUI);
    }

    void SetUIActive(GameObject activeUI)
    {
        menuUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        activeUI.SetActive(true);
    }

    void PlayerNGame(bool art, bool controller, CursorLockMode lockMode, bool visable, float time)
    {
        playerSprite.SetActive(art);
        playerController.enabled = controller;
        Cursor.lockState = lockMode;
        Cursor.visible = visable;
        Time.timeScale = time;
    }

}