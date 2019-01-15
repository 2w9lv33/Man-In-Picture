using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject follow;
    private void Update()
    {
        LookAt();
    }

    void LookAt()
    {
        float x = follow.transform.position.x;
        this.transform.position = new Vector3(x, -0.95f, -10);
    }
}
