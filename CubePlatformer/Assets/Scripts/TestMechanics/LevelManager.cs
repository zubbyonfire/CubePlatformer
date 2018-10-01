using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//What this script does:
//Handles loading scenes
public static class LevelManager {

    public static void RestartScene (int sceneBuildNumber)
    {
        //Restart the current scene
        SceneManager.LoadScene(sceneBuildNumber);
    }

    public static void LoadNextScene (int sceneBuildNumber)
    {
        Debug.Log("delete me");
        //Load the next scene
        SceneManager.LoadScene(sceneBuildNumber + 1);
    }
	
}
