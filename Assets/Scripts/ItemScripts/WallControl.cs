using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    public Animator animator;
    
    void Update()
    {
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
}
