using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.BLUE:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            default:
                break;
        }
    }
}
