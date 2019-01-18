using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 position;
    private void Start()
    {
        //UnityEngine.Cursor.visible = false;
    }
    void Update()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = -5f;
        transform.position = position;
    }
}
