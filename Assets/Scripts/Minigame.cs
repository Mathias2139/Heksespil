using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MA.Events;

public class Minigame : MonoBehaviour
{
    public string minigameName;
    public string beginText;
    public string tutorialText;
    public int timeToComplete;
    public int timeReward;
    [Range(0,5)]
    public int countdownTime = 3;
    public UnityEvent startGame;
    public BoolEvent gameFinished;
    public FloatEvent GlobalTimeReward;
    public FloatEvent GlobalTime;
    public FloatEvent localTime;
    public StringEvent countdown;
    private Coroutine broadcast;
    public Canvas[] canvi;
    private float localTimer;
    private bool gameStarted;
    private void Awake()
    {
        StartCoroutine(StartSequence(countdownTime));
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = Camera.main;
        }
        localTimer = timeToComplete;
        localTime.Raise(timeToComplete);
    }

    private void Update()
    {
        if (gameStarted)
        {


            localTimer -= Time.deltaTime;
            localTime.Raise(localTimer);

            if (localTimer <= 0)
            {
                EndGame(3);
            }
        }
    }

    private IEnumerator StartSequence(int countdownLenght)
    {
        while (true)
        {
            if (countdownLenght > 0)
            {
                countdown.Raise(countdownLenght.ToString());
                Debug.Log(countdownLenght);
            }
            if (countdownLenght == 0)
            {
                countdown.Raise(beginText);
                
                countdownLenght--;
                yield return new WaitForSeconds(0.5f);
                
            }
            if(countdownLenght < 0)
            {
                countdown.Raise(" ");
                StartGame();
                gameStarted = true;
                StopAllCoroutines();
            }
            countdownLenght--;
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void StartGame()
    {
        startGame.Invoke();
    }
    public void EndGame(int won)
    {
        broadcast = StartCoroutine(BroadcastEndGame(won,0));
        switch (won)
        {
            case 1:
                countdown.Raise("You Won");
                GlobalTimeReward.Raise(timeReward);
                Debug.Log("Added " + timeReward + " to global time");
                break;
            case 2:
                countdown.Raise("You Lost");
                GlobalTimeReward.Raise(-localTimer);
                break;
            case 3:
                countdown.Raise("Time Up");
                break;
            case 4:
                countdown.Raise("Tie");
                GlobalTimeReward.Raise(-localTimer);
                break;
        }
      
        
    }

    public IEnumerator BroadcastEndGame(int won, int loop)
    {
        while (true)
        {
            if(loop == 0)
            {
                loop++;
                yield return new WaitForSeconds(1);
            }
            if(won == 1)
            {
                gameFinished.Raise(true);
            }
            else
            {
                gameFinished.Raise(false);
            }
            
            if(broadcast != null)
            {
                StopCoroutine(broadcast);
            }
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
