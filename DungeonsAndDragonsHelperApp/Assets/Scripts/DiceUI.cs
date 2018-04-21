using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceUI : MonoBehaviour {

    public GameObject buttonContainer;
    public GameObject diceSpawner;
    public GameDiceObject[] diceObjectDatas;
    public GameObject diceButtonPrefab;
    public List<GameObject> buttons;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {

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
        List<GameDiceObject> diceTypes = new List<GameDiceObject>();
        List<int> diceAmounts = new List<int>();

        foreach(GameObject g in buttons)
        {
            diceTypes.Add(g.GetComponent<DiceButton>().diceObjectData);
            diceAmounts.Add(g.GetComponent<DiceButton>().numberOfDice);
            g.SetActive(false);
        }

        diceSpawner.GetComponent<DiceSpawner>().SpawnDice(diceTypes, diceAmounts);
    }

    public void ClearDice()
    {
        diceSpawner.GetComponent<DiceSpawner>().DestroyAllDice();
        foreach (GameObject g in buttons)
        {
            g.SetActive(true);
        }
    }
}
