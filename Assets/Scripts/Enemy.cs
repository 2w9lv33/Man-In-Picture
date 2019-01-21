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

    public Transform prefab;
    public Vector3 targetVelocity = new Vector3(1, 0, 0);
    public Animator animator1, animator2;
    public GameObject door;

    private int toPlayer = 0;
    public bool needCheck = true;
    private bool needAttack = false;

    private bool hasAttacked = false;

    private IEnumerator WaitToLeave(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Leave();
    }

    private void Awake()
    {
        //enemy_Rigidbody2D = GetComponent<Rigidbody2D>();
        checkPoint = new Vector3(8, 0, 0);
    }

    private void Start()
    {
        StartCoroutine(WaitToLeave(10f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!needAttack)
        {
            FindPlayer();
        }
        if (needCheck)
        {
            GoTo(checkPoint);
        }
        if (Mathf.Abs(transform.position.x - checkPoint.x) < 0.6f)
        {
            needCheck = false;
            animator1.SetFloat("Speed", -0.5f);
            animator2.SetFloat("Speed", -0.5f);
            Move(0f);
        }
        if(transform.position.x > door.transform.position.x)
        {
            //gameObject.SetActive(false);
            door.transform.GetComponent<Animator>().SetBool("Open", false);
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
        Vector3 position = transform.position;
        position += targetVelocity * move /100;
        transform.position = position;
        //Vector3 targetVelocity = new Vector2(move, enemy_Rigidbody2D.velocity.y);
        //enemy_Rigidbody2D.velocity = Vector3.SmoothDamp(enemy_Rigidbody2D.velocity, targetVelocity, ref enemy_Velocity, movementSmooth);
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
        if (player.GetComponent<PlayerController>().canBeSeen)
        {
            needCheck = false;
            GoTo(player.transform.position);
        }
        else
        {
            Invoke("Leave", 10f);
        }
    }

    public void GoTo(Vector3 Position)
    {
        if (transform.position.x - Position.x > 0.5f)
        {
            animator1.SetFloat("Speed", 0.5f);
            animator2.SetFloat("Speed", 0.5f);
            Move(Speed * -1);
        }
        if(transform.position.x - Position.x < -0.5f)
        {
            animator1.SetFloat("Speed", 0.5f);
            animator2.SetFloat("Speed", 0.5f);
            Move(Speed * 1);
        }
    }

    public void Leave()
    {
        needCheck = true;
        targetVelocity = new Vector3(1,0,0);
        checkPoint = new Vector3(30, 5, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !hasAttacked && collision.GetComponent<PlayerController>().canBeSeen)
        {
            needCheck = false;
            needAttack = true;
            targetVelocity = Vector3.zero;
            animator1.SetBool("Attack", true);
            animator2.SetBool("Attack", true);
            animator1.SetFloat("Speed", -0.5f);
            animator2.SetFloat("Speed", -0.5f);
            hasAttacked = true;
            Invoke("Leave", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Door")
        {
            gameObject.SetActive(false);
            collision.transform.GetComponent<Animator>().SetBool("Open", false);
        }
    }

    public void SetAttackFalse()
    {
        animator1.SetBool("Attack", false);
        animator2.SetBool("Attack", false);
    }

    public void Attack()
    {
        GameObject.Instantiate(prefab, transform.Find("ammo").transform.position, transform.Find("ammo").transform.rotation);
    }
}
