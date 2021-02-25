using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidAnalyzer : MonoBehaviour
{
    //public string GameScene_First, GameScene_Last;

    //private string nextScene;
    private GameObject[] activeAsteroids;
    public void Update()
    {
        activeAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (activeAsteroids.Length == 0)
        {
            Victory();
        }
    }

    public void Victory()
    {
        if (activeAsteroids.Length == 0)
        {
            SceneManager.LoadScene("WonScene");
        }
    }
}
