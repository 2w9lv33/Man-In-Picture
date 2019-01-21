using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 0.5f)] [SerializeField] private float movementSmooth = 0.1f;
    [SerializeField] private Transform interactivePoint;
    [SerializeField] private Texture2D mouseCursor;
    [SerializeField] public bool canBeSeen = true;
    [SerializeField] public bool canMove = true;
    [SerializeField] public bool withKey = false;
    [SerializeField] public bool awakeEnemy = false;

    private Rigidbody2D player_Rigidbody2D;
    private bool player_FacingRight = true;
    private Vector3 player_Velocity = Vector3.zero;

    private void Awake()
    {
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    //walk
    public void Move(float move)
    {
        if (canMove)
        {
            if (move > 0 && !player_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && player_FacingRight)
            {
                Flip();
            }
            Vector3 targetVelocity = new Vector2(move, player_Rigidbody2D.velocity.y);
            player_Rigidbody2D.velocity = Vector3.SmoothDamp(player_Rigidbody2D.velocity, targetVelocity, ref player_Velocity, movementSmooth);
        }
    }

    //flip player
    private void Flip()
    {
        player_FacingRight = !player_FacingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }

    public  void ChangePlayer(int type)
    {
        switch (type)
        {
            case 1:
                transform.GetComponent<Animator>().SetLayerWeight(0, 0f);
                transform.GetComponent<Animator>().SetLayerWeight(1, 1f);
                withKey = true;
                break;
            case 2:
                transform.GetComponent<Animator>().SetLayerWeight(0, 1f);
                transform.GetComponent<Animator>().SetLayerWeight(1, 0f);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Enemy_1")
        {
            transform.GetComponent<Animator>().SetBool("Die", true);
        }
    }

    public void SetMoveTrue()
    {
        canMove = true;
    }
}
