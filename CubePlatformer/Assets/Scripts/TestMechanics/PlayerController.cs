
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What this script does:
//Handles player movement logic
[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

    private PlayerMovement controller;

    [Range(1, 5)]
    [SerializeField]
    private float speedMode = 1;

    [Range(100,1000)]
    [SerializeField]
    private float jumpForce = 500;

    private float horizontalMove = 0f;

    private bool jump = false;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontalMove = Input.acceleration.x;

        horizontalMove *= speedMode;

        controller.Move(horizontalMove, jump, jumpForce);

        jump = false;
	}

    private void OnEnable()
    {
        GameManager.ChangeScene += SceneChange;
        GameManager.OnTap += PlayerJump;
    }

    private void OnDisable()
    {
        GameManager.ChangeScene -= SceneChange;
        GameManager.OnTap -= PlayerJump;
    }

    void SceneChange()
    {
        this.gameObject.SetActive(false);
    }

    void PlayerJump()
    {
        jump = true;
    }
}
