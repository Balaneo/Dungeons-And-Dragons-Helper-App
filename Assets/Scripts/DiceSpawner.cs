using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour {

    [System.Serializable]
    public struct DiceToSpawn
    {
        public GameDiceObject diceType;
        public int diceAmount;
    }

    public int diceRemaining;

    public GameObject spawnObject;
    public Text diceSpawnedCounter;
    public Text diceRemainingCounter;
    public List<GameObject> diceObjects;

    // Use this for initialization
    void Start ()
    {
        spawnObject = GameObject.FindGameObjectWithTag("Respawn");
        diceSpawnedCounter.text = "0";
        diceRemainingCounter.text = "0";
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void SpawnDice(List<GameDiceObject> diceTypes, List<int> diceAmounts)
    {
        List<DiceToSpawn> diceToSpawn = new List<DiceToSpawn>();

        for(int i = 0; i < diceTypes.Count; i++)
        {
            DiceToSpawn newDiceToSpawnEntry;

            newDiceToSpawnEntry.diceType = diceTypes[i];
            newDiceToSpawnEntry.diceAmount = diceAmounts[i];

            diceRemaining += diceAmounts[i];

            diceToSpawn.Add(newDiceToSpawnEntry);
        }

        StartCoroutine(SpawnDiceCoroutine(diceToSpawn));
    }
    
    IEnumerator SpawnDiceCoroutine(List<DiceToSpawn> retrievedDice)
    {
        int i = 0;
        Vector3 spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        while (i < retrievedDice.Count)
        {
            int j = 0;

            while (j < retrievedDice[i].diceAmount)
            {
                if (spawnObject.GetComponent<SpawnPointBase>().GetSpawnEmpty(10.0f) == true)
                {
                    GameObject newDice = Instantiate(Resources.Load("Prefabs/GameDicePrefab", typeof(GameObject)) as GameObject, spawnObject.transform.position, Random.rotation);
                    newDice.GetComponent<GameDiceBase>().diceData = retrievedDice[i].diceType;
                    newDice.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * 1000.0f, ForceMode.VelocityChange);
                    newDice.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.0f, 1.0f), -1.0f, Random.Range(-1.0f, 1.0f)).normalized * 5.0f, ForceMode.VelocityChange);

                    diceObjects.Add(newDice);
                    diceSpawnedCounter.text = diceObjects.Count.ToString();
                    diceRemainingCounter.text = (diceRemaining - diceObjects.Count).ToString();

                    j++;

                    print("Spawned Dice");
                }

                yield return null;
            }

            i++;
            yield return null;
        }

        print("Coroutine Stopped");
        print("Spawning done");
    }

    public void DestroyAllDice()
    {
        foreach (GameObject g in diceObjects)
        {
            Destroy(g);
        }

        diceObjects.Clear();
        diceRemaining = 0;
        diceSpawnedCounter.text = "0";
        diceRemainingCounter.text = "0";
    }
}
