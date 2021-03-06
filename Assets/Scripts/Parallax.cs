using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private Renderer renderObj;
    private Material objectMat;
    private GameController gameController;
    public float offset;
    public float offsetIncr;
    private float offsetSpeed;
    
    public string sortingLayer;
    public int orderInLayer;


    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        renderObj = GetComponent<MeshRenderer>();

        // permite mudar a ordem da layer
        renderObj.sortingLayerName = sortingLayer;
        renderObj.sortingOrder = orderInLayer;
        
        objectMat = renderObj.material;
        
        gameController = (GameController)FindObjectOfType(typeof(GameController));

    }

    // Update is called once per frame
    void Update()
    {

        offsetSpeed = gameController.groundSpeed;
        offset += offsetIncr;
        objectMat.SetTextureOffset("_MainTex", new Vector2(offset * offsetSpeed, 0f));

    }
}
