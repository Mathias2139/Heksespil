using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Leaderboard : ScriptableObject
{
    public List<entry> leaderboard;
    [System.Serializable]
    public class entry
    {
        public string name;
        public int score;
        public List<GameStats.GameTracker> stats;

        public entry(string name, int score, List<GameStats.GameTracker> stats)
        {
            this.name = name;
            this.score = score;
            this.stats = stats;
        }
    }
}
