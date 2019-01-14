using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    [SerializeField] private float playerSpeed = 10f;
    private float moveVelocity = 0f; 

	// Update is called once per frame
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
    }

    public void FinishUseAbility()
    {
        animator.SetBool("Using", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Door")
        {
            AsynLoad.LoadSceneAsync("FirstScene");
        }
    }
}
