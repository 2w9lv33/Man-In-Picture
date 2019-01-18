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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePlayer(1);
        }
    }

    //walk
    public void Move(float move)
    {
        if(move > 0 && !player_FacingRight)
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

    //flip player
    private void Flip()
    {
        player_FacingRight = !player_FacingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }

    private void ChangePlayer(int type)
    {
        switch (type)
        {
            case 1:
                transform.GetComponent<Animator>().SetLayerWeight(0, 0f);
                transform.GetComponent<Animator>().SetLayerWeight(1, 1f);
                break;
            case 2:
                transform.GetComponent<Animator>().SetLayerWeight(0, 1f);
                transform.GetComponent<Animator>().SetLayerWeight(1, 0f);
                break;
        }
    }

    //show shadow
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            if (collision.gameObject.transform.position.x > this.transform.position.x)
            {
                if (player_FacingRight)
                {
                    this.transform.Find("shadeRight").gameObject.SetActive(false);
                    this.transform.Find("shadeLeft").gameObject.SetActive(true);
                }
                else
                {
                    this.transform.Find("shadeLeft").gameObject.SetActive(false);
                    this.transform.Find("shadeRight").gameObject.SetActive(true);
                }
            }
            else
            {
                if (player_FacingRight)
                {
                    this.transform.Find("shadeRight").gameObject.SetActive(true);
                    this.transform.Find("shadeLeft").gameObject.SetActive(false);
                }
                else
                {
                    this.transform.Find("shadeLeft").gameObject.SetActive(true);
                    this.transform.Find("shadeRight").gameObject.SetActive(false);
                }
            }
        }
    }

    //close shadow
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Light")
        {
            this.transform.Find("shadeRight").gameObject.SetActive(false);
            this.transform.Find("shadeLeft").gameObject.SetActive(false);
        }
    }
}
