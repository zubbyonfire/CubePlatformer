using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private LevelLoadScriptableObject levelLoadScriptableObject;

    public delegate void MobileTap();
    public static event MobileTap OnTap;

    public delegate void SceneChange();
    public static event SceneChange ChangeScene;

    public delegate void SpawnPlayer(string previousSceneName);
    public static event SpawnPlayer PlayerSpawn;

    public static GameManager instance = null; //Static Instance of GameManager 

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            instance = this; //Instance = this
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
