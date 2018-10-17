using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CameraFollow))]
public class CameraLimitSetup : MonoBehaviour {

    [SerializeField]
    [Range(9, 100)]
    private float minX, maxX;
    public float minXPos { get { return minXPos; } set { minXPos = value; } }
    public float maxXPos { get { return maxXPos; } set { maxXPos = value; } }

    [SerializeField]
    [Range(0, 100)]
    private float minY, maxY;
    public float minYPos { get { return minYPos; } set { minYPos = value; } }
    public float maxYPos { get { return maxYPos; } set { maxYPos = value; } }

    private Vector2 topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner;

    private Vector2 centerPos = Vector2.zero;
    private Vector2 topPos, leftPos, rightPos, bottomPos;

    public Vector2 topPosition { get { return topPos; } }
    public Vector2 leftPosition { get { return leftPos; } }
    public Vector2 rightPosition { get { return rightPos; } }
    public Vector2 bottomPosition { get { return bottomPos; } }

    private float heightSize, lengthSize;

    private CameraFollow followScript;

	// Use this for initialization
	void Start () {
        followScript = gameObject.GetComponent<CameraFollow>();
        followScript.LimitSetup(minX, maxX, minY, maxY);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        //If the application is not playing
        //if (!Application.isPlaying)
        //{ 
            topPos = new Vector2(centerPos.x, centerPos.y + maxY);
            leftPos = new Vector2(centerPos.x - minX, centerPos.y);
            rightPos = new Vector2(centerPos.x + maxX, centerPos.y);
            bottomPos = new Vector2(centerPos.x, centerPos.y - minY);

            Gizmos.color = Color.blue;

            //Draw line between the top two points
            Gizmos.DrawLine(new Vector2(leftPos.x, topPos.y), new Vector2(rightPos.x, topPos.y));
            //Draw line between the bottom two points
            Gizmos.DrawLine(new Vector2(leftPos.x, bottomPos.y), new Vector2(rightPos.x, bottomPos.y));
            //Draw line between left hand points
            Gizmos.DrawLine(new Vector2(leftPos.x, topPos.y), new Vector2(leftPos.x, bottomPos.y));
            //Draw line between right hand points
            Gizmos.DrawLine(new Vector2(rightPos.x, topPos.y), new Vector2(rightPos.x, bottomPos.y));
        //}
    }
}
