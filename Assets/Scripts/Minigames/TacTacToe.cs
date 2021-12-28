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
    public bool aiStarts;
    private bool startRandom = true;
    private List<int> xMoves;
    private List<int> oMoves;
    public Transform handIdle;
    public Transform handReady;
    public Transform hand;
    public Transform paw;
    public Transform pawIdle;
    private bool aiStarted = false;
    public float handAndPawMoveSpeed = 100;
    private bool movingTowardTarget;
    public Vector3 squareOffset;
    private Coroutine playerRoutine;
    private Coroutine aiRoutine;
    private int playerChosenSquare = 10;
    private bool aiPawsTurn;
    public Sprite handNoPiece;
    public Sprite handYesPiece;
    

    public int[,] winCombos = new int[8, 3]
        {
            {0,1,2 },
            {3,4,5 },
            {6,7,8 },
            {0,3,6 },
            {1,4,7 },
            {2,5,8 },
            {0,4,8 },
            {6,4,2 }
        };


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
        if (aiStarts && !aiStarted)
        {
            aiStarted = true;
            startRandom = false;
            AIMove();
        }
        if (allowInput == true)
        {
            allowInput = false;
        }
        else
        {
            if (!aiStarted)
            {
                allowInput = true;
            }
            

        }
    }

    private void Update()
    {
        if (!movingTowardTarget)
        {
            if (allowInput)
            {
                hand.position = Vector3.MoveTowards(hand.position, handReady.position, handAndPawMoveSpeed * (1 + manager.currentGameState.minigamesPlayed / 30) * Time.deltaTime);
            }
            else
            {
                hand.position = Vector3.MoveTowards(hand.position, handIdle.position, 2 * handAndPawMoveSpeed * (1 + manager.currentGameState.minigamesPlayed / 30) * Time.deltaTime);
            }
        }
        if(playerChosenSquare != 10)
        {
            hand.position = Vector3.MoveTowards(hand.position, board[playerChosenSquare].squareRenderer.transform.position + squareOffset, handAndPawMoveSpeed * (1 + manager.currentGameState.minigamesPlayed / 30) * Time.deltaTime);
            if (Vector3.Distance(hand.position, board[playerChosenSquare].squareRenderer.transform.position + squareOffset) <= 0.001f)
            {
                PlayerMove(playerChosenSquare);
                movingTowardTarget = false;
                playerChosenSquare = 10;
            }
        }
        if (!aiPawsTurn)
        {
            paw.position = Vector3.MoveTowards(paw.position, pawIdle.position, handAndPawMoveSpeed * (1 + manager.currentGameState.minigamesPlayed / 30) * Time.deltaTime);
        }
        
    }

    public void Input(int targetSquare)
    {
        if (allowInput)
        {
            /*
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
            */
            

            //Player Move
            if (board[targetSquare - 1].isEmpty)
            {
                //Play Animation
                movingTowardTarget = true;
                StopAllCoroutines();
                playerChosenSquare = targetSquare-1;
            }
            else
            {
                Debug.Log("Square Already Occupied");
            }

        }
        
        

    }
    IEnumerator PlayerDelay(int targetSquare)
    {
        while (true)
        {
            
            yield return new WaitForEndOfFrame();
        }
    }
   IEnumerator AIDelay(int index)
    {
        while (true)
        {
            aiPawsTurn = true;
            paw.position = Vector3.MoveTowards(paw.position, board[index].squareRenderer.transform.position, handAndPawMoveSpeed * (1 + manager.currentGameState.minigamesPlayed / 30) * Time.deltaTime);
            if (Vector3.Distance(paw.position, board[index].squareRenderer.transform.position) <= 0.001f)
            {
                
                AiPlacePiece(index);
                aiPawsTurn = false;
                StopAllCoroutines();
            }
            
            yield return new WaitForEndOfFrame();

        }
    }
    private void PlayerMove(int targetSquare)
    {
        board[targetSquare].squareRenderer.sprite = symbols[0];
        board[targetSquare].isEmpty = false;
        board[targetSquare].symbol = 1;
        xMoves.Add(targetSquare);
        /*
        if (xMoves.Count > 3)
        {
            board[xMoves[0]].squareRenderer.sprite = null;
            board[xMoves[0]].isEmpty = true;
            board[xMoves[0]].symbol = 2;
            xMoves.RemoveAt(0);
        }
        */
        if (xMoves.Count >= 3)
        {

            if (CheckForWinner(1))
            {

                GameFinish(1);
                allowInput = false;
                movingTowardTarget = false;
                return;
            }
        }

        hand.GetComponent<SpriteRenderer>().sprite = handNoPiece;
        allowInput = false;
        AIMove();
        
    }
    private void AIMove()
    {

        //AI Move
        List<int> emptySpots = new List<int>();
        FindEmptySpot(emptySpots);
        if (emptySpots.Count != 0)
        {
            if (!startRandom)
            {
                int bestScore = -100;
                int bestMove = 0;
                for (int i = 0; i < emptySpots.Count; i++)
                {

                    int[] simboard = new int[9];
                    int j = 0;
                    foreach (Square symbol in board)
                    {
                        simboard[j] = symbol.symbol;
                        j++;
                    }

                    int score = -100;
                    if (EvaluatePosition(0, simboard, emptySpots[i]) == true)
                    {

                        score = 10;
                    }
                    else if (EvaluatePosition(1, simboard, emptySpots[i]) == true)
                    {

                        if (score < -10)
                        {
                            score = -10;
                        }

                    }
                    if (EvaluatePosition(0, simboard, emptySpots[i]) == false)
                    {
                        if (score < -50)
                        {
                            score = -50;
                        }
                    }
                    else if (EvaluatePosition(1, simboard, emptySpots[i]) == false)
                    {
                        if (score < -50)
                        {
                            score = -50;
                        }
                    }

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = emptySpots[i];
                        
                    }

                }
                if (bestScore == -100)
                {
                    System.Random random = new System.Random();
                    bestMove = emptySpots[random.Next(emptySpots.Count)];
                    
                   
                    
                    
                    
                }
                Debug.Log(bestMove);
                StopAllCoroutines();
                StartCoroutine(AIDelay(bestMove));

            }
            else
            {
                System.Random random = new System.Random();
                int index = random.Next(emptySpots.Count);
                
                
                StopAllCoroutines();
                
                StartCoroutine(AIDelay(emptySpots[index]));
                //play Animation

            }

            

        }
        else
        {
            GameFinish(4);
            allowInput = false;
        }

    }
    private void AiPlacePiece(int bestMoves)
    {
        board[bestMoves].squareRenderer.sprite = symbols[1];
        board[bestMoves].isEmpty = false;
        board[bestMoves].symbol = 0;
        oMoves.Add(bestMoves);

        if (oMoves.Count >= 3)
        {

            if (CheckForWinner(0))
            {
                Debug.Log("O Wins");
                GameFinish(2);
                allowInput = false;
                return;

            }
        }
        startRandom = !startRandom;

        //Find Random
        hand.GetComponent<SpriteRenderer>().sprite = handYesPiece;
        allowInput = true;
    }
    private bool EvaluatePosition(int piece, int[] board, int emptySpot)
    {
        
        board[emptySpot] = piece;

        for (int i = 0; i < 8; i++)
        {
            if (board[winCombos[i, 0]] == piece && board[winCombos[i, 1]] == piece && board[winCombos[i, 2]] == piece)
            {
                return true;
            }
        }
        return false;
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
        Debug.Log(spots.Count + " empty spots");
    }

    private bool CheckForWinner(int piece)
    {
        for (int i = 0; i < 8; i++)
        {
            if (board[winCombos[i,0]].symbol == piece && board[winCombos[i, 1]].symbol == piece && board[winCombos[i, 2]].symbol == piece)
            {
                
                return true;
            }
        }
        return false;
        #region old win check
        /*
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
        */
        #endregion

    }

    private float MiniMax(Square[] board, int depth, bool isMaximizing)
    {
        return 1;
    }

    private void Mistake()
    {

    }
    private void GameFinish(int won)
    {
        manager.EndGame(won);
        hand.GetComponent<SpriteRenderer>().sprite = handNoPiece;
        movingTowardTarget = false;
        allowInput = false;
    }
    private void GameWon()
    {
        manager.EndGame(1);
    }
}
