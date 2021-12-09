        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barchart_Controller : MonoBehaviour
{
    public GameObject barPrefab;
    public GameStats stats;
    public RectTransform textTemplate;
    public float graphHeight;
    public GameObject parent;

    private void Start()
    {
        SpawnBarchart();
    }
    public void SpawnBarchart()
    {
        //Find higest score for single minigame
        int bestScore = 0;
        for (int i = 0; i < stats.tracker.Count; i++)
        {
            if(stats.tracker[i].timesPlayed > bestScore)
            {
                bestScore = stats.tracker[i].timesPlayed;
            }
           
        }
        //Spawn bars
        for (int i = 0; i < stats.tracker.Count; i++)
        {
            GameObject bar = Instantiate(barPrefab, this.gameObject.transform);
            bar.GetComponent<Barchart_Bar>().playedValue = stats.tracker[i].timesPlayed / (bestScore+0.0001f);
            bar.GetComponent<Barchart_Bar>().wonValue = stats.tracker[i].timesWon / (stats.tracker[i].timesPlayed + 0.0001f);
            bar.GetComponent<Barchart_Bar>().sprite = stats.tracker[i].sprite;
        }
        if(stats.tracker.Count%2 != 0)
        {
            GameObject bar = Instantiate(barPrefab, this.gameObject.transform);
            bar.GetComponent<Barchart_Bar>().playedValue = 0;
            bar.GetComponent<Barchart_Bar>().wonValue = 0;
            bar.GetComponent<Barchart_Bar>().sprite = null;
            Image[] images = bar.GetComponentsInChildren<Image>();
            foreach (Image image in images)
            {
                image.color = Color.clear;
            }
        }


        int seperatorCount = Mathf.Min(8,bestScore+1);
        for (int i = 0; i < seperatorCount; i++)
        {
            RectTransform labelY = Instantiate(textTemplate);
            labelY.SetParent(parent.transform, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / seperatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt((normalizedValue * bestScore)+0.5f).ToString();
        }

    }
}
