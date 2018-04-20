using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Camera playerCamera;
    public GameObject cameraTarget;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        TrackTarget(cameraTarget);		
	}

    void TrackTarget(GameObject target)
    {
        if(target != null)
        {
            playerCamera.transform.LookAt(target.transform);
        }
    }
}
