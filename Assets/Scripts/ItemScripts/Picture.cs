using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    [SerializeField] private Game.Color.MyColor myColor;
    [SerializeField] private Game.Color.MyColor checkColor;
    public Game.Color Color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myColor = Color.myColor;
        switch (myColor)
        {
            case Game.Color.MyColor.RED:
                transform.GetComponent<Image>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.WALL:
                transform.GetComponent<Image>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.BLUE:
                transform.GetComponent<Image>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                transform.GetComponent<Image>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                transform.GetComponent<Image>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.NOCOLOR:
                transform.GetComponent<Image>().color = UnityEngine.Color.white;
                break;
            default:
                break;
        }
    }
}
