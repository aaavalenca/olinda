using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    public static Dictionary<string, Queue<GameObject>> Pool1;
    private GameObject[] prefabs;
    //private readonly string[] keys = { "Agua", "Axe", "1", "2", "3", "4", "Boi" };
    private List<string> keys = new List<string>();

    private int[] pn = { 0, 0, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6 };

    private int index;
    private GameObject instance;
    private int rn;

    void Awake()
    {
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

            inst.SetActive(false);
            inst2.SetActive(false);
            inst3.SetActive(false);

            queue.Enqueue(inst);
            queue.Enqueue(inst2);
            queue.Enqueue(inst3);

            keys.Add(i.tag);

            Pool1.Add(i.tag, queue);

        }

    }

    public GameObject GetInstance()
    {

        rn = pn[Random.Range(0, keys.Count)];
        index = rn;
        instance = Pool1[keys[index]].Dequeue();
        //index = (index + 1) % 7;
        return instance;
    }

    public void ReturnInstance() {
        Pool1[keys[index]].Enqueue(instance);
    }

    

}