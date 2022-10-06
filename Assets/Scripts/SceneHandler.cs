using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    bool gameCurrentlyRunning = true;
    GameObject menuButton;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            menuButton = GameObject.Find("MenuButton");
            menuButton.SetActive(false);
        }
            
    }

    void Update()
    {
        if(Input.GetButtonDown("escape") && SceneManager.GetActiveScene().name == "Game")
        {
            gameCurrentlyRunning = !gameCurrentlyRunning;
            menuButton.SetActive(!menuButton.activeInHierarchy);
            Time.timeScale = Convert.ToInt32(gameCurrentlyRunning);
        }
    }
    public void LoadScene(string sceneName)
    {
        if(Time.timeScale == 0)
            Time.timeScale = 1;
            
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
