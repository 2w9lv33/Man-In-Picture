﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControl : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<SpriteMask>().sprite = this.GetComponent<SpriteRenderer>().sprite;
    }
}
