using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderEnable : MonoBehaviour
{
    void OnEnable()
    {
        transform.GetComponent<SpriteRenderer>().GetComponent<Renderer>().receiveShadows = true;
        transform.GetComponent<SpriteRenderer>().GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }
}
