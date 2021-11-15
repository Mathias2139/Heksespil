using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;
using System;

public class TacTacToe : MonoBehaviour
{
    private bool allowInput = false;
    private Minigame manager;
    public Sprite[] symbols;
    public Square[] board;

    private List<int> xMoves;
    private List<int> oMoves;


    [System.Serializable]
    public class Square
    {
        public SpriteRenderer squareRenderer;
        public bool isEmpty = true;
        public int symbol = 2;
        public Square(SpriteRenderer squareRenderer, bool isEmpty, int symbol)
        {
            this.squareRenderer = squareRenderer;
            this.isEmpty = isEmpty;
            this.symbol = symbol;
        }
    }
    private void Awake()
    {
        manager = GetComponent<Minigame>();
        xMoves = new List<int>();
        oMoves = new List<int>();
    }
    public void StartGame()
    {
        allowInput = true;
    }
   
    public void Input(int targetSquare)
    {
        if (allowInput)
        {
            int targetRow = 1;
            switch (targetSquare)
            {
                case (1):
                    targetRow = 3;
                    break;
                case (2):
                    targetRow = 3;
                    break;
                case (3):
                    targetRow = 3;
                    break;

                case (4):
                    targetRow = 2;
                    break;
                case (5):
                    targetRow = 2;
                    break;
                case (6):
                    targetRow = 2;
                    break;

                case (7):
                    targetRow = 1;
                    break;
                case (8):
                    targetRow = 1;
                    break;
                case (9):
                    targetRow = 1;
                    break;
            }
            int targetColumn = targetSquare % 3;
            if (targetColumn == 0)
            {
                targetColumn = 3;
            }

            Debug.Log("Player pressed: " + targetRow + ", " + targetColumn);

            //Player Move
            if (board[targetSquare - 1].isEmpty)
            {
                board[targetSquare - 1].squareRenderer.sprite = symbols[0];
                board[targetSquare - 1].isEmpty = false;
                board[targetSquare - 1].symbol = 1;
                xMoves.Add(targetSquare - 1);
                if (xMoves.Count > 3)
                {
                    board[xMoves[0]].squareRenderer.sprite = null;
                    board[xMoves[0]].isEmpty = true;
                    board[xMoves[0]].symbol = 2;
                    xMoves.RemoveAt(0);
                }

                //AI Move
                List<int> emptySpots = new List<int>();
                FindEmptySpot(emptySpots);
                if (emptySpots.Count != 0)
                {
                    System.Random random = new System.Random();
                    int index = random.Next(emptySpots.Count);

                    board[emptySpots[index]].squareRenderer.sprite = symbols[1];
                    board[emptySpots[index]].isEmpty = false;
                    board[emptySpots[index]].symbol = 0;
                    oMoves.Add(emptySpots[index]);
                    if (oMoves.Count > 3)
                    {
                        board[oMoves[0]].squareRenderer.sprite = null;
                        board[oMoves[0]].isEmpty = true;
                        board[oMoves[0]].symbol = 2;
                        oMoves.RemoveAt(0);
                    }
                }
            }
            else
            {
                Debug.Log("Square Already Occupied");
            }

        }
        if(xMoves.Count == 3)
        {
            CheckForWinner();
        }
        

    }

    private void FindEmptySpot(List<int> spots)
    {
        
            
        for (int i = 0; i < 9; i++)
        {
            if (board[i].isEmpty)
            {
                spots.Add(i);
            }
        }
    }

    private void CheckForWinner()
    {
        //Check Columns
        if(board[6].symbol == board[3].symbol && board[6].symbol == board[0].symbol)
        {
            if(board[6].symbol == 1)
            {
                GameWon();
            }
            else if (board[6].symbol == 0)
            {
                GameLost();
            }
            return;
            
        }
        if (board[7].symbol == board[4].symbol && board[7].symbol == board[1].symbol)
        {
            if (board[7].symbol == 1)
            {
                GameWon();
            }
            else if(board[7].symbol == 0)
            {
                GameLost();
            }
            return;

        }
        if (board[8].symbol == board[5].symbol && board[8].symbol == board[2].symbol)
        {
            if (board[8].symbol == 1)
            {
                GameWon();
            }
            else if (board[8].symbol == 0)
            {
                GameLost();
            }
            return;

        }

        //Check Rows
        if (board[0].symbol == board[1].symbol && board[0].symbol == board[2].symbol)
        {
            if (board[0].symbol == 1)
            {
                GameWon();
            }
            else if (board[0].symbol == 0)
            {
                GameLost();
            }
            return;

        }
        if (board[3].symbol == board[4].symbol && board[3].symbol == board[5].symbol)
        {
            if (board[3].symbol == 1)
            {
                GameWon();
            }
            else if (board[3].symbol == 0)
            {
                GameLost();
            }
            return;

        }
        if (board[6].symbol == board[7].symbol && board[6].symbol == board[8].symbol)
        {
            if (board[6].symbol == 1)
            {
                GameWon();
            }
            else if (board[6].symbol == 0)
            {
                GameLost();
            }
            return;

        }

        //Check Diagonals
        if (board[0].symbol == board[4].symbol && board[0].symbol == board[8].symbol)
        {
            if (board[0].symbol == 1)
            {
                GameWon();
            }
            else if (board[0].symbol == 0)
            {
                GameLost();
            }
            return;

        }
        if (board[6].symbol == board[4].symbol && board[6].symbol == board[2].symbol)
        {
            if (board[6].symbol == 1)
            {
                GameWon();
            }
            else if (board[6].symbol == 0)
            {
                GameLost();
            }
            return;

        }
       
    }

    private float MiniMax(Square[] board, int depth, bool isMaximizing)
    {
        return 1;
    }

    private void Mistake()
    {

    }
    private void GameLost()
    {
        manager.EndGame(false);

       
       
        
        allowInput = false;
    }
    private void GameWon()
    {
        manager.EndGame(true);
    }
}
