using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColor : MonoBehaviour
{
    void Update()
    {
        if(this.GetComponent<Game.Color>().myColor == this.GetComponent<Game.Color>().checkColor)
        {
            this.transform.Find("Room_1").gameObject.SetActive(false);
            this.transform.Find("Room_2").gameObject.SetActive(true);
        }
    }
}
