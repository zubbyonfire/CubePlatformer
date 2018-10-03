using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//What this script does:
//Handles loading scenes
public static class LevelManager {

    public static string previousSceneName;

    public static void RestartScene ()
    {
        //Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void LoadNextScene ()
    {
        //Update the LevelObjectScriptableObjeect
        previousSceneName = SceneManager.GetActiveScene().name;

        //Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadTargetScene(string sceneName)
    {
        //Load specific scene
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
