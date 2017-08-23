using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleFollow : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public float speed = 0f;
    Animator animator = null;


	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(target.position);
        speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude;
        animator.SetFloat("Speed", speed);
	}
}
