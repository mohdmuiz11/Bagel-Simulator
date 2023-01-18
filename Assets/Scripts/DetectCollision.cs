using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private GameManager gameManager;
    public int coinValue;
    public float powerUpChance;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bagel"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateCoin(coinValue);

            float spawnChance = Random.value;
            
            if(spawnChance <= powerUpChance)
            {
                int i = Random.Range(0, gameManager.powerUpPrefab.Length);
                Instantiate(gameManager.powerUpPrefab[i], transform.position, gameManager.powerUpPrefab[i].transform.rotation);
            }
        }

    }

}
