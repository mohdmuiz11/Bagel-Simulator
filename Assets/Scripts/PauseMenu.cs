using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
