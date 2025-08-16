using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public float gameMode = 5;
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
        gameMode = mode;
        SceneManager.LoadScene("Game");
    }
}
