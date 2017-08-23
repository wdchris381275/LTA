using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicCharacterController : MonoBehaviour {

    public float movingTurnSpeed = 360;
    public float stationaryTurnSpeed = 180;
    private float speed = 3.5f;

    private Animator m_Anim;
    private CharacterController m_Controller;

    private Transform m_Cam;
    private float curSpeedX;
    private float curSpeedZ;



    // Use this for initialization
    void Start ()
    {
        m_Cam = Camera.main.transform;
        m_Anim = GetComponent<Animator>();
        m_Controller = GetComponent<CharacterController>();
		
	}
	
    void FixedUpdate()
    {

    }



	// Update is called once per frame
	void Update () {
        HandleGroundMovement();
	}

    void HandleGroundMovement()
    {
        Vector3 forward = transform.InverseTransformDirection(Vector3.forward);
        curSpeedX = speed * Input.GetAxis("Vertical");
        curSpeedZ = speed * Input.GetAxis("Horizontal");

        if (curSpeedX < 0.0f)
        {
            m_Controller.SimpleMove(forward * -curSpeedX);
        }
        else if (curSpeedX > 0.0f)
        {
            m_Controller.SimpleMove(forward * curSpeedX);
        }

        if(curSpeedZ < 0.0f)
        {
            //Vector3 left = transform.TransformDirection
            m_Controller.SimpleMove(forward * -curSpeedZ);
        }
        else if(curSpeedZ > 0.0f)
        {
            m_Controller.SimpleMove(forward * curSpeedZ);
        }

    }
}
