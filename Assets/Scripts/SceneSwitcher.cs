using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneSwitcher : MonoBehaviour
{

     private VideoPlayer video;

     private void Start()
     {
          video = GetComponent<VideoPlayer>();
          video.Play();
     }

     private void Update()
     {
          if (!video.isPlaying)
          {
               SwitchScene();
          }
     }

     public void SwitchScene()
     {
          SceneManager.LoadScene("Scenes/Game");
     }
}
