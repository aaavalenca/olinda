using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    public static Dictionary<string, Queue<GameObject>> Pool1;
    private GameObject[] prefabs;

    private List<string> keys;

    // 0 - "Agua"; 1- "Axe"; 2 - "Bloco 1"; 3 - "Bloco 2"; 4 - "Bloco 3"; 5 - "Bloco 4"; 6 - "Boi";
    private int[] pn1 = {4, 5};
    private int[] pn2 = {0};
    private int[] pn3 = {0, 2, 3, 4, 5};
    private int[] pn4 = {0, 0, 1, 2, 2, 2, 3, 4, 4, 5, 6};
    private int[] pn5 = {0, 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 6, 6};

    private List<int[]> pn;

    // private Queue<GameObject> iQueue;
    // private Queue<int> index;

    private (int, GameObject) inst;
    private Queue<(int, GameObject)> iQueue;
    private int index;
    
    private GameObject instance;
    private GameObject retInstance;

    private int rn;
    private int bull;
    private int purva;

    void Awake()
    {
        pn = new List<int[]>();
        pn.Add(pn1);
        pn.Add(pn2);
        pn.Add(pn3);
        pn.Add(pn4);
        pn.Add(pn5);
        
        keys = new List<string>();
        // iQueue = new Queue<GameObject>();
        // index = new Queue<int>();
        iQueue = new Queue<(int, GameObject)>();
        
        Pool1 = new Dictionary<string, Queue<GameObject>>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        prefabs = Resources.LoadAll<GameObject>("Prefabs");

        foreach(GameObject i in prefabs)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            var inst = Instantiate(i);
            var inst2 = Instantiate(i);
            var inst3 = Instantiate(i);
            var inst4 = Instantiate(i);
            var inst5 = Instantiate(i);
            var inst6 = Instantiate(i);
            
            inst.SetActive(false);
            inst2.SetActive(false);
            inst3.SetActive(false);
            inst4.SetActive(false);
            inst5.SetActive(false);
            inst6.SetActive(false);

            queue.Enqueue(inst);
            queue.Enqueue(inst2);
            queue.Enqueue(inst3);
            queue.Enqueue(inst4);
            queue.Enqueue(inst5);
            queue.Enqueue(inst6);

            keys.Add(i.tag);
            
            Pool1.Add(i.tag, queue);

        }
 
    }

    private int GetLevel()
    {

        
        
        return 0;
    }

    public GameObject GetInstance()
    {
        
        if (Time.time < 80f)
        {
            purva = 0;
        } else if (Time.time >= 80 && Time.time < 86)
        {
            purva = 1;
        } else if (Time.time >= 86 && Time.time < 120)
        {
            purva = 2;
        }
        else
        {
            purva = 3;
        }
        
        int random = Random.Range(0, pn[purva].Length);
        rn = pn[purva][random];
        
        if (random == 6 && bull < 13)
        {
            return GetInstance();
        } 
        if (Pool1[keys[rn]].Count != 0)
        {
            bull++;
            instance = Pool1[keys[rn]].Dequeue();
            Pool1[keys[rn]].Enqueue(instance);
            return instance;
        } else
        {
            return GetInstance();
        }
    }

}