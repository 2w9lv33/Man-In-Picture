using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSystem : MonoBehaviour
{
    public GameObject Player;
    public Text text;
    private Vector3 mousePosition;
    [SerializeField] private Game.Color.MyColor palette;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetColor(mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetColor(mousePosition);
        }
        //Player.GetComponent<Game.Color>().myColor == Game.Color.MyColor.WALL
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Hide();
        }
    }

    private void SetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        Debug.Log("hit");
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            hit.transform.GetComponent<Game.Color>().myColor = palette;
            //text.text = palette.ToString();
        }
    }

    private void GetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if(hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            palette = hit.transform.GetComponent<Game.Color>().myColor;
            text.text = palette.ToString();
        }
    }

    private void Hide()
    {
        Color color = Player.GetComponent<SpriteRenderer>().color;
        color.a = 0.1f;
        Player.GetComponent<SpriteRenderer>().color = color;
    }
}
