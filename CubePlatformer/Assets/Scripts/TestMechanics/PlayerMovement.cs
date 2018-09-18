using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 0f, jumpForce = 0f, movementSmoothing = 0.5f;

    private float distToGround = 0f;

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb2D = null;

    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(float move, bool jump)
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
}
