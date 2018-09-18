﻿
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

        controller.Move(horizontalMove, jump);

        jump = false;
	}

    

    private void OnEnable()
    {
        GameManager.OnTap += PlayerJump;
    }

    private void OnDisable()
    {
        GameManager.OnTap -= PlayerJump;
    }

    void PlayerJump()
    {
        Debug.Log("jump");

        jump = true;
    }
}
