using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Arrow : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition, Vector3 targetPosition)
    {
        Transform arrowTransform = Instantiate(GameAssets.i.pfArrow, spawnPosition, Quaternion.identity);

        Arrow arrow = arrowTransform.GetComponent<Arrow>();
        arrow.Setup(targetPosition);
    }

    private Vector3 targetPosition;

    private void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        
        float moveSpeed = 15f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float angle = UtilsClass.GetAngleFromVectorFloat(moveDir)/2;
        transform.eulerAngles = new Vector3(0, 0, angle);

        float destroySelfDistance = 0.1f;
        if(Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
        {
            Destroy(gameObject);
        }
    }
}
