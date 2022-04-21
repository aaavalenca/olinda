using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private Rigidbody2D obstRB;

    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
    }
    
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
