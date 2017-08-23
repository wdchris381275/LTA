using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class characterSwitcher : MonoBehaviour {

    public ThirdPersonCamera cam;
    public GameObject player;
    public GameObject pet;


	// Use this for initialization
	void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
        pet = GameObject.FindGameObjectWithTag("Pet");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(cam != null)
            {
                if(cam.lookAt.gameObject == player)
                {
                    player.GetComponent<ThirdPersonUserControl>().enabled = false;
                    player.GetComponent<ThirdPersonCharacter>().enabled = false;
                    player.GetComponent<Animator>().enabled = false;
                    pet.GetComponent<PetController>().enabled = true;
                    pet.GetComponent<NavMeshAgent>().enabled = false;
                    pet.GetComponent<SampleFollow>().enabled = false;
                    cam.switchFollower();
                    Debug.Log("Switched to Pet");
                }
                else
                {
                    player.GetComponent<ThirdPersonUserControl>().enabled = true;
                    player.GetComponent<ThirdPersonCharacter>().enabled = true;
                    player.GetComponent<Animator>().enabled = true;
                    pet.GetComponent<PetController>().enabled = false;
                    pet.GetComponent<NavMeshAgent>().enabled = true;
                    pet.GetComponent<SampleFollow>().enabled = true;
                    cam.switchFollower();
                    Debug.Log("Switched to Player");

                }
            }
            else
            {
                Debug.Log("Camera component not found");
            }
        }
		
	}
}
