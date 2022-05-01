using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> instances;
    private GameObject[] prefabs;
    private int lastInstanceIndex = 0;

    void Awake()
    {
        
        instances = new List<GameObject>();

        prefabs = Resources.LoadAll<GameObject>("Prefabs");

        foreach(GameObject i in prefabs)
        {
            var inst = Instantiate(i);
            inst.SetActive(false);
            instances.Add(inst);
        }
    }

    public GameObject GetInstance()
    {
        GameObject instance = instances[lastInstanceIndex++];
        if (lastInstanceIndex >= instances.Count)
            lastInstanceIndex = 0;

        return instance;
    }
}