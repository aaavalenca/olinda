using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseHeight : MonoBehaviour
{
    private int i;
    private float[] n = { 0f, 0.125f, 0.25f, 0.375f, 0.5f, 0.625f, 0.75f, 0.875f };
    private GameObject child0;
    private GameObject child1;
    private GameObject child2;
    private GameObject child3;
    private GameObject child4;
    private GameObject child5;
    private GameObject child6;
    private GameObject child7;
    private GameObject[] child;
    private float offset;
    private float offsetSpeed;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = (GameController)FindObjectOfType(typeof(GameController));

        child0 = gameObject.transform.GetChild(0).gameObject;
        child1 = gameObject.transform.GetChild(1).gameObject;
        child2 = gameObject.transform.GetChild(2).gameObject;
        child3 = gameObject.transform.GetChild(3).gameObject;
        child4 = gameObject.transform.GetChild(4).gameObject;
        child5 = gameObject.transform.GetChild(5).gameObject;
        child6 = gameObject.transform.GetChild(6).gameObject;
        child7 = gameObject.transform.GetChild(7).gameObject;
        child = new [] { child0, child1, child2, child3, child4, child5, child6, child7 };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = child0.GetComponent<RotationEffects>().offset;
        offsetSpeed = gameController.groundSpeed;


        if (offset * offsetSpeed >= n[i])
        {
            if (i == 7) {
                for (var j = 0; j < 8; j++) {
                    n[j] += 1.0f;
                }
            }

            for (var k = 0; k < 8; k++) {
                child[k].tag = ((int.Parse(child[k].tag) + 1) % 8).ToString();
            }
            i = (i + 1) % 8;
        }

    }
}
