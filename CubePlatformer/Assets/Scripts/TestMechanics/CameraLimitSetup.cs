using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CameraFollow))]
public class CameraLimitSetup : MonoBehaviour {

    [SerializeField]
    [Range(9, 100)]
    private float minX, maxX;

    [SerializeField]
    [Range(5, 100)]
    private float minY, maxY;

    private Vector2 centerPos = Vector2.zero;
    private Vector2 topPos, leftPos, rightPos, bottomPos;

    private CameraFollow followScript;

    private Vector2 updatedCenterPos;

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
#if UNITY_EDITOR
        //If the application is not playing
        if (!Application.isPlaying)
        {
            centerPos = this.gameObject.transform.position;

            //Adjust the values of Min/Max so there within 0.5
            minX = Mathf.Floor(minX * 2) / 2;
            maxX = Mathf.Floor(maxX * 2) / 2;
            minY = Mathf.Floor(minY * 2) / 2;
            maxY = Mathf.Floor(maxY * 2) / 2;

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

            //Update the updatedCenterPosition
            Vector3 horizPos = (leftPos + rightPos) / 2f;
            Vector3 vertPos = (topPos + bottomPos) / 2f;
            Vector3 updatedNewPos = new Vector3(horizPos.x, vertPos.y, 0);

            //Draw cube to help show camera area
            Gizmos.color = new Color(0, 0, 20, 0.1f);
            Gizmos.DrawCube(updatedNewPos,
                new Vector3(Vector2.Distance(leftPos, rightPos), Vector2.Distance(topPos, bottomPos), 1));

        }
#endif
    }

}

