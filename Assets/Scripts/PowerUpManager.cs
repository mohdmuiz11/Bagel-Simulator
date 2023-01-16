using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    private Coroutine slowDownCoroutine;
    private Coroutine insuranceCoroutine;
    private Coroutine foodMagnetCoroutine;

    public bool isGameTimeSlowedDown = false;
    public bool insuranceProtected = false;
    public bool foodMagnetActive = false;
    public TextMeshProUGUI powerUpText;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        
    }
    IEnumerator CoolDownTime()
    {
        Time.timeScale = 0.5f;
        powerUpText.gameObject.SetActive(true);
        powerUpText.text = "Peak Hour";
        yield return new WaitForSeconds(2.5f);
        powerUpText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isGameTimeSlowedDown = false;
    }

    IEnumerator InsuranceCoolDown()
    {
        powerUpText.gameObject.SetActive(true);
        powerUpText.text = "Insurance Protection";
        yield return new WaitForSeconds(5);
        powerUpText.gameObject.SetActive(false);
        insuranceProtected = false;
    }

    IEnumerator MagnetCoolDown()
    {
        powerUpText.gameObject.SetActive(true);
        powerUpText.text = "Food Magnet";
        yield return new WaitForSeconds(5);
        powerUpText.gameObject.SetActive(false);
        foodMagnetActive = false;
    }

    public void powerupPeakTime()
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

    public void powerupInsurance()
    {
        if (!insuranceProtected)
        {
            insuranceProtected = true;
            insuranceCoroutine = StartCoroutine(InsuranceCoolDown());
        }
        else
        {
            if (insuranceCoroutine != null)
                StopCoroutine(insuranceCoroutine);
            insuranceCoroutine = StartCoroutine(InsuranceCoolDown());
        }
    }

    public void powerupMagnet()
    {
        if (!foodMagnetActive)
        {
            foodMagnetActive = true;
            foodMagnetCoroutine = StartCoroutine(MagnetCoolDown());
        }
        else
        {
            if (foodMagnetCoroutine != null)
                StopCoroutine(foodMagnetCoroutine);
            foodMagnetCoroutine = StartCoroutine(MagnetCoolDown());
        }
    }
}



