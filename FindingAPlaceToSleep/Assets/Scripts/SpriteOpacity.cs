using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOpacity : MonoBehaviour
{
    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = new Color(1f, 1f, 1f, .5f);
    }
}
