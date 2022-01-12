using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TelefonMinigame : MonoBehaviour
{
    private bool allowInput = false;
    public Transform pointer;
    public Sprite[] numberSprites;
    public SpriteRenderer[] spriteRenderers;
    private System.Random random;
    private int progress = 0;
    private int[] phonenumber;
    private Minigame minigame;
    private int moveTowards = 0;
    public Transform[] numberPositions;
    public AudioClip[] slidingSounds;
    private AudioSource audioPlayer;
    public AudioClip Paperslide;
    private int lastInput;
    
    
    void Start()
    {
        random = new System.Random();
        minigame = GetComponent<Minigame>();
        phonenumber = GeneratePhoneNumber();
        audioPlayer = GetComponent<AudioSource>();
        for (int i = 0; i < 8; i++)
        {
            spriteRenderers[i].sprite = numberSprites[phonenumber[i]];
        }
        GetComponent<Animation>().Play("Telefonspil_Papir");
        audioPlayer.clip = Paperslide;
        audioPlayer.Play();
    }

    private void Update()
    {
        if(moveTowards != 0)
        {
            pointer.position = Vector3.MoveTowards(pointer.position, numberPositions[moveTowards].position, 12 * (1+minigame.currentGameState.completedMinigames/8) * Time.deltaTime);
        }
    }

    public void StartGame()
    {
        if(allowInput == true)
        {
            allowInput = false;
        }
        else
        {
            allowInput = true;
        }
        
        
    }

    private int[] GeneratePhoneNumber()
    {
        int[] numbers = new int[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = Mathf.RoundToInt(random.Next(0,9));
        }
        return numbers;
    }

    public void Input(int input)
    {
        
        if (allowInput)
        {
            #region numpad to phone
            switch (input)
            {
                case (1):
                    input = 7;
                    break;
                case (2):
                    input = 8;
                    break;
                case (3):
                    input = 9;
                    break;
                case (4):
                    input = 4;
                    break;
                case (5):
                    input = 5;
                    break;
                case (6):
                    input = 6;
                    break;
                case (7):
                    input = 1;
                    break;
                case (8):
                    input = 2;
                    break;
                case (9):
                    input = 3;
                    break;
            }
            #endregion
            moveTowards = input;
            if(input != lastInput)
            {
                PlaySound();
            }
            lastInput = input;
            if (input-1 == phonenumber[progress])
            {
                spriteRenderers[progress].color = Color.green;
                progress++;
            }
            else
            {
                spriteRenderers[progress].color = Color.red;
            }
            if(progress == 8)
            {
                GameWon();
                allowInput = false;
            }
        }
    }

    private void PlaySound()
    {
        int random = UnityEngine.Random.Range(0, 6);
      
        audioPlayer.clip = slidingSounds[random];
        audioPlayer.Play();
    }
    private void GameWon()
    {
        minigame.EndGame(1);
    }
}
