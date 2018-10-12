using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraFollow))]
public class CameraLimitSetup : MonoBehaviour {

    [SerializeField]
    [Range(0, 100)]
    private float minX, maxX, minY, maxY;

    private Vector2 topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner;

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

        }
    }
}
