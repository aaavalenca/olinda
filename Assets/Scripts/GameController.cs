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
    public GameObject prefabObstacle;
    public float speedObstacle = 5;
    
    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // prefabObstacle = GetComponent<>()
        StartCoroutine("SpawObstacle");
    }
    

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        groundSpeed += 0.0000001f;

    }

    IEnumerator SpawObstacle()
    {
        yield return new WaitForSeconds(timeObstacle);

        GameObject TimeObstacleObj = Instantiate(prefabObstacle);

        speedObstacle += 1;

        StartCoroutine("SpawObstacle");


    }
    
}
