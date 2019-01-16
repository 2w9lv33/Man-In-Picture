using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            animator.SetBool("Up", true);
            animator.SetBool("Thinking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            animator.SetBool("Thinking", false);
            animator.SetBool("Up", false);
        }
    }

    public void EndUp()
    {
        animator.SetBool("Up", false);
    }

    public void EndThinking()
    {
        animator.SetBool("Thinking", false);
    }
}
