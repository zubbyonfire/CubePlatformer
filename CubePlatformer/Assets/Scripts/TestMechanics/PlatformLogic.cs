using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour {

    //Platform movement variables
    [SerializeField]
    private float platformMoveSpeed;

    [SerializeField]
    [Range(0,5)]
    private float startPos = 1, endPos = 1;

    private Vector2 startTargetPos, endTargetPos;

    //Platform logic
    [Tooltip("Does this platform require player to be on to start moving")]
    [SerializeField]
    private bool playerTriggerActive = false;

    [Tooltip("Does the platform continuosly move back and forth")]
    [SerializeField]
    private bool continuosMovement = false;

    private enum MovementDirection
    {
        Horizontal,
        Vertical
    }

    [SerializeField]
    private MovementDirection movementDirection;

    //Where does the platform start when the level begins
    private enum PlatformStartPosition
    {
        None,
        Start,
        End
    }

    [SerializeField]
    private PlatformStartPosition platformStartPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        switch (movementDirection)
        {
            case MovementDirection.Horizontal:
                startTargetPos = new Vector2(transform.position.x + startPos, transform.position.y);
                endTargetPos = new Vector2(transform.position.x - endPos, transform.position.y);
                break;
            case MovementDirection.Vertical:
                startTargetPos = new Vector2(transform.position.x, transform.position.y + startPos);
                endTargetPos = new Vector2(transform.position.x, transform.position.y - endPos);
                break;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, startTargetPos);
        Gizmos.DrawCube(startTargetPos, new Vector3(0.25f, 0.25f, 0));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, endTargetPos);
        Gizmos.DrawCube(endTargetPos, new Vector3(0.25f, 0.25f, 0));
    }

    //Child the Player while they collide with the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //De-Child the player once they exit the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
