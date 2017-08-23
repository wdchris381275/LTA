using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VentActivation : MonoBehaviour {
    // made by christopher loney

    public GameObject activation_prompt;
    public GameObject bam_prompt;
    public KeyCode activationkey;
    private bool atdoor = false;
    
    void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Player")
        {

            activation_prompt.SetActive(true);
            bam_prompt.SetActive(false);
            atdoor = true;
           
        }
    
    }
    void Update()
    {
        if (Input.GetKey(activationkey))
        {
            activation_prompt.SetActive(false);
            GameObject.Destroy(gameObject);
        }
    }
	
}
