using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    public Game.Color[] pictures;
    public Animator animator;
    
    void Update()
    {
        CheckColor();
        animator.SetBool("Open", false);
        if (flag)
        {
            animator.SetBool("Open", true);
        }
    }

    public void Change()
    {
        transform.parent.Find("Wall_After").gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    public void CheckColor()
    {
        if (pictures[0].same && pictures[1].same && pictures[2].same)
        {
            flag = true;
        }
    }
}
