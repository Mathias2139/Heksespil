using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    public GameStats stats;
    public Leaderboard leaderboard;
    public GameObject leaderboardLayoutGroup;
    public UnityEvent[] events;
    [Range(0,5)]
    public int[] timeBetweenEvents;
    public DialogueManager scoreDisplay;
    private List<GameObject> leaderboardobjects;
    public Font leaderboardFont;
    public string menuScene;
    private bool StatsShown;
    private int endscreenState = 0;
    public GameObject backbutton;
    private void Start()
    {
        leaderboardobjects = new List<GameObject>();
        
        scoreDisplay.dialogue[0] = "<sp:3>" + stats.completedMinigames.ToString();
        DisplayLeaderboard();
        AdvanceEndscreen();
    }

    public void AdvanceEndscreen()
    {
        switch (endscreenState)
        {
            case 0:
                //Play result dialogue
                endscreenState++;
                break;
            case 1:
                ShowStats();
                endscreenState++;
                break;
            case 2:
                //Show Bargraph
                backbutton.SetActive(true);
                endscreenState++;
                break;
            case 3:
                break;
        }
    }
    public void ShowStats()
    {
        if (!StatsShown)
        {
            StatsShown = true;
            StartCoroutine(InvokeEvents());
        }
        
    }

    public void DisplayLeaderboard()
    {
        foreach (GameObject obj in leaderboardobjects)
        {
            Destroy(obj);
        }
        for (int i = 0; i < Mathf.Min(leaderboard.leaderboard.Count, 7); i++)
        {
            GameObject entry = new GameObject("Entry " + leaderboard.leaderboard[i].name);
            Text entrytext = entry.AddComponent<Text>();
            entrytext.text = leaderboard.leaderboard[i].score.ToString() + " - " + leaderboard.leaderboard[i].name;
            entrytext.font = leaderboardFont;
            entrytext.alignment = TextAnchor.MiddleCenter;
            entrytext.fontSize = 32;
            entrytext.resizeTextForBestFit = true;
            entrytext.color = Color.black;
            entry.transform.SetParent(leaderboardLayoutGroup.transform);
            leaderboardobjects.Add(entry);
        }
       
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    IEnumerator InvokeEvents()
    {
        while (true)
        {
            for (int i = 0; i < events.Length; i++)
            {
                events[i].Invoke();
                Debug.Log("Invoked Event");
               
                yield return new WaitForSeconds(timeBetweenEvents[i]);

            }
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
