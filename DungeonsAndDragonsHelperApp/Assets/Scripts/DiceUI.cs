using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceUI : MonoBehaviour {

    public GameObject buttonContainer;

    public GameDiceObject[] diceObjectDatas;
    public GameObject diceButtonPrefab;
    public List<GameObject> buttons;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {

        if(buttonContainer != null)
        {
            for(int i = 0; i < diceObjectDatas.Length; i++)
            {
                if(diceButtonPrefab != null)
                {
                    buttons.Add(Instantiate(diceButtonPrefab, buttonContainer.transform, false));
                    buttons[i].GetComponent<DiceButton>().buttonIndex = i;
                    buttons[i].GetComponent<DiceButton>().diceObjectData = diceObjectDatas[i];
                    buttons[i].GetComponent<DiceButton>().diceTypeText.text = diceObjectDatas[i].label;
                }
            }
        }		
	}

    // Update is called once per frame
    void Update()
    {

    }
}
