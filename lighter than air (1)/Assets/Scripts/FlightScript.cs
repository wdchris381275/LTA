using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float minSpeed = 1.0f;
    [SerializeField]
    private float maxSpeed = 5.0f;
    [SerializeField]
    private float deceleration = 0.5f;
    [SerializeField]
    private float acceleration = 0.5f;
    
   	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed -= deceleration;
        }
        else
        {
            speed += acceleration * Time.deltaTime; // auto accelerates
        }
        speed -= transform.forward.y * Time.deltaTime * 2.0f;
        if (speed < minSpeed)
        {
            speed = minSpeed;
        }
        else if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        transform.Rotate(Input.GetAxis("Vertical"),0.0f,-Input.GetAxis("Horizontal"));

	}
}
