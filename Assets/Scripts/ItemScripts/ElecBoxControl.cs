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
    public Collider2D collider;

    private void Update()
    {
        if(Color.myColor == Game.Color.MyColor.BLACK)
        {
            Electric.SetBool("Play",false);
            room.transform.Find("Room_2").gameObject.SetActive(true);
            Door.SetBool("Open", true);
            Enemy.SetActive(true);
            collider.enabled = false;
    //Canvas.gameObject.SetActive(false);
}
        else
        {
            Electric.SetBool("Play", true);
        }
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
