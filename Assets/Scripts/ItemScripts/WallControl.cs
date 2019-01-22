using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    public Game.Color[] pictures;
    public Animator animator;
    public Canvas Canvas;
    public ColorSystem ColorSystem;
    
    void Update()
    {
        CheckColor();
        animator.SetBool("Open", false);
        if (flag)
        {
            ColorSystem.IsUILayer = false;
            animator.SetBool("Open", true);
            Canvas.transform.Find("BOOK").gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
        }
    }

    public void Change()
    {
        transform.parent.Find("Wall_After").gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    public void CheckColor()
    {
        if (pictures[0].same && pictures[1].same && pictures[2].same && pictures[3].same)
        {
            flag = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Canvas.gameObject.SetActive(false);
        }
    }
}
