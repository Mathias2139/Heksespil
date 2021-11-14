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

    private void Awake()
    {
        StartCoroutine(StartSequence(countdownTime));
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
                yield return new WaitForSeconds(0.7f);
                
            }
            if(countdownLenght < 0)
            {
                countdown.Raise(" ");
                StartGame();
                StopAllCoroutines();
            }
            countdownLenght--;
            yield return new WaitForSeconds(1);
        }
    }
    public void StartGame()
    {
        startGame.Invoke();
    }
    public void EndGame(bool won)
    {
        gameFinished.Raise(won);
    }
}
