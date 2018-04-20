using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceButton : MonoBehaviour {

    public int buttonIndex;
    public GameDiceObject diceObjectData;
    public int numberOfDice = 1;
    public Text diceTypeText;
    public InputField numberOfDiceField;

    void SpawnDice(int idx)
    {
        {
            GameObject newDice = Instantiate(Resources.Load("Prefabs/GameDicePrefab", typeof(GameObject)) as GameObject, GameObject.FindGameObjectWithTag("Respawn").transform.position, Random.rotation);
            newDice.GetComponent<GameDiceBase>().diceData = diceObjectData;
            newDice.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * 1000.0f, ForceMode.VelocityChange);
            newDice.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.0f, 1.0f), -1.0f, Random.Range(-1.0f, 1.0f)).normalized * 5.0f, ForceMode.VelocityChange);


            GameObject manager = GameObject.FindGameObjectWithTag("GameController");

            if (manager != null)
            {
                manager.GetComponent<Manager>().cameraTarget = newDice;
            }
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
