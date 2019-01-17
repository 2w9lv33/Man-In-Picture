using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopControl : MonoBehaviour
{
    public Animator popAnimator;
    public GameObject player;
    public GameObject playerPop;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !player.transform.GetComponent<PlayerController>().withKey)
        {
            popAnimator.SetBool("Up", true);
            popAnimator.SetBool("Thinking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player" && !player.transform.GetComponent<PlayerController>().withKey)
        {
            EndThinking();
            popAnimator.SetBool("Thinking", false);
            popAnimator.SetBool("Up", false);
            HideSomthing();
        }
    }

    public void ShowSomthing()
    {
        if(popAnimator.transform.GetChild(0).name == "Help")
        {
            transform.Find("Help").gameObject.SetActive(true);
        }
        if(popAnimator.transform.GetChild(0).name == "Key")
        {
            playerPop.transform.Find("Key").gameObject.SetActive(true);
        }
    }

    public void HideSomthing()
    {
        if (popAnimator.transform.GetChild(0).name == "Help")
        {
            transform.Find("Help").gameObject.SetActive(false);
        }
        if (popAnimator.transform.GetChild(0).name == "Key")
        {
            playerPop.transform.Find("Key").gameObject.SetActive(false);
        }
    }

    public void EndUp()
    {
        popAnimator.SetBool("Up", false);
    }

    public void EndThinking()
    {
        popAnimator.SetBool("Thinking", false);
    }
}
