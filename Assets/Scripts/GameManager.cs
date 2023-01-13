using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Inspector mode
    [SerializeField] private float _backSpeed;

    // public vars
    public float backSpeed { get { return _backSpeed; } }

    // scoring variable
    public TextMeshProUGUI coinText;
    private int coin;

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
        coin += cointoAdd;
        coinText.text = "Coins: " + coin;
    }
}
