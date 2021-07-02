using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public GameObject enemyPrefab;

    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;
    private float sideSpawnRotation = -90.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private float enemyDelay = 5.0f;
    private float enemyInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnEnemy", enemyDelay, enemyInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Spawn random animal at random position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnEnemy()
    {
        // Randomise side of screen to spawn enemy on
        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            sideSpawnX *= -1;
            sideSpawnRotation *= -1;
        }

        // Spawn enemy
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 spawnRot = new Vector3(0, sideSpawnRotation, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(spawnRot));
    }
}
