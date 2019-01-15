using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Room")
        {
            animator.SetBool("Broken", true);
        }
    }
}
