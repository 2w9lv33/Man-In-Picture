using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerController playerController;
    [SerializeField] private float playerSpeed = 10f;
    private float moveVelocity = 0f; 

	// Update is called once per frame
	void Update () {
        moveVelocity = Input.GetAxisRaw("Horizontal") * playerSpeed;
	}

    private void FixedUpdate()
    {
        playerController.Move(moveVelocity);
    }
}
