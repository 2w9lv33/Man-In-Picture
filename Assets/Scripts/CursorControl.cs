using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    public Texture2D cursorTexture_0;
    public Texture2D cursorTexture_1;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public ColorSystem ColorSystem;
    public Vector3 mousePosition;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetItem(mousePosition);
    }

    private void GetItem(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Item")
            {
                if(ColorSystem.palette != Game.Color.MyColor.NOCOLOR)
                {
                    Cursor.SetCursor(cursorTexture_1, hotSpot, cursorMode);
                }
                else
                {
                    Cursor.SetCursor(cursorTexture_0, hotSpot, cursorMode);
                }
            }
            else
            {
                Cursor.SetCursor(null, hotSpot, cursorMode);
            }
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }
}
