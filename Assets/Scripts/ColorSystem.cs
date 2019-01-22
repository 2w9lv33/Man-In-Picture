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
    private Vector3 mousePosition;
    [SerializeField]public bool Use = false;
    public bool IsUILayer = false;
    [SerializeField] public Game.Color.MyColor palette;

    private void Update()
    {
        Click();
        ChangePlayerColor(palette);
    }

    public void Click()
    {
        if (palette == Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !IsUILayer)
            {
                Use = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Mathf.Abs(player.transform.position.x - mousePosition.x) < 3f && Use)
            {
                GetColor(mousePosition);
                Use = false;
                player.GetComponent<PlayerMove>().moveVelocity = 0f;
                animator.SetFloat("Speed", -5f);
            }
        }
        if (palette != Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !IsUILayer)
            {
                Use = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Mathf.Abs(player.transform.position.x - mousePosition.x) < 3f && Use)
            {
                SetColor(mousePosition);
                Use = false;
                player.GetComponent<PlayerMove>().moveVelocity = 0f;
                animator.SetFloat("Speed", -5f);
            }
        }
    }

    //set color
    private void SetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Item" && hit.transform.GetComponent<Game.Color>().canBeSet && palette != Game.Color.MyColor.NOCOLOR)
            {
                PlayerController.canMove = false;
                animator.SetBool("Use", true);
                hit.transform.GetComponent<Game.Color>().myColor = palette;
                palette = Game.Color.MyColor.NOCOLOR;
                ChangePlayerColor(palette);
            }
        }
    }

    public bool IsItem(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Item")
            {
                return true;
            }
        }
        return false;
    }

    //get color
    private void GetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if(hit.collider != null)
        {
            if (hit.transform.tag == "Item" && hit.transform.GetComponent<Game.Color>().canBeGet)
            {
                PlayerController.canMove = false;
                animator.SetBool("Use", true);
                palette = hit.transform.GetComponent<Game.Color>().myColor;
                ChangePlayerColor(palette);
            }
        }
    }

    public void ChangePlayerColor(Game.Color.MyColor myColor)
    {
        player.GetComponent<Game.Color>().myColor = myColor;
        switch (myColor)
        {
            case Game.Color.MyColor.RED:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.WALL:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.BLUE:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.NOCOLOR:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
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
