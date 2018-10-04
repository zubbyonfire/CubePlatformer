using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlatformLogic : MonoBehaviour {

    //Platform movement variables
    [SerializeField]
    private float platformMoveSpeed;

    [SerializeField]
    [Range(0,5)]
    private float startPos = 1, endPos = 1;

    private Vector2 startTargetPos, endTargetPos;
    private float minPos, maxPos;

    [Tooltip("Does the platform wait upon reaching it's target, before moving back")]
    [SerializeField]
    private bool wait;

    [SerializeField]
    private float waitTime;

    private enum MovementDirection
    {
        Horizontal,
        Vertical
    }

    [SerializeField]
    private MovementDirection movementDirection;

    //Where does the platform start when the level begins
    private enum PlatformInitalMoveDirection
    {
        Start,
        End
    }

    [SerializeField]
    private PlatformInitalMoveDirection platformInitalMoveDirection;

    private IEnumerator currentCoroutine; //Current coroutine 

    static float time = 0.0f;

	// Use this for initialization
	void Start () {

        SetupPlatform();
	}

    void SetupPlatform()
    {
        if (movementDirection == MovementDirection.Horizontal)
        {
            startTargetPos = new Vector2(transform.position.x + startPos, transform.position.y);
            endTargetPos = new Vector2(transform.position.x - endPos, transform.position.y);

            minPos = startTargetPos.x;
            maxPos = endTargetPos.x;

            if (platformInitalMoveDirection == PlatformInitalMoveDirection.End)
            {
                SwitchDirection();
            }

            //currentCoroutine = MovePlatform(minPos, maxPos);
        }
        else
        {
            startTargetPos = new Vector2(transform.position.x, transform.position.y + startPos);
            endTargetPos = new Vector2(transform.position.x, transform.position.y - endPos);

            minPos = startTargetPos.y;
            maxPos = endTargetPos.y;

            if (platformInitalMoveDirection == PlatformInitalMoveDirection.End)
            {
                SwitchDirection();
            }

            //currentCoroutine = MovePlatform(minPos, maxPos);
        }

        StartCoroutine(currentCoroutine); //Start the move platform coroutine
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //Switch values between min and max pos
    void SwitchDirection()
    {
        float tempValue = minPos;
        minPos = maxPos;
        maxPos = tempValue;
    }

    IEnumerator MovePlatformHorizontal (float min, float max)
    {
        

        yield return null;
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
        Handles.Label(new Vector2(startTargetPos.x - 0.15f, startTargetPos.y + 0.3f), "Start");

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, endTargetPos);
        Gizmos.DrawCube(endTargetPos, new Vector3(0.25f, 0.25f, 0));
        Handles.Label(new Vector2(endTargetPos.x - 0.1f, endTargetPos.y + 0.3f), "End");
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
