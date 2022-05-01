using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameController gameController;

    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        Vector3 xPos = transform.position;
        if (xPos.x < -24)
        {

            gameObject.transform.position = new Vector3(50f, 25f, 0); ;
            gameObject.SetActive(false);
            
        }
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Translate(Vector2.left * gameController.speedObstacle * Time.smoothDeltaTime);
    }

}
