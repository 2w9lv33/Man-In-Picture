using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private Vector3 vector3 = Vector3.zero;
    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x)
        {
            vector3 = new Vector3(-1, 0, 0);
        }
        else
        {
            vector3 = new Vector3(1, 0, 0);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += vector3 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Die", true);
        }
        transform.gameObject.SetActive(false);
    }
}
