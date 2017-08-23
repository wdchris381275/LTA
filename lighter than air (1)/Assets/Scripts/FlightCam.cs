using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCam : MonoBehaviour {

     private Camera cam = null;
    [SerializeField]
    private float smoothness = 0.875f;

    [SerializeField]
    private float distance = 5.0f;
    [SerializeField]
    private float height = 0.5f;
    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveCamTo = transform.position - transform.forward * distance + Vector3.up * height;
        cam.transform.position = cam.transform.position * smoothness + moveCamTo * (1.0f - smoothness);
        cam.transform.LookAt(transform.position + transform.forward * 30.0f);

    }
}
