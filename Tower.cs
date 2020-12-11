using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class Tower : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;
    private float range;
    private int attack;
    private float dexterityMax;
    private float dexterity;

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
        range = 10f;
        attack = 200;
        dexterityMax = 0.25f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CMDebug.TextPopupMouse("Click!");
            //Arrow.Create(projectileShootFromPosition,UtilsClass.GetMouseWorldPosition());
        }

        dexterity -= Time.deltaTime;

        if(dexterity <= 0f)
        {
            dexterity = dexterityMax;

            Enemy enemy = GetClosestEnemy();
            if (enemy != null)
            {
                // Enemy in range
                Arrow.Create(projectileShootFromPosition, enemy, attack);
            }

        }

        
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosestEnemy(transform.position, range);
    }
}
