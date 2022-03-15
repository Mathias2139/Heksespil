using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmitHighscore : MonoBehaviour
{
    public GameStats stats;
    public TMP_Text text;
    public Leaderboard leaderboard;
    private bool alreadySubmitted;
    public EndScreenManager manager;
    public DialogueManager newScoreManager;
    public GameObject newScoreText;
   public void Submit()
    {
        Debug.Log("Pressed");
        Debug.Log(Application.persistentDataPath + "/Leaderboard.json");
        if (!alreadySubmitted)
        {
            
            AddToLeaderboard();
            
            
        }
        else
        {

        }
        
    }

    private void AddToLeaderboard()
    {
        for (int i = 0; i < leaderboard.leaderboard.Count; i++)
        {
            if(stats.completedMinigames > leaderboard.leaderboard[i].score)
            {
                leaderboard.leaderboard.Insert(i, new Leaderboard.entry(text.text, stats.completedMinigames, stats.tracker));
                newScoreText.transform.SetSiblingIndex(i);
                newScoreText.SetActive(true);
                newScoreManager.dialogue[0] = "<sp:10><anim:wave>"+stats.completedMinigames.ToString() + " - " + text.text + "</anim>";
                newScoreManager.AutoPlay();
                string potion = JsonUtility.ToJson(leaderboard);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/Leaderboard.json", potion);
                alreadySubmitted = true;

                //manager.DisplayLeaderboard();
                return;
            }
            
        }
        if(alreadySubmitted != true)
        {
            
                leaderboard.leaderboard.Insert(leaderboard.leaderboard.Count, new Leaderboard.entry(text.text, stats.completedMinigames, stats.tracker));
                newScoreText.transform.SetSiblingIndex(leaderboard.leaderboard.Count);
                newScoreText.SetActive(true);
                newScoreManager.dialogue[0] = "<sp:10><anim:wave>" + stats.completedMinigames.ToString() + " - " + text.text + "</anim>";
                newScoreManager.AutoPlay();
                string potion = JsonUtility.ToJson(leaderboard);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/Leaderboard.json", potion);
                alreadySubmitted = true;
            
        }
        
    }
}
