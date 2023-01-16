using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource audioSource;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.isOver)
        {
            audioSource.pitch = 0.1f;
        }
        else
        {
            audioSource.pitch = 0.5f;
        }
    }
}
