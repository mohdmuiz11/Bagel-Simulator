using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    public void Pause()
    {
        if (!gameManager.isOver) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gameManager.isPaused = true;
            eventSystem.SetSelectedGameObject(continueButton.gameObject);
            continueButton.interactable = true;
            mainMenuButton.interactable = true;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        if (powerUpManager.isGameTimeSlowedDown)
            Time.timeScale = 0.5f;
        else
            Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.isPaused = false;
        eventSystem.SetSelectedGameObject(null);
        continueButton.interactable = false;
        mainMenuButton.interactable = false;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
