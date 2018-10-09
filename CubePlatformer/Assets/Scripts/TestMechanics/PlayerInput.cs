
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        TouchInput();
    }

    void TouchInput()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerController.PlayerJump();
            }
        }
    }

    public float HorizontalInput()
    {
        return (Input.acceleration.x);
    }

}
