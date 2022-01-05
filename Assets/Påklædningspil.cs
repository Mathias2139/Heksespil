using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    private void Start()
    {
        minigame = GetComponent<Minigame>();
        correctCombination = new int[3];
        currentCombination = new int[3];
        currentNumber = new int[3];
        convertedNumber = new int[3];
        clothingOptions = new Sprite[3][];

        clothingOptions[0] = headClothingOptions;
        clothingOptions[1] = midClothingOptions;
        clothingOptions[2] = bottomClothingOptions;


        Debug.Log("Start game");
        for (int i = 0; i < 3; i++)
        {
            correctCombination[i] = Random.Range(0, headClothingOptions.Length);
        }
        for (int i = 0; i < 3; i++)
        {
            currentCombination[i] = Random.Range(0, headClothingOptions.Length);
            if(currentCombination[i] == correctCombination[i])
            {
                currentCombination[i] = (currentCombination[i] + 2) % headClothingOptions.Length;
            }
            bodySprites[i].sprite = clothingOptions[i][currentCombination[i]];
            currentNumber[i] = currentCombination[i];
            ConvertAndDisplay(i);
        }
        
        for (int i = 0; i < 3; i++)
        {
            mirrorSprites[i].sprite = clothingOptions[i][correctCombination[i]];
        }
    }
    public void StartGame()
    {
        allowInput = !allowInput;
        
    }
    public void Input(int input)
    {
        if (allowInput)
        {
            switch (input)
            {
                case (1):
                    currentNumber[2]--;
                    ConvertAndDisplay(2);
                    break;
                case (2):
                    break;
                case (3):
                    currentNumber[2]++;
                    ConvertAndDisplay(2);
                    break;
                case (4):
                    currentNumber[1]--;
                    ConvertAndDisplay(1);
                    break;
                case (5):
                    break;
                case (6):
                    currentNumber[1]++;
                    ConvertAndDisplay(1);
                    break;
                case (7):
                    currentNumber[0]--;
                    ConvertAndDisplay(0);
                    break;
                case (8):
                    break;
                case (9):
                    currentNumber[0]++;
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

    private void ConvertAndDisplay(int value)
    {
        
        convertedNumber[value] = currentNumber[value] % headClothingOptions.Length;
        currentCombination[value] = convertedNumber[value];
        bodySprites[value].sprite = clothingOptions[value][convertedNumber[value]];
    }
}
