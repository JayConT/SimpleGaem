using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnTimer = 4f;
    private float spawnAmountTimer = 12f;
    private int spawnAmount = 1;
    public GameObject enemySpawned;
    public Transform spawnPosition;
    void Start()
    {
        SpawnEnemy(3);
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        spawnAmountTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnEnemy(spawnAmount);
            spawnTimer = 4f;
        }
        if (spawnAmountTimer <= 0)
        {
            spawnAmount++;
            spawnAmountTimer = 12f;
        }
    }

    void SpawnEnemy(int numSpawned)
    {
        for (int i = 0; i < numSpawned; i++)
        {
            MoveSpawner();
            Instantiate(enemySpawned, spawnPosition.position, Quaternion.identity);
        }
    }

    void MoveSpawner()
    {
        spawnPosition.position = new Vector2(Random.Range(-7, 8), Random.Range(1,5));
    }

    public void StopSpawning()
    {
        Destroy(gameObject);
    }
}
