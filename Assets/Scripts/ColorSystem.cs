using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSystem : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Text text;
    private Vector3 mousePosition;
    [SerializeField] private Game.Color.MyColor palette;

    private void Update()
    {
        animator.SetBool("Use", false);
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("Use", true);
            animator.SetBool("Using", true);
            GetColor(mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("Use", true);
            animator.SetBool("Using", true);
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
            if (hit.transform.GetComponent<Game.Color>().canBeSet && palette != Game.Color.MyColor.NOCOLOR)
            {
                hit.transform.GetComponent<Game.Color>().myColor = palette;
            }
            //text.text = palette.ToString();
        }
    }

    private void GetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if(hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Game.Color>().canBeGet)
            {
                palette = hit.transform.GetComponent<Game.Color>().myColor;
                text.text = palette.ToString();
            }
        }
    }

    private void Hide()
    {
        Color color = player.GetComponent<SpriteRenderer>().color;
        color.a = 0.1f;
        player.GetComponent<SpriteRenderer>().color = color;
    }
}
