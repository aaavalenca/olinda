using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{

    private GameController _gameController;

    public bool _floorInst = false;
    
    
    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
    }

    void Start()
    {
        // o script em si é um objeto do tipo GameController. Assim que o pegamos.
        _gameController = (GameController)FindObjectOfType(typeof(GameController));
    }

    // Update is called once per frame
    void Update()
    {
        if (!_floorInst)
        {
            if (transform.position.x <= -8)
            {
                // passou de uma determinada posição, cria um novo objeto do tipo groundPrefab
                GameObject _tempFloor = Instantiate(_gameController._groundPrefab);
                //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                //spriteRenderer.size = new Vector2();
                // dá para fazer as valas abertas somando valores ao x (podem ser aleatórios, ou em função da velocidade)
                _tempFloor.transform.position = new Vector3(transform.position.x + _gameController._groundSize * transform.localScale.x, transform.position.y, 0);
                _floorInst = true;
            }
        }

        if (transform.position.x < _gameController._groundDestroyed)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        MoveGround();
    }

    void MoveGround()
    {
        // move o objeto ao qual esse script (RepeatGround) está associado para a esquerda,
        // multiplicando o vetor para a esquerda pela velocidade que está no script gameController
        // e pelo Time.deltaTime (um tempo fixo). v * t = s; temos o deslocamento do objeto
        transform.Translate(Vector2.left * _gameController._groundSpeed * Time.deltaTime);
    }
}
