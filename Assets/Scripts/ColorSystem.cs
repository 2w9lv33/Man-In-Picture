using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSystem : MonoBehaviour
{
    public GameObject player;
    public PlayerController PlayerController;
    public Animator animator;
    public Text text;
    private Vector3 mousePosition;
    //Player's Palette
    [SerializeField] public Game.Color.MyColor palette;
    public Image UI;

    private void Update()
    {
        animator.SetBool("Use", false);
        if (Input.GetMouseButtonDown(1) && !animator.GetBool("Using") && !animator.GetBool("Get") && PlayerController.canMove)
        {
            Debug.Log("MouseDown");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("Use", true);
            GetColor(mousePosition);
        }
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("Using") && !animator.GetBool("Get") && PlayerController.canMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("Use", true);
            SetColor(mousePosition);
        }
        if(player.GetComponent<Game.Color>().myColor == Game.Color.MyColor.WALL)
        {
            Hide();
        }
        else
        {
            //UnHide();
        }       
    }

    //set color
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

    //get color
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
                ChangeUI(palette);
            }
        }
    }

    public void ChangeUI(Game.Color.MyColor myColor)
    {
        switch (myColor)
        {
            case Game.Color.MyColor.RED:
                UI.color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.WALL:
                UI.color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.BLUE:
                UI.color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                UI.color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                UI.color = UnityEngine.Color.gray;
                break;
            default:
                break;
        }
    }

    //hide!
    private void Hide()
    {
        Color color = player.GetComponent<SpriteRenderer>().color;
        color.a = 0.1f;
        player.GetComponent<SpriteRenderer>().color = color;
        PlayerController.canBeSeen = false;
    }

    private void UnHide()
    {
        Color color = player.GetComponent<SpriteRenderer>().color;
        color.a = 1f;
        player.GetComponent<SpriteRenderer>().color = color;
        PlayerController.canBeSeen = true;
    }

}
