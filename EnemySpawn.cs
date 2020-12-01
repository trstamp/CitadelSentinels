using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemySpawn : MonoBehaviour
{
    private Grid grid;

    private void Awake()
    {
        grid = new Grid(20, 20, 1.5f, new Vector3(-12.8f, -6f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {

        }
    }

    private void SpawnEnemyWave()
    {
        float spawnTime = 0f;
        float timePerSpawn = .8f;

        //FunctionTimer.Create(() => SpawnEnemyWave())
    }

    /*private void spawnEnemy(Enemy.EnemyType enemyType)
    {

    }*/
}
