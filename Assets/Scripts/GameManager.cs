using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Inspector mode
    [SerializeField] private float _backSpeed;
    [HideInInspector] public bool isPaused;
    private MouseLook mouseLook;
    public GameObject gameOverScreen;
    public bool isOver;
    public GameObject[] powerUpPrefab;

    // public vars
    public float backSpeed { get { return _backSpeed; } }
    public bool insuranceProtected = false;

    // scoring variable
    public TextMeshProUGUI coinText;
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
        if (cointoAdd < 0 && insuranceProtected)
            cointoAdd = 0;
        coin += cointoAdd;
        coinText.text = "Coins: " + coin;
        if (coin < 0)
               checkFail();
        
    }
    public void checkFail()
    {
        
        isOver = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
    }




}
