using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableThis : MonoBehaviour
{
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
