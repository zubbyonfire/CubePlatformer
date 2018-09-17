
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What this script does:
//Handles player movement logic
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 0f, jumpForce = 0f;

    [SerializeField]
    private float distToGround = 0f;

    private Vector2 movementDirection = Vector2.zero; //Direction player moves in

    private Rigidbody2D rb2D = null;

    [SerializeField]
    private LayerMask groundLayer;

	// Use this for initialization
	void Start () {

        rb2D = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        TiltMovement();
	}

    //Move the player left/right based on tilt input
    void TiltMovement()
    {
        movementDirection = new Vector2(Input.acceleration.x, 0.0f);

        rb2D.velocity = movementDirection * movementSpeed;
    }

    //Check if the Player is grounded
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = distToGround + 0.1f;

        Debug.DrawRay(position, direction * distance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
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
        if (IsGrounded())
        {
            Debug.Log("Jump");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
