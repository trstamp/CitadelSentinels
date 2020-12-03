using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemySpawn : MonoBehaviour
{
    private Grid grid;

    private void Awake()
    {
        grid = new Grid(0, 0, 1.5f, new Vector3(-12.8f, -6f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnSpikeyWave();
            grid.SetValue(Utilities.GetMouseWorldPosition(), 1);
        }
    }

    private void SpawnSpikeyWave()
    {
        float spawnTime = 0f;
        float timePerSpawn = .8f;

        SpawnEnemy(Enemy.EnemyType.spikey);
        SpawnEnemy(Enemy.EnemyType.spikey);
        SpawnEnemy(Enemy.EnemyType.spikey);
        SpawnEnemy(Enemy.EnemyType.spikey);

        FunctionTimer.Create(() => SpawnEnemy(Enemy.EnemyType.spikey), spawnTime); spawnTime += timePerSpawn;
        FunctionTimer.Create(() => SpawnEnemy(Enemy.EnemyType.spikey), spawnTime); spawnTime += timePerSpawn;
        FunctionTimer.Create(() => SpawnEnemy(Enemy.EnemyType.spikey), spawnTime); spawnTime += timePerSpawn;
        FunctionTimer.Create(() => SpawnEnemy(Enemy.EnemyType.spikey), spawnTime); spawnTime += timePerSpawn;
    }

    private void SpawnEnemy(Enemy.EnemyType enemyType)
    {
        Vector3 spawnPosition = new Vector3(-9, 7);
        Enemy.Create(spawnPosition, enemyType);
    }
}
