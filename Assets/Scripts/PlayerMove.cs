﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    [SerializeField] private float playerSpeed = 10f;
    private float moveVelocity = 0f; 

	void Update () {
        moveVelocity = Input.GetAxisRaw("Horizontal") * playerSpeed;
        animator.SetFloat("Speed", Mathf.Abs(moveVelocity));
	}

    private void FixedUpdate()
    {
        if (!animator.GetBool("Using"))
        {
            playerController.Move(moveVelocity);
        }
        else
        {
            playerController.Move(0f);
        }
    }

    //set flag finish
    public void FinishUseAbility()
    {
        animator.SetBool("Using", false);
        Debug.Log("Finish!");
    }

    //set flag start
    public void StartUseAbility()
    {
        animator.SetBool("Using", true);
        Debug.Log("Start!");
    }

    //check if go throw the door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Door")
        {
            AsynLoad.LoadSceneAsync("FirstScene");
        }
    }
}
