using System.Collections;
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
        if (!animator.GetBool("Using") && !animator.GetBool("Get"))
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
