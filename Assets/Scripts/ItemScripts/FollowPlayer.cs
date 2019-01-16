using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 position;
    private void Update()
    {
        position = player.transform.position;
        position.x += 0.65f;
        position.y += 2.46f;
        transform.position = position;
    }
}
