using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition, EnemyType enemyType)
    {
        Enemy enemy;

        if (enemyType == EnemyType.spikey)
        {
            enemy = Instantiate(GameAssets.i.spikey, spawnPosition, Quaternion.identity);
        }
        
    }

    public enum EnemyType
    {
        spikey,
        soldier,
        idk
    }
}
