
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What this script does:
//Handles player movement logic
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour {

    private static PlayerController instance;

    private PlayerMovement playerMovement;
    private PlayerInput playerInput;

    [Range(1, 5)]
    [SerializeField]
    private float speedMode = 1;

    [Range(100,1000)]
    [SerializeField]
    private float jumpForce = 500;

    private bool jump = false;

    private void Awake()
    {
        //Check if instance already exists, otherwise delete self
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }

    // Use this for initialization
    void Start () {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerMovement.Move(playerInput.HorizontalInput() * speedMode, jump, jumpForce);

        jump = false;
	}

    public void PlayerJump()
    {
        jump = true;
    }
}
