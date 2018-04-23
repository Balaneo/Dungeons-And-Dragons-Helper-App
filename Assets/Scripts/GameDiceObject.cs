using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dice", menuName = "Custom/GameDice")]
public class GameDiceObject : ScriptableObject{

    public string label;
    public int[] sides;
    public Mesh mesh;
    public Mesh meshCollider;
}
