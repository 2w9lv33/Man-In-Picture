using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject player;
    public Animator door;
    [SerializeField] private bool doorIsTriggered;

    void Update()
    {
        if (doorIsTriggered)
        {
            if (transform.name == "Door_m" && player.transform.GetComponent<PlayerController>().withKey)
            {
                player.SetActive(false);
                door.SetBool("Open", true);
            }
            if(transform.name == "Door")
            {
                player.SetActive(false);
                door.SetBool("Open", true);
            }
        }
        if (transform.name == "Door_E" && player.transform.GetComponent<PlayerController>().awakeEnemy)
        {
            door.SetBool("Open", true);
            player.transform.GetComponent<PlayerController>().awakeEnemy = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            doorIsTriggered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            doorIsTriggered = true;
        }
    }

    public void AwakeEnemy()
    {
        GameObject.FindGameObjectWithTag("Enemy").SetActive(true);
    }

    public void FinishOpen()
    {
        door.SetBool("Open", false);
    }

    public void LoadFirstScene()
    {
        AsynLoad.LoadSceneAsync("FirstScene");
    }
}
