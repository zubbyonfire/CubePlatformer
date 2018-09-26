﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class PlayerSpawner : MonoBehaviour {

    [SerializeField]
    private bool levelStart = false; //Is this the first scene in a level

    public bool LevelStart { get { return levelStart; } set { levelStart = value; } }

    [SerializeField]
    private SceneList sceneList; //Enum of all levels

    public SceneList SceneList { get { return sceneList; } set { sceneList = value; } }

    public PlayerObjectScrtipableObject playerData;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnPlayer(string previousSceneName) //Spawn the player at the spawn transform
    {
        if (previousSceneName == sceneList.ToString())
        {
            GameObject spawnedPlayer = playerData.playerObject;

            Instantiate(spawnedPlayer, transform.position, transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 0));
    }
}

[CustomEditor(typeof(PlayerSpawner))]
public class PlayerSpawnerEditor:Editor
{
    override public void OnInspectorGUI()
    {
        var playerSpawner = target as PlayerSpawner;

        playerSpawner.LevelStart = GUILayout.Toggle(playerSpawner.LevelStart, "Level Start");

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(playerSpawner.LevelStart)))
        {
            if (group.visible == false)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PrefixLabel("Scene List");
                playerSpawner.SceneList = (SceneList)EditorGUILayout.EnumPopup(playerSpawner.SceneList);
                EditorGUI.indentLevel--;
            }
        }
    }
}
