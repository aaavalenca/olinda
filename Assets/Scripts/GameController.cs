using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    // Propriedades do Chão
    [Header("Configuração do Chão")]
    public float _groundDestroyed;
    public float _groundSize;
    public float _groundSpeed;
    public GameObject _groundPrefab;


    [Header("Configuração do Obstáculo")]
    public float _timeObstacle;
    public GameObject _prefabObstacle;
    public float speedObstacle;
    
    // Start is called before the first frame update
    void Start()
    {
        // _prefabObstacle = GetComponent<>()
        StartCoroutine("SpawObstacle");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawObstacle()
    {
        yield return new WaitForSeconds(_timeObstacle);

        GameObject TimeObstacleObj = Instantiate(_prefabObstacle);

        StartCoroutine("SpawObstacle");


    }
    
}
