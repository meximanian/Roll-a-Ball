using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletprop : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            PlayerMovement.count = PlayerMovement.count + 1;
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
