using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour
{
    public delegate void ShowShade();

    public event ShowShade onLightLeft;
    public event ShowShade onLightRight;
}
