using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(40,20, 1.5f, new Vector3(-12.8f, -6f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Utilities.GetMouseWorldPosition(), 1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(Utilities.GetMouseWorldPosition()));
        }
    }
}
