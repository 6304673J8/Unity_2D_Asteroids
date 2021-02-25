using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;
    private GameObject[] activeAsteroids;
    public enum Scene
    {
        TitleScene,
        GameScene_First,
        GameScene_Last,
        WonScene,
        LostScene
    }

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
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("test_space");
                    nextSceneToLoad++;
                }
                break;
            case 1:
                Debug.Log("test_asteroide 1");
                AsteroidsAnalyzer();
                break;
            case 2:
                Debug.Log("test_asteroide 2");
                AsteroidsAnalyzer();
                break;
            case 3:
                ReturnToTitleScreen();
                break;
            case 4:
                ReturnToTitleScreen();
                break;
        }
    }

    private void AsteroidsAnalyzer()
    {
        activeAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (activeAsteroids.Length == 0)
        {
            sceneToLoad++;
        }
    }

    private void ReturnToTitleScreen()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sceneToLoad = 0;
        }
    }
}
