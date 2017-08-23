using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PetController : MonoBehaviour
{
    [SerializeField]
    public float m_MovingTurnSpeed = 360;
    [SerializeField]
    public float m_StationaryTurnSpeed = 180;
    private Animator m_Anim;
    public float speed = 3.5f;
      
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    float m_TurnAmount;
    float m_ForwardAmount;
    bool m_isGrounded;
    float m_groundDistance = 0.2f;
    Vector3 groundNormal = new Vector3(0,1,0);
    private float curSpeedX;
    private float curSpeedZ;

    void Start()
    {
        m_Cam = Camera.main.transform;
        m_Anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        // This block of code finds where the camera is facing, calculates the turning distance and turns if the player chooses to move to that direction
        if (m_Move.magnitude > 1.0f)
        {
            m_Move.Normalize();
        }
        GroundCheckStatus();
        m_Move = transform.InverseTransformDirection(m_Move);
        m_Move = Vector3.ProjectOnPlane(m_Move, groundNormal);
        m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
        m_ForwardAmount = m_Move.z;
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        HandleGroundMovement();
    }
    void HandleGroundMovement()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        // Moves the player forward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        curSpeedX = speed * Input.GetAxis("Vertical");
        curSpeedZ = speed * Input.GetAxis("Horizontal");
        

        if (curSpeedX < 0.0f)
        {
            controller.SimpleMove(forward * -curSpeedX);
            m_Anim.SetFloat("Speed", controller.velocity.magnitude);
        }
        else if(curSpeedX > 0.0f)
        { 
            controller.SimpleMove(forward * curSpeedX);
            m_Anim.SetFloat("Speed", controller.velocity.magnitude);
           
        }


        if(curSpeedZ < 0.0f)
        {
            controller.SimpleMove(forward * -curSpeedZ);
            m_Anim.SetFloat("Speed", controller.velocity.magnitude);
        }
        else if(curSpeedZ > 0.0f)
        {
            controller.SimpleMove(forward * curSpeedZ);
            m_Anim.SetFloat("Speed", controller.velocity.magnitude);
        }

        m_Anim.SetFloat("Speed", controller.velocity.magnitude > 0.1f ? controller.velocity.magnitude : 0.0f);
    }

    void GroundCheckStatus()
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position + (Vector3.forward * 0.1f), transform.position + (Vector3.forward * 0.1f) + (Vector3.down * m_groundDistance), Color.blue);

        if (Physics.Raycast(transform.position + (Vector3.forward * 0.1f), Vector3.down, out hit, m_groundDistance))
        {
            groundNormal = hit.normal;
            m_isGrounded = true;
            Debug.Log(hit.collider.name);

        }


    }
}



