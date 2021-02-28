using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;
    private GameObject[] activeAsteroids;
    private GameObject[] activeShip;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        SwitchScenes();
    }
    private void SwitchScenes()
    {
        //Scene scene;
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        switch (sceneToLoad)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LoadGameScene();
                }
                break;
            case 1:
                AsteroidsAnalyzer();
                break;
            case 2:
                AsteroidsAnalyzer();
                break;
            case 3:
                LoadTitleScene();
                break;
            case 4:
                LoadTitleScene();
                break;
        }
    }

    private void AsteroidsAnalyzer()
    {
        activeAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        activeShip = GameObject.FindGameObjectsWithTag("playerShip");

        if (sceneToLoad == 1)
        {
            if (activeAsteroids.Length == 0)
            {
                SceneManager.LoadScene(nextSceneToLoad);
            }
            if (activeShip.Length == 0)
            {
                LoadLostScene();
            }
        }
        else if(sceneToLoad == 2)
        {
            if (activeAsteroids.Length == 0)
            {
                SceneManager.LoadScene(4);
            }
            if (activeShip.Length == 0)
            {
                LoadLostScene();
            }
        }
    }

    private void LoadTitleScene()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadLostScene()
    {
        SceneManager.LoadScene(3);
    }
}
