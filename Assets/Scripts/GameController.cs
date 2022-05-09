using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    // Propriedades do Chão
    [Header("Configuração do Chão")]
    public float groundSpeed = 1;
    
    [Header("Configuração do Obstáculo")]
    public float timeObstacle;
    public ObjectPool objectPool;
    public float speedObstacle = 2;


    [Header("Game Over Screen")]
    public GameOver gameOver;
    
    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacle");
    }
    

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        groundSpeed += 0.0001f;
        
        if (timeObstacle > 1)
        {
            timeObstacle -= 0.0001f;
        }

        
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(timeObstacle);

        GameObject obstacle = objectPool.GetInstance();
        obstacle.SetActive(true);

        if (speedObstacle < 15)
        {
            speedObstacle += 0.25f;
        }

        StartCoroutine("SpawnObstacle");


    }

    public void GameOver()
    {
        gameOver.EndGame();
    }
    
}
