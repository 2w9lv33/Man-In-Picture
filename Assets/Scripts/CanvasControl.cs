using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public ColorSystem ColorSystem;
    public Image UI;
    //public ColorSystem ColorSystem;


    public Texture2D cursorTexture_0;
    public Texture2D cursorTexture_1;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public Vector3 mousePosition;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetItem(mousePosition);

        if (Input.GetMouseButtonDown(1))
        { 
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            if(results.Count > 0)
            {
               ColorSystem.palette = results[0].gameObject.GetComponent<Game.Color>().myColor;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            if (results.Count > 0)
            {
                if (ColorSystem.palette != Game.Color.MyColor.NOCOLOR)
                {
                    results[0].gameObject.GetComponent<Game.Color>().myColor = ColorSystem.palette;
                }
            }
        }

        ChangeUI(ColorSystem.palette);
    }

    private void GetItem(Vector3 mousePosition)
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count > 0)
        {
            if (results[0].gameObject.tag == "Item")
            {
                Cursor.SetCursor(cursorTexture_1, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(cursorTexture_0, hotSpot, cursorMode);
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
}
