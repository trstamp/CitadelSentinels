using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class Tower : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CMDebug.TextPopupMouse("Click!");
        }
    }
}
