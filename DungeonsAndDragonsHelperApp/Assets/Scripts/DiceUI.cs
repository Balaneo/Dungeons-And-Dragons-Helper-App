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

        GameObject manager = GameObject.FindGameObjectWithTag("GameController");

        if (manager != null)
        {
            //manager.GetComponent<Manager>().cameraTarget = newDice;
        }

        if (buttonContainer != null)
        {
            for(int i = 0; i < diceObjectDatas.Length; i++)
            {
                if(diceButtonPrefab != null)
                {
                    buttons.Add(Instantiate(diceButtonPrefab, buttonContainer.transform, false));

                    DiceButton localDiceButton = buttons[i].GetComponent<DiceButton>();

                    localDiceButton.buttonIndex = i;
                    localDiceButton.diceObjectData = diceObjectDatas[i];
                    localDiceButton.diceTypeText.text = diceObjectDatas[i].label;
                }
            }
        }		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void RollDice()
    {
        foreach(GameObject g in buttons)
        {
            g.GetComponent<DiceButton>().SpawnDice();
        }
    }

    public void ClearDice()
    {
        foreach(GameObject g in buttons)
        {
            DiceButton cachedDiceButton = g.GetComponent<DiceButton>();

            foreach(GameObject d in cachedDiceButton.diceObjects)
            {
                Destroy(d);
            }

            cachedDiceButton.diceObjects.Clear();            
        }
    }
}
