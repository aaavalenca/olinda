using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int amount = 5;

    private List<GameObject> instances;
    private int lastInstanceIndex = 0;

    void Awake()
    {
        instances = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            var instance = Instantiate(prefab);
            instance.SetActive(false);
            instances.Add(instance);
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