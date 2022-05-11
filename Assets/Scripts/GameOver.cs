using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] GameObject gameOverScreen;

    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
