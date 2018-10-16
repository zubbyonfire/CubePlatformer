using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraFollow))]
public class CameraLimitSetup : MonoBehaviour {

    [SerializeField]
    [Range(9, 100)]
    private float minX, maxX;
    [SerializeField]
    [Range(5, 100)]
    private float minY, maxY;

    private Vector2 topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner;

    private Vector2 centerPos = Vector2.zero;
    private Vector2 topPos, leftPos, rightPos, bottomPos;

    private float heightSize, lengthSize;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        //If the application is not playing
        if (!Application.isPlaying)
        { 
            topPos = new Vector2(centerPos.x, centerPos.y + maxY);
            leftPos = new Vector2(centerPos.x - minX, centerPos.y);
            rightPos = new Vector2(centerPos.x + maxX, centerPos.y);
            bottomPos = new Vector2(centerPos.x, centerPos.y - minY);

            //Draw line between the top two points
            Gizmos.DrawLine(new Vector2(leftPos.x, topPos.y), new Vector2(rightPos.x, topPos.y));
            //Draw line between the bottom two points
            Gizmos.DrawLine(new Vector2(leftPos.x, bottomPos.y), new Vector2(rightPos.x, bottomPos.y));
            //Draw line between left hand points
            Gizmos.DrawLine(new Vector2(leftPos.x, topPos.y), new Vector2(leftPos.x, bottomPos.y));
            //Draw line between right hand points
            Gizmos.DrawLine(new Vector2(rightPos.x, topPos.y), new Vector2(rightPos.x, bottomPos.y));
        }

        //Draw Handle gizmos to adjust the size of the camera limit
    }
}
