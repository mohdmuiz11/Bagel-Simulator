using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private GameManager gameManager;
    public int coinValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bagel"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateCoin(coinValue);
        }
        
        
    }

}
