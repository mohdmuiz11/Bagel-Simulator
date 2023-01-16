using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // Inspector mode
    [SerializeField] private float _backSpeed;
    [SerializeField] private EventSystem eventSystem;
    [HideInInspector] public bool isPaused;
    private MouseLook mouseLook;
    public GameObject gameOverScreen;
    public bool isOver;
    public GameObject[] powerUpPrefab;
    public PowerUpManager powerUpManager;
    public GameObject gameOverText;
    public GameObject gameEndText;
    public GameObject mainMenuButton;


    // public vars
    public float backSpeed { get { return _backSpeed; } }

    // scoring variable
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalScore;
    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        coin = 0;
        UpdateCoin(0);

    }

    public void UpdateCoin (int cointoAdd)
    {
        if (cointoAdd < 0 && powerUpManager.insuranceProtected)
            cointoAdd = 0;
        coin += cointoAdd;
        coinText.text = "Coins: " + coin;
        if (coin < 0)
               checkFail();
        
    }
    public void checkFail()
    {       
        SetEndScreen();
        gameOverText.SetActive(true);
    }

    public void gameEnd()
    {
        SetEndScreen();
        gameEndText.SetActive(true);
    }

    private void SetEndScreen()
    {
        isOver = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
        finalScore.text = "Final Coins : " + coin;
        eventSystem.SetSelectedGameObject(mainMenuButton);
    }



}
