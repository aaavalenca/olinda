using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMusic : MonoBehaviour
{

    private AudioSource _as;
    [SerializeField] AudioClip[] audioClipArray;
    

    void Start()
    {
        _as = GetComponent<AudioSource>();
        AudioClip clip = audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
        _as.PlayOneShot(clip);
    }

    private void Update()
    {
        if (!_as.isPlaying)
        {
            AudioClip clip = audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
            _as.PlayOneShot(clip);
        }
    }
}
