using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MA.Events;

public class Påklædningspil : MonoBehaviour
{
    private bool allowInput = false;
    public Sprite[] headClothingOptions;
    public Sprite[] midClothingOptions;
    public Sprite[] bottomClothingOptions;
    private Sprite[][] clothingOptions;
    public SpriteRenderer[] bodySprites;
    public Image[] mirrorSprites;
    private int[] correctCombination;
    private int[] currentCombination;
    private int[] currentNumber;
    private int[] convertedNumber;
    private Minigame minigame;
    public LastOutfit outfit;
    public Animator[] arrows;
    public AudioClip[] topChangeClips;
    public AudioClip[] midChangeClips;
    public AudioClip[] bottomChangeClips;
    private AudioSource audioPlayer;
    public AudioClipEvent voiceEvent;
    public AudioClip[] somethingMoreLines;
    public AudioClip[] somethingElseLines;



    private void Start()
    {
        minigame = GetComponent<Minigame>();
        correctCombination = new int[3];
        currentCombination = new int[3];
        currentNumber = new int[3];
        convertedNumber = new int[3];
        clothingOptions = new Sprite[3][];

        audioPlayer = GetComponent<AudioSource>();

        clothingOptions[0] = headClothingOptions;
        clothingOptions[1] = midClothingOptions;
        clothingOptions[2] = bottomClothingOptions;
        

        Debug.Log("Start game");
        for (int i = 0; i < 3; i++)
        {
            correctCombination[i] = Random.Range(0, headClothingOptions.Length);

            if(outfit.lastOutfit.Length == 3)
            {
                if(correctCombination[i] == outfit.lastOutfit[i])
                {
                    correctCombination[i] = (correctCombination[i] + 2) % headClothingOptions.Length;
                }
            }
        }
        EvaluateNewOutfit();
        for (int i = 0; i < 3; i++)
        {
            if(outfit.lastOutfit.Length != 3)
            {
                currentCombination[i] = Random.Range(0, headClothingOptions.Length);
                if (currentCombination[i] == correctCombination[i])
                {
                    currentCombination[i] = (currentCombination[i] + 2) % headClothingOptions.Length;
                }
                bodySprites[i].sprite = clothingOptions[i][currentCombination[i]];
                currentNumber[i] = currentCombination[i];
            }
            else
            {
                currentNumber[i] = outfit.lastOutfit[i];
            }
            
            ConvertAndDisplay(i);
        }
        
        for (int i = 0; i < 3; i++)
        {
            mirrorSprites[i].sprite = clothingOptions[i][correctCombination[i]];
            
        }


    }

    private void EvaluateNewOutfit()
    {
        int trackedIndex = 100;
        int ofAKind = 1;
        AudioClip clip = somethingElseLines[0];
        for (int i = 0; i < correctCombination.Length; i++)
        {
            if(trackedIndex == correctCombination[i])
            {
                ofAKind++;
            }
            else if(ofAKind == 1)
            {
                trackedIndex = correctCombination[i];
            }
            
        }
        string output = "";
        if(ofAKind >= 2)
        {
            switch (trackedIndex)
            {
                case 0:
                    output = "cozy";
                    clip = somethingMoreLines[0];
                    break;
                case 1:
                    output = "cute";
                    clip = somethingMoreLines[1];
                    break;
                case 2:
                    output = "classy";
                    clip = somethingMoreLines[2];
                    break;
                case 3:
                    output = "practical";
                    clip = somethingElseLines[UnityEngine.Random.Range(0, somethingElseLines.Length)];
                    break;
                case 4:
                    output = "fancy";
                    clip = somethingMoreLines[3];
                    break;
                case 5:
                    output = "colorful";
                    clip = somethingMoreLines[4];
                    break;
                case 6:
                    output = "cool";
                    clip = somethingMoreLines[5];
                    break;
            }
        }
        else
        {
            int random = UnityEngine.Random.Range(0, 3);
            if(random == 0)
            {
                clip = somethingElseLines[UnityEngine.Random.Range(0, somethingElseLines.Length)];
            }
            
        }
        
        voiceEvent.Raise(clip);
    }

    public void StartGame()
    {
        allowInput = !allowInput;
        outfit.lastOutfit = new int[3];
        for (int i = 0; i < 3; i++)
        {
            outfit.lastOutfit[i] = correctCombination[i];
        }
        
    }
    public void Input(int input)
    {
        if (allowInput)
        {
            switch (input)
            {
                case (1):
                    currentNumber[2]--;
                    arrows[0].SetTrigger("Click");
                    PlayBottomSound();
                    ConvertAndDisplay(2);
                    break;
                case (2):
                    break;
                case (3):
                    currentNumber[2]++;
                    arrows[1].SetTrigger("Click");
                    PlayBottomSound();
                    ConvertAndDisplay(2);
                    break;
                case (4):
                    currentNumber[1]--;
                    arrows[2].SetTrigger("Click");
                    PlayMidSound();
                    ConvertAndDisplay(1);
                    break;
                case (5):
                    break;
                case (6):
                    currentNumber[1]++;
                    arrows[3].SetTrigger("Click");
                    PlayMidSound();
                    ConvertAndDisplay(1);
                    break;
                case (7):
                    currentNumber[0]--;
                    arrows[4].SetTrigger("Click");
                    PlayTopSound();
                    ConvertAndDisplay(0);
                    break;
                case (8):
                    break;
                case (9):
                    currentNumber[0]++;
                    arrows[5].SetTrigger("Click");
                    PlayTopSound();
                    ConvertAndDisplay(0);
                    break;
            }
            if (currentCombination[0] == correctCombination[0])
            {
                if (currentCombination[1] == correctCombination[1])
                {
                    if (currentCombination[2] == correctCombination[2])
                    {
                        minigame.EndGame(1);
                    }
                }
            }
        }
    }

    private void PlayTopSound()
    {
        int played = 0;
        played += UnityEngine.Random.Range(0, 4);
        
        audioPlayer.clip = topChangeClips[played];
        audioPlayer.Play();
    }
    private void PlayMidSound()
    {
        int played = 0;
        played += UnityEngine.Random.Range(0, 4);
        
        audioPlayer.clip = midChangeClips[played];
        audioPlayer.Play();
    }
    private void PlayBottomSound()
    {
        int played = 0;
        played += UnityEngine.Random.Range(0, 4);
        
        audioPlayer.clip = bottomChangeClips[played];
        audioPlayer.Play();
    }
    private void ConvertAndDisplay(int value)
    {
        
        convertedNumber[value] = currentNumber[value] % headClothingOptions.Length;
        currentCombination[value] = convertedNumber[value];
        bodySprites[value].sprite = clothingOptions[value][convertedNumber[value]];
    }
}
