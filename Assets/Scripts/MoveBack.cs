using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    private GameManager gameManager;
    public bool isforward;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isforward)
            transform.Translate(Vector3.back * gameManager.backSpeed * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.forward * gameManager.backSpeed * Time.deltaTime * speed);
    }
}
