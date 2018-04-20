using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDiceBase : MonoBehaviour {

    public GameDiceObject diceData;

	// Use this for initialization
	void Start ()
    {

        if(diceData != null)
        {
            GetComponent<MeshFilter>().mesh = diceData.mesh;
            GetComponent<MeshCollider>().sharedMesh = diceData.meshCollider;
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
