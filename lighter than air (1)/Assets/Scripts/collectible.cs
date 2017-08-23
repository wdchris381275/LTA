using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour {

	
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.name);
        if (col.gameObject.tag == "Pet")
        {
            
            Destroy(this.gameObject);
        }
    }
}
