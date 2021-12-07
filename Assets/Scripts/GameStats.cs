using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nye Stats" ,menuName = "Scriptable Object/Stats")]
public class GameStats : ScriptableObject
{
    public int completedMinigames;
    public int minigamesPlayed;
    public List<GameTracker> tracker;

    [System.Serializable]
    public class GameTracker
    {
        public string name;
        public int timesWon;
        public int timesPlayed;
        public Sprite sprite;
        public GameTracker(string name, int timesWon, int timesPlayed, Sprite sprite)
        {
            this.name = name;
            this.timesWon = timesWon;
            this.timesPlayed = timesPlayed;
            this.sprite = sprite;
        }
    }
}
