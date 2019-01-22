using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerController playerController;
    public ColorSystem ColorSystem;
    public Animator animator;
    [SerializeField] private float playerSpeed = 10f;
    public float moveVelocity = 0f;
    public Vector3 mousePosition = Vector3.zero;

    void Update () {
        if (Input.GetMouseButtonDown(0) && !ColorSystem.IsUILayer)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveVelocity = (mousePosition.x > transform.position.x ? 1 : -1) * playerSpeed;
            animator.SetFloat("Speed", Mathf.Abs(moveVelocity));
        }
        if (Mathf.Abs(mousePosition.x - transform.position.x) < 0.1f && playerController.canMove)
        {
            animator.SetFloat("Speed", -5f);
            moveVelocity = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (!animator.GetBool("Using") && !animator.GetBool("Get"))
        {
            playerController.Move(moveVelocity);
        }
        else
        {
            playerController.Move(0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mousePosition = transform.position;
        animator.SetFloat("Speed", -5f);
        moveVelocity = 0f;
    }

    //set flag finish
    public void SetUseFalse()
    {
        animator.SetBool("Use", false);
        animator.SetFloat("Speed", -5f);
        moveVelocity = 0f;
        //Debug.Log("Finish!");
    }

    //set flag start
    public void SetUseTrue()
    {
        animator.SetBool("Use", true);
        //Debug.Log("Start!");
    }

    public void SetUsingFalse()
    {
        animator.SetBool("Using", false);
        animator.SetFloat("Speed", -5f);
        moveVelocity = 0f;
        Debug.Log("Finish!");
    }

    //set flag start
    public void SetUsingTrue()
    {
        animator.SetBool("Using", true);
        //Debug.Log("Start!");
    }

    public void SetDieFalse()
    {
        animator.SetBool("Die", false);
        playerController.canMove = false;
    }

    public void SetGetFalse()
    {
        animator.SetBool("Get", false);
        animator.SetBool("Using", true);
    }

    public void LoadFirstScene()
    {
        AsynLoad.LoadSceneAsync("FirstScene");
    }

    public void LoadSecondScene()
    {
        AsynLoad.LoadSceneAsync("SecondScene");
    }
}
