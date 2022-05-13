using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRed : MonoBehaviour
{

    private SpriteRenderer sr;
    void Start()
    {
        sr = GameObject.Find("RedScreen").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //
        // Color tmp = sr.color;
        // if (tmp.a < 1)
        // {
        //     tmp.a = tmp.a + 0.01f;
        // }
        // sr.color = tmp;
    }

    public void StartFlash()
    {
        Debug.Log("JDEJDo");
        Color tmp = Color.red;
        tmp.a = 0.5f;
        sr.color = tmp;
    }
}
