using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float lastEnemySpawn;
    private float spawnDelay = 7;

    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastEnemySpawn + spawnDelay)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = transform.position;
            position.x += i * 2;
            GameObject enemyInstance = Pooler.Spawn(enemy, position, transform.rotation);
            enemyInstance.SetActive(true);
        }

        lastEnemySpawn = Time.time;
    }
}
