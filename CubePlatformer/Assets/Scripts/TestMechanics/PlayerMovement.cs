using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPlatform
{
    [SerializeField]
    private float movementSmoothing = 0.5f;

    private Collider2D playerCollider = null;
    private float distToGround = 0f; //Distance from center of object to bottom of objects bounds
    private float distToSides = 0f; //Distance from center of object to edge of object bounds

    [SerializeField]
    private float jumpForceLeftRight;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private LayerMask wallJumpLayer;

    [SerializeField]
    [Range(0.1f, 1)]
    private float groundDistCheck = 0.1f;

    [SerializeField]
    private Rigidbody2D rb2D = null;

    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<Collider2D>();
        distToSides = playerCollider.bounds.extents.x;
        distToGround = playerCollider.bounds.extents.y;   
    }

    public void Move(float move, bool jump, float jumpForce)
    {
        if (rb2D == null)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);

        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (IsGrounded() && jump)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
        else if (!IsGrounded() && IsWallJumpLeft() && jump)
        {
            //Jump right
            rb2D.AddForce(new Vector2(jumpForceLeftRight, jumpForce));
            Debug.Log("Jump Right");
        }
        else if (!IsGrounded() && IsWallJumpRight() && jump)
        {
            //Jump left
            rb2D.AddForce(new Vector2(-jumpForceLeftRight, jumpForce));
            Debug.Log("Jump Left");
        }
    }

    //Check if the Player is grounded
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 position1 = new Vector2(transform.position.x - distToSides + 0.05f, transform.position.y);
        Vector2 position2 = new Vector2(transform.position.x + distToSides - 0.05f, transform.position.y);

        Vector2 direction = Vector2.down;
        float distance = distToGround + 0.1f;

        Debug.DrawRay(position, direction * distance, Color.red);
        Debug.DrawRay(position1, direction * distance, Color.blue);
        Debug.DrawRay(position2, direction * distance, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position1, direction, distance, groundLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(position2, direction, distance, groundLayer);

        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            return true;
        } 

        return false;
    }

    bool IsWallJumpLeft()
    {
        Vector2 position = transform.position;
        Vector2 position1 = new Vector2(transform.position.x, transform.position.y + distToGround);
        Vector2 position2 = new Vector2(transform.position.x, transform.position.y - distToGround);

        Vector2 direction = Vector2.left;
        float distance = distToSides + 0.1f;

        Debug.DrawRay(position, direction * distance, Color.cyan);
        Debug.DrawRay(position1, direction * distance, Color.magenta);
        Debug.DrawRay(position2, direction * distance, Color.grey);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance);
        RaycastHit2D hit2 = Physics2D.Raycast(position1, direction, distance);
        RaycastHit2D hit3 = Physics2D.Raycast(position2, direction, distance);

        if (hit.collider != null && hit2.collider != null && hit3.collider != null)
        {
            if (hit.collider.tag == "WallJump" || hit2.collider.tag == "WallJump" || hit3.collider.tag == "WallJump")
            {
                return true;
            }
        }

        return false;
    }

    bool IsWallJumpRight()
    {
        Vector2 position = transform.position;
        Vector2 position1 = new Vector2(transform.position.x, transform.position.y + distToGround);
        Vector2 position2 = new Vector2(transform.position.x, transform.position.y - distToGround);

        Vector2 direction = Vector2.right;
        float distance = distToSides + 0.1f;

        Debug.DrawRay(position, direction * distance, Color.cyan);
        Debug.DrawRay(position1, direction * distance, Color.magenta);
        Debug.DrawRay(position2, direction * distance, Color.grey);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance);
        RaycastHit2D hit2 = Physics2D.Raycast(position1, direction, distance);
        RaycastHit2D hit3 = Physics2D.Raycast(position2, direction, distance); ;

        if (hit.collider != null && hit2.collider != null && hit3.collider != null)
        {
            if (hit.collider.tag == "WallJump" || hit2.collider.tag == "WallJump" || hit3.collider.tag == "WallJump")
            {
                return true;
            }
        }

        return false;
    }


    public void OnPlatform(bool onPlatform)
    { 
        if (onPlatform) //If on platform freeze rotation, otherwise unFreeze it
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            transform.rotation = Quaternion.Euler(0,0,0); 
        }
        else
        {
            rb2D.constraints = RigidbodyConstraints2D.None;
        }

    }
}
