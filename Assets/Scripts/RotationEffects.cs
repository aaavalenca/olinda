using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEffects : MonoBehaviour
{

    private Renderer renderObj;
    private Material objectMat;
    private GameController gameController;
    public float offset;
    public float offsetIncr;
    private float offsetSpeed;

    public string sortingLayer;
    public int orderInLayer;


    private GameObject ground;
    private float tagNum = 0f;
    private float increaseTag = 0f;
    private float rot;
    public float maxrot = 30;

    void Awake()
    {
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

        ground = GameObject.FindGameObjectWithTag("RotatingGround");

        tagNum = float.Parse(transform.tag);
        

    }

    // Update is called once per frame
    void Update()
    {
        offsetSpeed = gameController.groundSpeed;
        increaseTag = offsetSpeed / (0.125f / offsetIncr );
        
        rot = ground.transform.rotation.eulerAngles.z;

        if (tagNum >= 8)
        {
            tagNum = 0f;
            // tagNum = float.Parse(transform.tag);
        }
        offset += offsetIncr;
        objectMat.SetTextureOffset("_MainTex", new Vector2(offset * offsetSpeed, 0f));

        tagNum += increaseTag;

    }
}
