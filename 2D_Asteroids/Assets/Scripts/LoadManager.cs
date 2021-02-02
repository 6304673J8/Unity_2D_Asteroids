using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadManager
{
    public enum Scene
    {
        TitleScene,
        Loading,
        GameScene,
        WonScene,
        LostScene,
    }
    private static Action onLoader;

    public static void Load(Scene scene)
    {
        onLoader = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.Loading.ToString());
    }
    public static void Loader()
    {
        //Triggers after the first update
        //Executes onLoader which will load the desired scene
        if (onLoader != null)
        {
            onLoader();
            onLoader = null;
        }
    }
}