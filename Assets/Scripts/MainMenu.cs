using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
[SerializeField] GameObject howToMenu;
[SerializeField] private EventSystem eventSystem;
[SerializeField] private Button howToButtonButton;
[SerializeField] private Button playButton;
[SerializeField] private Button exitButton;
[SerializeField] private Button howToBackButton;


    public void PlayButton()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void HowToButton()
    {
        howToMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(howToBackButton.gameObject);

        // Button management
        howToBackButton.interactable = true;
        howToButtonButton.interactable = false;
        playButton.interactable = false;
        exitButton.interactable = false;
    }

    public void HowToBack()
    {
        howToMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(howToButtonButton.gameObject);

        // Button management
        howToBackButton.interactable = false;
        howToButtonButton.interactable = true;
        playButton.interactable = true;
        exitButton.interactable = true;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitted Game");
    }
}
