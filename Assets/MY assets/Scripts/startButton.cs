using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public float gameMode = 5;
    public bool unkillebale = false;

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeSceneByName(string name)
    {
        if (name != null) SceneManager.LoadScene(name);
    }

    public void GameMode(float mode)
    {
        if(mode == 99)
        {
            unkillebale = true;
            gameMode = 5;
        }
        else
        {
            gameMode = mode;
        }
        SceneManager.LoadScene("Game");
    }
}
