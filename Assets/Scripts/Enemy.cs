using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    //public Animator animator;
    private bool enemy_FacingRight = false;
    private Rigidbody2D enemy_Rigidbody2D;
    private Vector3 enemy_Velocity = Vector3.zero;
    private float movementSmooth = 0.1f;
    [SerializeField] private Vector3 checkPoint = Vector3.zero;
    [SerializeField] private float Speed = 3f;

    private int toPlayer = 0;
    private bool needCheck = true;

    private void Awake()
    {
        enemy_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        if (needCheck)
        {
            CheckRoom(checkPoint);
        }
    }

    //walk
    public void Move(float move)
    {
        if (move > 0 && !enemy_FacingRight)
        {
            Flip();
        }
        else if (move < 0 && enemy_FacingRight)
        {
            Flip();
        }
        Vector3 targetVelocity = new Vector2(move, enemy_Rigidbody2D.velocity.y);
        enemy_Rigidbody2D.velocity = Vector3.SmoothDamp(enemy_Rigidbody2D.velocity, targetVelocity, ref enemy_Velocity, movementSmooth);
    }

    //flip player
    private void Flip()
    {
        enemy_FacingRight = !enemy_FacingRight;
        Vector3 enemyScale = this.transform.localScale;
        enemyScale.x *= -1;
        this.transform.localScale = enemyScale;
    }

    private void FindPlayer()
    {
        if(player.transform.position.x > transform.position.x)
        {
            if (player.GetComponent<PlayerController>().canBeSeen)
            {
                toPlayer = -1;
                needCheck = false;
            }
            else { needCheck = true; }
        }
        else
        {
            if (player.GetComponent<PlayerController>().canBeSeen)
            {
                toPlayer = 1;
                needCheck = false;
            }
            else { needCheck = true; }
        }
    }

    public void CheckRoom(Vector3 Position)
    {
        if (transform.position.x - Position.x > 0.2f)
        {
            Debug.Log("NeedCheck");
            Move(Speed * -1);
        }
        if(transform.position.x - Position.x < 0.2f)
        {
            Move(Speed * 1);
        }
    }

    public void Leave()
    {

    }
}
