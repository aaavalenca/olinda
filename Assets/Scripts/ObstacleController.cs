using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private Rigidbody2D obstRB;

    // Start is called before the first frame update
    void Start()
    {
        obstRB = GetComponent<Rigidbody2D>();
        //obstRB.velocity = new Vector2(-5f, 0);
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Translate(Vector2.left * 5f * Time.smoothDeltaTime);
    }
    
}
