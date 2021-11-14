using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class TacTacToe : MonoBehaviour
{
    private bool allowInput = false;
    private Minigame manager;
    public Sprite[] symbols;
    public Square[] board;

    [System.Serializable]
    public class Square
    {
        public SpriteRenderer squareRenderer;
        public bool isEmpty = true;
        public Square(SpriteRenderer squareRenderer, bool isEmpty)
        {

            this.squareRenderer = squareRenderer;
            this.isEmpty = isEmpty;
        }
    }
    private void Awake()
    {
        manager = GetComponent<Minigame>();
    }
    public void StartGame()
    {
        allowInput = true;
    }
   
    public void Input(int targetSquare)
    {
        if (allowInput)
        {
            Debug.Log("Player pressed: " + targetSquare);
            if (board[targetSquare - 1].isEmpty)
            {
                board[targetSquare - 1].squareRenderer.sprite = symbols[0];
                board[targetSquare - 1].isEmpty = false;
            }
            else
            {
                Debug.Log("Square Already Occupied");
            }
        }
        
    }

    private void Mistake()
    {

    }
    private void GameLost()
    {
        manager.EndGame(false);
    }
    private void GameWon()
    {
        manager.EndGame(true);
    }
}
