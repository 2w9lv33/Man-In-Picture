using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElecBoxControl : MonoBehaviour
{
    public Canvas Canvas;
    public Game.Color Color;
    public Animation Animation;

    private void Update()
    {
        if(Color.myColor == Game.Color.MyColor.BLACK)
        {
            Animation.Stop();
        }
        else
        {
            Animation.Play();
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
