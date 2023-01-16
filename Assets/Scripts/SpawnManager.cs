using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("NPC Prefabs")]
    public GameObject[] npcSPrefab;
    public float goodSpawnRate = 0.5f;
    public float richSpawnRate = 0.05f;
    public float badSpawnRate = 0.45f;

    [Header("Spawn settings")]
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    [SerializeField] private float xMidRange;

    [SerializeField] private float startDelay = 1.0f;
    [SerializeField] private float spawnInterval= 2.0f;

    private float spawnTimer = 0.0f;
    private LevelDifficulty levelDifficulty;

    private void Start()
    {
        levelDifficulty = GameObject.Find("LevelManager").GetComponent<LevelDifficulty>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval / levelDifficulty.level)
        {
            spawnTimer = 0;

            float spawnChance = Random.value;

            if (spawnChance <= goodSpawnRate)
                SpawnRandomNPC(Random.Range(1, 2));
            else if (spawnChance <= goodSpawnRate + badSpawnRate)
                SpawnRandomNPC(Random.Range(2, 6));
            else
                SpawnRandomNPC(0);
        }

    }

    private void SpawnRandomNPC(int index)
    {
        float xPos;

        // avoid spawn in the middle
        do
        {
            xPos = Random.Range(xRange, -xRange);
        } while (xPos > -xMidRange && xPos < xMidRange);

        Vector3 spawnPos = new Vector3(xPos, 0, zRange);
        Instantiate(npcSPrefab[index], spawnPos, npcSPrefab[index].transform.rotation);
    }
}
