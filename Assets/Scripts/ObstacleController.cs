using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameController gameController;
    private ObjectPool op;
    private bool isGrounded = false;

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
                gameObject.transform.position = new Vector3(27f, 3.5f, 0);
            }
            else {
                gameObject.transform.position = new Vector3(27f, 11f, 0);
            }
            gameObject.SetActive(false);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        
        if (gameObject.CompareTag("Agua") || gameObject.CompareTag("Axe"))
        {
            MoveObject();
        }
        else {
            if (isGrounded)
            {
                MoveObject();
            }
        }
    }

    void MoveObject()
    {
        transform.Translate(Vector2.left * gameController.speedObstacle * Time.smoothDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && (this.CompareTag("Agua") || this.CompareTag("Axe")))
        {
            gameObject.transform.position = new Vector3(50f, 3.5f, 0);
            gameObject.SetActive(false);
        }
    }
}
