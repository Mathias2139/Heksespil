using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nye Stats" ,menuName = "Scriptable Object/Stats")]
public class GameStats : ScriptableObject
{
    public int completedMinigames;
    public int minigamesPlayed;
}
