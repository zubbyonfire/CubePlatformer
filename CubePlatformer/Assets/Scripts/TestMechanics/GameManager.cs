using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void MobileTap();
    public static event MobileTap OnTap;

    public delegate void SceneChange();
    public static event SceneChange ChangeScene;

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
		if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnTap();
            }
        }
	}

    public void RestartLevel() //Restart the current scene
    {
        ChangeScene();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex)); //Reload this scene
    }

    public void LoadNextLevel() //Load the next scene
    {
        ChangeScene();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); //Load next scene
    }

    IEnumerator LoadLevel(int newSceneIndex)
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene(newSceneIndex);
    }
}
