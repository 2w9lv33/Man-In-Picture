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
        float y = follow.transform.position.y + 1.35f;
        this.transform.position = new Vector3(x, y, -10);
    }
}
