﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementSmoothing = 0.5f;

    private Collider2D playerCollider = null;
    private float distToGround = 0f; //Distance from center of object to bottom of objects bounds
    private float distToSides = 0f; //Distance from center of object to edge of object bounds

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb2D = null;

    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<Collider2D>();
        distToSides = playerCollider.bounds.extents.x;
        distToGround = playerCollider.bounds.extents.y;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(float move, bool jump, float jumpForce)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);

        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (IsGrounded() && jump)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    //Check if the Player is grounded
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 position1 = new Vector2(transform.position.x - distToSides, transform.position.y);
        Vector2 position2 = new Vector2(transform.position.x + distToSides, transform.position.y);

        Vector2 direction = Vector2.down;
        float distance = distToGround + 0.1f;

        Debug.DrawRay(position, direction * distance, Color.red);
        Debug.DrawRay(position1, direction * distance, Color.blue);
        Debug.DrawRay(position2, direction * distance, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position1, direction, distance, groundLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(position1, direction, distance, groundLayer);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            return true;
        } 

        return false;
    }
}
