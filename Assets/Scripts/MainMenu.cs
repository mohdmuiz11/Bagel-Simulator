using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
[SerializeField] GameObject howToMenu;


    public void PlayButton()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void HowToButton()
    {
        howToMenu.SetActive(true);
    }

    public void HowToBack()
    {
        howToMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitted Game");
    }
}
