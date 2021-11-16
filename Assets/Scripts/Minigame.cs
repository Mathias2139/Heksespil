using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MA.Events;

public class Minigame : MonoBehaviour
{
    public string minigameName;
    [Range(0,5)]
    public int countdownTime = 3;
    public UnityEvent startGame;
    public BoolEvent gameFinished;
    public StringEvent countdown;
    private Coroutine broadcast;
    public Canvas[] canvi;
    private void Awake()
    {
        StartCoroutine(StartSequence(countdownTime));
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = Camera.main;
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
                countdown.Raise("Begin");
                countdownLenght--;
                yield return new WaitForSeconds(0.5f);
                
            }
            if(countdownLenght < 0)
            {
                countdown.Raise(" ");
                StartGame();
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
    public void EndGame(bool won)
    {
        broadcast = StartCoroutine(BroadcastEndGame(won,0));
        if (won)
        {
            countdown.Raise("You Won");
        }
        else
        {
            countdown.Raise("You Lost");
        }
        
    }

    public IEnumerator BroadcastEndGame(bool won, int loop)
    {
        while (true)
        {
            if(loop == 0)
            {
                loop++;
                yield return new WaitForSeconds(1);
            }
            gameFinished.Raise(won);
            if(broadcast != null)
            {
                StopCoroutine(broadcast);
            }
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
