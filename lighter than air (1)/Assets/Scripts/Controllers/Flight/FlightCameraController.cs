using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraController : MonoBehaviour
{
    //Public attributes
    public BezierPath flightPath = null;
    public float movementSpeed = 1.0f;
    public float rotationDamping = 2.5f;

    //Private attributes
    private float distanceTravelled = 0.0f;

    //Called on initialization
    void Awake()
    {
        //If the flight path is not valid
        if(flightPath == null)
        {
            //Log warning
            Debug.LogWarning("WARNING: FlightCameraController.cs requires a valid flight path on game start...");
        }
        //Otherwise
        else
        {
            //Initialize camera position
            transform.position = flightPath.GetPositionFromDistance(distanceTravelled);
        }
    }

    //Called at the end of each frame
    void LateUpdate()
    {
        //If the flight path is valid
        if(flightPath != null)
        {
            //Move the camera
            distanceTravelled += movementSpeed * Time.deltaTime;
            transform.position = flightPath.GetPositionFromDistance(distanceTravelled);
            transform.rotation = Quaternion.Slerp(transform.rotation, flightPath.GetRotationFromDistance(distanceTravelled), rotationDamping * Time.deltaTime);
        }
    }
}