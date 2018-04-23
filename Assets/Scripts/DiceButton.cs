using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceButton : MonoBehaviour {

    public int buttonIndex;
    public GameDiceObject diceObjectData;
    public int numberOfDice;
    public Text diceTypeText;
    public InputField numberOfDiceField;

    private void Start()
    {
        if(numberOfDiceField != null)
        {
            SetNumberOfDice("0");
        }        
    }  

    public void SetNumberOfDice(string str)
    {
        int number;

        if (str != "" && int.TryParse(str, out number) != false)
        {
            numberOfDice = Mathf.Abs(number);
            numberOfDiceField.text = numberOfDice.ToString();
        }
    }

    public void IncrementNumberOfDice()
    {
        numberOfDice = Mathf.Max(0, numberOfDice + 1);
        numberOfDiceField.text = numberOfDice.ToString();
    }

    public void DecrementNumberOfDice()
    {
        numberOfDice = Mathf.Max(0, numberOfDice - 1);
        numberOfDiceField.text = numberOfDice.ToString();
    }
}
