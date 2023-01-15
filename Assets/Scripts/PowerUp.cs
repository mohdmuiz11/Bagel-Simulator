using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;
    private static bool isGameTimeSlowedDown = false;
    private static Coroutine slowDownCoroutine;
    private static Coroutine insuranceCoroutine;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bagel"))
        {
            if (powerUpType == PowerUpType.Peak_Hour_Time)
            {
                if (!isGameTimeSlowedDown)
                {
                    isGameTimeSlowedDown = true;
                    slowDownCoroutine = StartCoroutine(CoolDownTime());
                }
                else
                {
                    if (slowDownCoroutine != null)
                        StopCoroutine(slowDownCoroutine);
                    slowDownCoroutine = StartCoroutine(CoolDownTime());
                }
            }
            else if (powerUpType == PowerUpType.Insurance_Protection)
            {
                if (!gameManager.insuranceProtected)
                {
                    gameManager.insuranceProtected = true;
                    insuranceCoroutine = StartCoroutine(InsuranceCoolDown());
                }
                else
                {
                    if (insuranceCoroutine != null)
                        StopCoroutine(insuranceCoroutine);
                    insuranceCoroutine = StartCoroutine(InsuranceCoolDown());
                }
            }
        }
    }

    // Peak hour i guess
    IEnumerator CoolDownTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        isGameTimeSlowedDown = false;
    }

    IEnumerator InsuranceCoolDown()
    {
        yield return new WaitForSecondsRealtime(5);
        gameManager.insuranceProtected = false;
    }
}

public enum PowerUpType
{
    Peak_Hour_Time,
    Insurance_Protection,
    Food_Magnet
}