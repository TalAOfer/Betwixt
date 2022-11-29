using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private int enemy1SpawnRate = 5;
    [SerializeField] private int enemy2SpawnRate = 3;

    private float timer;
    private float lastEnemySpawn;
    private float spawnDelay = 7;
    public List<Transform> enemyBase;
    
    private bool secondEnemy = false;
    

    void Start()
    {
        timer = 0;
        SpawnEnemies(enemy1, enemy1SpawnRate * 2);
          
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > lastEnemySpawn + spawnDelay)
        {
            SpawnEnemies(enemy1, enemy1SpawnRate);
            if (secondEnemy)
            {
                SpawnEnemies(enemy2, enemy2SpawnRate);
            }
        }

        if (timer > 30) 
        {
            spawnDelay = 5;
        }

        if (timer > 45)
        {
            spawnDelay = 3;
        }

        if (timer > 60)
        {
            secondEnemy = true;
            spawnDelay = 5;
        }
    }

    private void SpawnEnemies(GameObject enemyType, int numOfSpawns)
    {
        Vector3 position = GetRandomBase();

        for (int i = 0; i < numOfSpawns; i++)
        {
            position.x += i * Random.Range(1,3);
            GameObject enemyInstance = Pooler.Spawn(enemyType, position, transform.rotation);
            enemyInstance.SetActive(true);
        }

        lastEnemySpawn = Time.time;
    }

    private Vector3 GetRandomBase()
    {
        return enemyBase[Random.Range(0, enemyBase.Count)].position;
    }
}
