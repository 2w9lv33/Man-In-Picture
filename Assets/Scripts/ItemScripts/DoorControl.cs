using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject player;
    public Animator door;
    [SerializeField] private bool doorIsTriggered;

    void Update()
    {
        if (doorIsTriggered)
        {
            player.SetActive(false);
            door.SetBool("Open", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            doorIsTriggered = true;
        }
    }

    public void FinishOpen()
    {
        door.SetBool("Open", false);
    }

    public void LoadFirstScene()
    {
        AsynLoad.LoadSceneAsync("FirstScene");
    }
}
