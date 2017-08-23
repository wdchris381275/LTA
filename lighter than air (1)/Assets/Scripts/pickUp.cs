using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pickUp : MonoBehaviour
{

    public Transform hands;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<SampleFollow>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            this.transform.position = hands.position;
            this.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<SampleFollow>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
            
        }
    }
}
