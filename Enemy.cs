using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;

public class Enemy : MonoBehaviour
{
    
    private Health enemyHealth;
    public static List<Enemy> enemyList = new List<Enemy>();

    private void Awake()
    {
        enemyList.Add(this);
        enemyHealth = new Health(300);
    }

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

    public static Enemy GetClosestEnemy(Vector3 position, float maxRange)
    {
        Enemy closest = null;
        foreach(Enemy enemy in enemyList)
        {
            if (enemy.IsDead()) continue;
            if (Vector3.Distance(position, enemy.GetPosition()) <= maxRange)
            {
                if(closest == null)
                {
                    closest = enemy;
                }
                else
                {
                    if(Vector3.Distance(position, enemy.GetPosition()) < Vector3.Distance(position, closest.GetPosition()))
                    {
                        closest = enemy;
                    }
                }
            }
        }
        return closest;
    }

    public bool IsDead()
    {
        Console.WriteLine("Enemy dead.");
        return enemyHealth.isDead();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Damage(int amount)
    {
        enemyHealth.Damage(amount);

        if (IsDead())
        {
            Destroy(gameObject);
        }
    }
}
