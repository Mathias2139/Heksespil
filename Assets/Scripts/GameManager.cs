using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MA.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Range(0,180)]
    public float startTime = 60;
    private float globalTime = 100;
    public GameStats stats;
    public IntEvent inputEvent;
    public GameObject[] minigames;
    public bool runGame;
    public bool banPreviousGame;
    public FloatEvent globalTimer;
    public BoolEvent gameFinished;
    public FloatEvent globalTimeReward;
    public FloatEvent localTime;
    private PlayerControls input;
    private bool[] held;
    public Animator transition;
    public StringEvent countdown;
    private float currentTimeGain = 0;
    private float timeGainResetTimer = 3;
    private GameObject currentMinigame;
    private int previousMinigame;
    private int randomNumber;
    public Animation globalTimerAnimation;
    public GameObject globalTimerAdd;
    private void Start()
    {
        //transition.SetBool("In", true);
        stats.tracker = new List<GameStats.GameTracker>();
        stats.completedMinigames = 0;
        stats.minigamesPlayed = 0;
        input = new PlayerControls();
        held = new bool[9];
        globalTime = startTime;
        if (runGame)
        {
            SpawnNextMinigame();
        }
        
    }
    private void Update()
    {
        globalTime -= Time.deltaTime;
        
        if(globalTime <= 0)
        {
            countdown.Raise("Time Up!");
            currentMinigame.GetComponent<Minigame>().startGame.Invoke();
            ChangeScene();
        }
        if(currentTimeGain != 0)
        {
            
            timeGainResetTimer -= Time.deltaTime;
            if(timeGainResetTimer <= 0)
            {
                //Play Add Time Animation
                globalTimerAnimation.Play("ApplyTime");
            }
        }
        else
        {
            globalTimerAdd.SetActive(false);
        }

        globalTimer.Raise(Mathf.Max(globalTime-currentTimeGain,0));
        if(globalTime <= currentTimeGain)
        {
            globalTime = currentTimeGain;
        }
    }

    public void ResetTimeGain()
    {
        currentTimeGain = 0;
        timeGainResetTimer = 3;
    }

    private void ChangeScene()
    {
        
        Debug.Log("Swithing SCenes");
        transition.SetBool("In", true);
        //SceneManager.LoadScene(endscene);
    }

    public void MinigameCompleted(bool won)
    {
        //Add score and time
        if (won)
        {
            stats.completedMinigames++;
        }
        stats.minigamesPlayed++;
        //Cover Screen while switching game

        if (runGame)
        {
            //Remove Previous Minigame
            RemoveMinigame();
            //Spawn Next Minigame
            SpawnNextMinigame();
        }
       
        //uncover screen
    }
   
    private void SpawnNextMinigame()
    {
        //Spawn Prefab
        int randomNumber = GenerateRandomNumber();
        if (banPreviousGame)
        {
            if (randomNumber == previousMinigame)
            {
                if (randomNumber == minigames.Length - 1)
                {
                    randomNumber = 0;   
                }
                else
                {
                    randomNumber++;
                }

            }
        }
        currentMinigame = Instantiate(minigames[randomNumber]);
        previousMinigame = randomNumber;
        Minigame minigame = currentMinigame.GetComponent<Minigame>();
        minigame.globalTime = globalTimer;
        minigame.localTime = localTime;
        minigame.globalTimeReward = globalTimeReward;
        


        //Initialize Controls, link game to manager
        //Start Game
    }

    private int GenerateRandomNumber()
    {
        return Random.Range(0, minigames.Length);
    }

    private void RemoveMinigame()
    {
        Destroy(currentMinigame);
    }

    public void AddTime(float time)
    {
        globalTimerAdd.SetActive(true);
        globalTime += (time);
        currentTimeGain += time;
        //Play TimeGainIncrease Animation
        if (currentTimeGain > 0)
        {
            globalTimerAdd.GetComponent<Text>().text = "+" + Mathf.RoundToInt(currentTimeGain).ToString();
        }
        else
        {
            globalTimerAdd.GetComponent<Text>().text = Mathf.RoundToInt(currentTimeGain).ToString();
        }
        
        globalTimerAnimation.Play("TimeGainIncrease");
        timeGainResetTimer = 3;
    }
    private void LateUpdate()
    {
      
    }

    #region InputSystem

    #region Inputs
    public void One(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(1);
        }

    }
    public void Two(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(2);
        }

    }
    public void Three(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(3);
        }

    }
    public void Four(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(4);
        }

    }
    public void Five(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(5);
        }

    }
    public void Six(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(6);
        }

    }
    public void Seven(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(7);
        }

    }
    public void Eight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(8);
        }

    }
    public void Nine(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputEvent.Raise(9);
        }
        
    }

    #endregion

    public void RaiseInput(int number)
    {
        inputEvent.Raise(number);
    }

    private void OnEnable()
    {
        input.Enable(); 
    }

    private void OnDisable()
    {
        input.Disable();
    }
    #endregion
}
