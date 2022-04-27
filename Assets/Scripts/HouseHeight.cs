using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseHeight : MonoBehaviour
{
    private int i = 0;
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
    private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {

        child0 = this.gameObject.transform.GetChild(0).gameObject;
        child1 = this.gameObject.transform.GetChild(1).gameObject;
        child2 = this.gameObject.transform.GetChild(2).gameObject;
        child3 = this.gameObject.transform.GetChild(3).gameObject;
        child4 = this.gameObject.transform.GetChild(4).gameObject;
        child5 = this.gameObject.transform.GetChild(5).gameObject;
        child6 = this.gameObject.transform.GetChild(6).gameObject;
        child7 = this.gameObject.transform.GetChild(7).gameObject;
        child = new GameObject[] { child0, child1, child2, child3, child4, child5, child6, child7 };
    }

    // Update is called once per frame
    void Update()
    {
        offset = child0.GetComponent<Parallax>().offset;

        if (offset >= n[i])
        {
            if (i == 7) {
                for (int j = 0; j < 8; j++) {
                    n[j] = n[j] + 1.0f;
                }
            }

            for (int k = 0; k < 8; k++) {
                child[k].tag = ((int.Parse(child[k].tag) + 1) % 8).ToString();
            }
            i = (i + 1) % 8;
        }

    }
}
