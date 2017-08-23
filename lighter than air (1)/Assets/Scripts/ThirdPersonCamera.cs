using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    [SerializeField]
    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    public float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    public float sensitivityX = 4.0f;
    public float sensitivityY = 4.0f;

    public float smoothSpeed = 0.125f;

    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (distance < 5.0f)
            {
                distance += 0.2f;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (distance > 1.0f)
            {
                distance -= 0.2f;
            }
        }
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

    }

    private void FixedUpdate()
    {
        smoothFollow();
    }
    public void smoothFollow()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = lookAt.position + rotation * dir;
        
        Vector3 smoothedPosition = Vector3.Slerp(camTransform.position, desiredPosition, smoothSpeed);

        camTransform.position = smoothedPosition;
        camTransform.LookAt(lookAt.position,lookAt.up);
    }

    public void switchFollower()
    {
        if (lookAt.tag == "Player")
        {
            lookAt = GameObject.FindGameObjectWithTag("Pet").transform;
            distance = 2.0f;

        }
        else
        {
            lookAt = GameObject.FindGameObjectWithTag("Player").transform;
            distance = 5.0f;
        }
    }
}
