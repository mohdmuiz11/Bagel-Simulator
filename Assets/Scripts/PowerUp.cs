using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;
    private PowerUpManager powerUpManager;

    void Start()
    {
        powerUpManager = GameObject.Find("Power Up Manager").GetComponent<PowerUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bagel"))
        {
            if (powerUpType == PowerUpType.Peak_Hour_Time)
            {
                powerUpManager.powerupPeakTime();
            }
            else if (powerUpType == PowerUpType.Insurance_Protection)
            {
                powerUpManager.powerupInsurance();
            }
            else if (powerUpType == PowerUpType.Food_Magnet)
            {
                powerUpManager.powerupMagnet();
            }
           Destroy(gameObject);
           Destroy(other.gameObject);
        }
    }

   

}

public enum PowerUpType
{
    Peak_Hour_Time,
    Insurance_Protection,
    Food_Magnet
}