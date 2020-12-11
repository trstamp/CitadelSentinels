using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Arrow : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition, Enemy enemy, int damage)
    {
        Transform arrowTransform = Instantiate(GameAssets.i.pfArrow, spawnPosition, Quaternion.identity);

        Arrow arrow = arrowTransform.GetComponent<Arrow>();
        arrow.Setup(enemy, damage);
    }

    private Enemy enemy;
    private int damage;

    private void Setup(Enemy enemy, int damage)
    {
        this.enemy = enemy;
        this.damage = damage;
    }

    private void Update()
    {
        Vector3 targetPosition = enemy.GetPosition();
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        
        float moveSpeed = 15f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float angle = UtilsClass.GetAngleFromVectorFloat(moveDir)/2;
        transform.eulerAngles = new Vector3(0, 0, angle);

        float destroySelfDistance = 0.1f;
        if(Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
            Enemy.enemyList.Remove(enemy);
        }
    }
}
