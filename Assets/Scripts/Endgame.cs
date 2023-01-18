using UnityEngine;

public class Endgame : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GameEnd();
        }
    }
}
