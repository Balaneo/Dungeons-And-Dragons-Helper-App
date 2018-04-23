using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwapper : MonoBehaviour {

    public int currentScreenIndex;
    public List<GameObject> canvasScreens = new List<GameObject>();


	// Use this for initialization
	void Start ()
    {
        SetCurrentScreen(currentScreenIndex);		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetCurrentScreen(int idx)
    {
        for(int i = 0; i < canvasScreens.Count; i++)
        {
            if(i != idx)
            {
                canvasScreens[i].SetActive(false);
            }
            else
            {
                canvasScreens[i].SetActive(true);
            }
        }
    }

    public void SetCurrentScreen(Canvas canvas)
    {
        foreach (GameObject go in canvasScreens)
        {
            if (go != canvas)
            {
                go.SetActive(false);
            }
            else
            {
                go.SetActive(true);
            }
        }
    }
}
