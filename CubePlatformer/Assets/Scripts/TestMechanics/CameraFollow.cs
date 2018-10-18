using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Target we follow
    [SerializeField]
    private Transform targetPlayer;

    //Zero out the velocity
    private Vector3 cameraVelocity = Vector3.zero;

    //Time to follow target
    [SerializeField]
    private float smoothTime = 0.15f;

    private float yMinValue = 0, yMaxValue = 0, xMinValue = 0, xMaxValue = 0;

    private bool playerActive = false;

    //Minimum X and Y values - these are the min values for the limit
    private float minimumX = 9, minimumY = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetupPlayer(GameObject player)
    {
        targetPlayer = player.transform;

        playerActive = true;
    }

    private void LateUpdate()
    {
        if (playerActive)
        {
            //Update the target position
            Vector3 targetPos = targetPlayer.position;

            targetPos.x = Mathf.Clamp(targetPlayer.position.x, xMinValue, xMaxValue);
            targetPos.y = Mathf.Clamp(targetPlayer.position.y, yMinValue, yMaxValue);

            //Align the target Z position with the cameras
            targetPos.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref cameraVelocity, smoothTime);
        }
    }

    public void LimitSetup(float minX, float maxX, float minY, float maxY)
    {
        if (minimumX > minX) { xMinValue = minimumX; } else { xMinValue = -minX; }
        if (minimumX > maxX) { xMaxValue = minimumX; } else { xMaxValue = maxX; }
        if (minimumY > minY) { yMinValue = minimumY; } else { yMinValue = -minY; }
        if (minimumY > maxY) { yMaxValue = minimumY; } else { yMaxValue = maxY; }

        float vertExtent = GetComponent<Camera>().orthographicSize;
        float horizExtent = (vertExtent * Screen.width / Screen.height);

        xMinValue += horizExtent;
        xMaxValue -= horizExtent;

        yMinValue += vertExtent;
        yMaxValue -= vertExtent;
    }
}
