using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    private GameObject _ground;
    public TextMeshProUGUI scoreUI;
    public double distance;
    void Start()
    {
        scoreUI = GetComponent<TextMeshProUGUI>();
        _ground = GameObject.FindGameObjectWithTag("GroundSpeed");
        distance = _ground.GetComponent<Parallax>().offset;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Math.Floor(_ground.GetComponent<Parallax>().offset);
        scoreUI.text = distance.ToString();
    }
}
