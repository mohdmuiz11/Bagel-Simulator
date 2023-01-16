using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    private GameManager gameManager;
    public bool isforward;
    [SerializeField] private float speed;

    private LevelDifficulty levelDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        levelDifficulty = GameObject.Find("LevelManager").GetComponent<LevelDifficulty>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isforward)
            transform.Translate(Vector3.back * gameManager.backSpeed * Time.deltaTime * speed * (levelDifficulty.level / 2));
        else
            transform.Translate(Vector3.forward * gameManager.backSpeed * Time.deltaTime * speed * (levelDifficulty.level / 2));
    }
}
