using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TelefonMinigame : MonoBehaviour
{
    public bool allowInput = false;
    public Transform pointer;
    public Sprite[] numberSprites;
    public SpriteRenderer[] spriteRenderers;
    private System.Random random;
    private int progess = 0;
    private int[] phonenumber;
    private Minigame minigame;
    private int moveTowards = 0;
    public Transform[] numberPositions;
    
    
    void Start()
    {
        
    }

    private void Update()
    {
        if(moveTowards != 0)
        {
            pointer.position = Vector3.MoveTowards(pointer.position, numberPositions[moveTowards].position, 15 * Time.deltaTime);
        }
    }

    public void StartGame()
    {
        allowInput = true;
        random = new System.Random();
        minigame = GetComponent<Minigame>();
        phonenumber = GeneratePhoneNumber();
        for (int i = 0; i < 8; i++)
        {
            spriteRenderers[i].sprite = numberSprites[phonenumber[i]];
        }
        GetComponent<Animation>().Play("Telefonspil_Papir");
    }

    private int[] GeneratePhoneNumber()
    {
        int[] numbers = new int[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = Mathf.RoundToInt(random.Next(1,9));
        }
        return numbers;
    }

    public void Input(int input)
    {
        if (allowInput)
        {
            moveTowards = input-1;
            if (input-1 == phonenumber[progess])
            {
                spriteRenderers[progess].color = Color.green;
                progess++;
            }
            else
            {
                spriteRenderers[progess].color = Color.red;
            }
            if(progess == 8)
            {
                GameWon();
                allowInput = false;
            }
        }
    }

    private void GameWon()
    {
        minigame.EndGame(true);
    }
}
