using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    public Game.Color playerColor;
    public Animator animator;

    void Update()
    {
        if (flag)
        {
            animator.SetBool("Open", true);
            playerColor.transform.gameObject.SetActive(false);
            Invoke("WaitAndReLoad", 2f);
        }
        flag = false;
    }

    public void WaitAndReLoad()
    {
        AsynLoad.LoadScene("FirstScene");
    }

    public void Change()
    {
        transform.parent.Find("Trap_after").gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(playerColor.myColor != Game.Color.MyColor.RED)
            {
                flag = true;
            }
        }
    }
}
