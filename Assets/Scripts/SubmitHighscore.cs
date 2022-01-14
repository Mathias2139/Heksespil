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
    public AudioSource click;
   public void Submit()
    {
        if (!alreadySubmitted)
        {
            click.Play();
            AddToLeaderboard();
            alreadySubmitted = true;
            
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
                leaderboard.leaderboard.Insert(i, new Leaderboard.entry(text.text, stats.completedMinigames));
                newScoreText.transform.SetSiblingIndex(i);
                newScoreText.SetActive(true);
                newScoreManager.dialogue[0] = "<sp:10><anim:wave>"+stats.completedMinigames.ToString() + " - " + text.text + "</anim>";
                newScoreManager.AutoPlay();
                string potion = JsonUtility.ToJson(leaderboard);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/Leaderboard.json", potion);
                Debug.Log(Application.persistentDataPath + "/Leaderboard.json");

                //manager.DisplayLeaderboard();
                return;
            }
        }
        
    }
}
