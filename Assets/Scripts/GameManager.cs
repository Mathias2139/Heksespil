using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MA.Events;

public class GameManager : MonoBehaviour
{
    [Range(0,180)]
    public float startTime = 60;
    private float time = 100;
    private int globalScore = 0;
    public IntEvent inputEvent;
    public GameObject[] minigames;

    private PlayerControls input;
    private bool[] held;

    private GameObject currentMinigame;
    

    private void Start()
    {
        input = new PlayerControls();
        held = new bool[9];
        time = startTime;
        //SpawnNextMinigame();
    }
    public void MinigameCompleted(bool won)
    {
        //Add score and time
        if (won)
        {
            globalScore++;
        }
        //Cover Screen while switching game
        //Remove Previous Minigame
        RemoveMinigame();
        //Spawn Next Minigame
        SpawnNextMinigame();
        //uncover screen
    }
   
    private void SpawnNextMinigame()
    {
        //Spawn Prefab

        currentMinigame = Instantiate(minigames[Random.Range(0, minigames.Length)]);

        //Initialize Controls, link game to manager
        //Start Game
    }

    private void RemoveMinigame()
    {
        Destroy(currentMinigame);
    }

    private void LateUpdate()
    {
        time -= Time.deltaTime;
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
