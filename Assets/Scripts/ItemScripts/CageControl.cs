using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageControl : MonoBehaviour
{
    public Animator cage1, cage2;
    public Game.Color color;
    public GameObject bigman;
    public SpriteMask SpriteMask;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(color.myColor == color.checkColor)
        {
            cage1.SetBool("Save", true);
            cage2.SetBool("Save", true);
            transform.Find("Pop").gameObject.SetActive(false);
            SpriteMask.enabled = true;
            Player.GetComponent<Animator>().SetBool("Get",true);
            color.checkColor = Game.Color.MyColor.NOCOLOR;
        }
    }

    public void SetBigMan()
    {
        bigman.SetActive(true);
    }
}
