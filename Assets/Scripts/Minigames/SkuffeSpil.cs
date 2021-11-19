using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkuffeSpil : MonoBehaviour
{
    private bool allowInput;
    public SkuffeItemScriptableObject[] items;
    private SkuffeItemScriptableObject randomItem;
    private Minigame minigame;
    private void Start()
    {
        randomItem = items[Random.Range(0, items.Length)];
        minigame = GetComponent<Minigame>();
        minigame.beginText = randomItem.discription;
    }
    public void StartGame()
    {
        allowInput = true;

    }
    public void Input(int input)
    {
        if (allowInput)
        {

        }
    }
}
