using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Påklædningspil : MonoBehaviour
{
    private bool allowInput = false;
    public Color[] clothingOptions;
    public Image[] bodySprites;
    public Image[] mirrorSprites;
    private int[] correctCombination;
    private int[] currentNumber;
    private int[] convertedNumber;

    private void Start()
    {
        correctCombination = new int[3];
        currentNumber = new int[3];
        convertedNumber = new int[3];

        Debug.Log("Start game");
        for (int i = 0; i < 3; i++)
        {
            correctCombination[i] = Random.Range(0, clothingOptions.Length);
        }
        for (int i = 0; i < 3; i++)
        {
            mirrorSprites[i].color = clothingOptions[correctCombination[i]];
        }
    }
    public void StartGame()
    {
        allowInput = !allowInput;
        
    }
    public void Input(int input)
    {
        switch (input)
        {
            case (1):
                currentNumber[0]--;
                convertedNumber[0] = currentNumber[0] % clothingOptions.Length;
                bodySprites[0].color = clothingOptions[convertedNumber[0]];
                break;
            case (2):
                break;
            case (3):
                currentNumber[0]++;
                convertedNumber[0] = currentNumber[0] % clothingOptions.Length;
                bodySprites[0].color = clothingOptions[convertedNumber[0]];
                break;
            case (4):
                currentNumber[1]--;
                convertedNumber[1] = currentNumber[1] % clothingOptions.Length;
                bodySprites[1].color = clothingOptions[convertedNumber[1]];
                break;
            case (5):
                break;
            case (6):
                currentNumber[1]++;
                convertedNumber[1] = currentNumber[1] % clothingOptions.Length;
                bodySprites[1].color = clothingOptions[convertedNumber[1]];
                break;
            case (7):
                currentNumber[2]--;
                convertedNumber[2] = currentNumber[2] % clothingOptions.Length;
                bodySprites[2].color = clothingOptions[convertedNumber[2]];
                break;
            case (8):
                break;
            case (9):
                currentNumber[2]++;
                convertedNumber[2] = currentNumber[2] % clothingOptions.Length;
                bodySprites[2].color = clothingOptions[convertedNumber[2]];
                break;
        }
    }
}
