using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nyt Leaderboard" ,menuName = "Scriptable Object/Leaderboard")]
public class Leaderboard : ScriptableObject
{
    public List<entry> leaderboard;

    [System.Serializable]
    public class entry
    {
        public string name;
        public int score;
        public entry(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
