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
            EndThinking();
            animator.SetBool("Thinking", false);
            animator.SetBool("Up", false);
            if(transform.parent.name == "Cage") {
                HideHelp();
            }
            if (transform.name == "Door_m")
            {
                Debug.Log("A");
                HideKey();
            }
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

    public void ShowHelp()
    {
        transform.Find("Help").gameObject.SetActive(true);
        //transform.Find("Key").gameObject.SetActive(true);
    }
    public void HideHelp()
    {
        transform.Find("Help").gameObject.SetActive(false);
        //transform.Find("Key").gameObject.SetActive(true);
    }
    public void ShowKey()
    {
        transform.Find("Key").gameObject.SetActive(true);
    }
    public void HideKey()
    {
        transform.Find("Key").gameObject.SetActive(false);
    }
}
