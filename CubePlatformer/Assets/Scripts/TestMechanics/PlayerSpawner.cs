using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class PlayerSpawner : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class LevelData
{
    private int sceneNumber;
    private string sceneName;
    
    public LevelData(int _number, string _name)
    {
        sceneNumber = _number;
        sceneName = _name;
    }
}
