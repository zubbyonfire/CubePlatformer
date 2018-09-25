using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
#if UNITY_EDITOR


public class GenerateEnum : MonoBehaviour {

    [MenuItem("Tools/GenerateEnum")]
    public static void Go()
    {
        string enumName = "SceneList";
        List<string> sceneNames = new List<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            sceneNames.Add(GetSceneNameByBuildIndex(i));
        }

        string filePathAndName = "Assets/Scripts/Enums/" + enumName + ".cs"; //Make sure Enum folder exists

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < sceneNames.Count; i++)
            {
                if (i != sceneNames.Count - 1)
                {
                    streamWriter.WriteLine("\t" + sceneNames[i] + ",");
                }
                else
                {
                    streamWriter.WriteLine("\t" + sceneNames[i]);
                }
            
            }
            streamWriter.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }

    public static string GetSceneNameByBuildIndex(int buildIndex)
    {
        return GetSceneNameFromScenePath(SceneUtility.GetScenePathByBuildIndex(buildIndex));
    }

    private static string GetSceneNameFromScenePath(string scenePath)
    {
        // Unity's asset paths always use '/' as a path separator
        int sceneNameStart = scenePath.LastIndexOf("/") + 1;
        int sceneNameEnd = scenePath.LastIndexOf(".");
        int sceneNameLength = sceneNameEnd - sceneNameStart;
        return scenePath.Substring(sceneNameStart, sceneNameLength);
    }
}
#endif