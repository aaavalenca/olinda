using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameController gameController;
    private ObjectPool op;


    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        op = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        Vector3 xPos = transform.position;
        if (xPos.x < -24)
        {


            if (gameObject.CompareTag("Agua") || gameObject.CompareTag("Axe"))
            {
                gameObject.transform.position = new Vector3(50f, 3.5f, 0);

            }
            else if (gameObject.CompareTag("Boi"))
            {
                gameObject.transform.position = new Vector3(50f, -2f, 0);

            }
            else {
                gameObject.transform.position = new Vector3(50f, 25f, 0);
            }

            gameObject.SetActive(false);
            op.ReturnInstance();
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
