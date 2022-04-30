using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{

    private GameController gameController;

    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        // o script em si é um objeto do tipo GameController. Assim que o pegamos.
        gameController = (GameController)FindObjectOfType(typeof(GameController));
    }

    // Update is called once per frame
  
    private void FixedUpdate()
    {
        MoveGround();
    }

    void MoveGround()
    {
        // move o objeto ao qual esse script (RepeatGround) está associado para a esquerda,
        // multiplicando o vetor para a esquerda pela velocidade que está no script gameController
        // e pelo Time.deltaTime (um tempo fixo). v * t = s; temos o deslocamento do objeto
        transform.Translate(Vector2.left * gameController.groundSpeed * Time.deltaTime);
    }
}
