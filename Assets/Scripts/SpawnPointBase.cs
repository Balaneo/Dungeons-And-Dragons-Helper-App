using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool GetSpawnEmpty(float radius)
    {
        RaycastHit hit;
        print(!Physics.SphereCast(transform.position, radius, Vector3.zero, out hit));
        return !Physics.SphereCast(transform.position, radius, Vector3.zero, out hit);
    }
}
