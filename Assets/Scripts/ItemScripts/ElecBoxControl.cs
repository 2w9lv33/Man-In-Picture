using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElecBoxControl : MonoBehaviour
{
    public Canvas Canvas;
    public Game.Color Color;
    public Animator Door;
    public Animator Electric;
    public GameObject room;
    public GameObject Enemy;
    public ColorSystem ColorSystem;
    public GameObject trap;

    private void Update()
    {
        if(Color.myColor == Game.Color.MyColor.BLACK)
        {
            Electric.SetBool("Play",false);
            room.transform.Find("Room_2").gameObject.SetActive(true);
            Invoke("AwakeEnemy", 3f);
            Invoke("OpenDoor", 1f);
            ColorSystem.IsUILayer = false;
            trap.SetActive(false);
            Canvas.gameObject.SetActive(false);
        }
        else
        {
            Electric.SetBool("Play", true);
        }
    }

    public void AwakeEnemy()
    { 
        Enemy.SetActive(true);
    }

    public void OpenDoor()
    {
        Door.SetBool("Open", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Canvas.transform.Find("ELECBOX").gameObject.SetActive(true);
            Canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Canvas.transform.Find("ELECBOX").gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
        }
    }
}
