using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkuffeSpil : MonoBehaviour
{
    private bool allowInput;
    public SkuffeItemScriptableObject[] items;
    private SkuffeItemScriptableObject randomItem;
    private Minigame minigame;
    private int itemPosition;
    private int randomPosition;
    private bool[] drawerOpen;
    public Transform[] drawers;
    private Vector3[] drawerStartPositions;
    public Vector3 drawerOpenAmount;
    public Image foundItemObject;
    private void Start()
    {
         
        randomItem = items[Random.Range(0, items.Length)];
        randomPosition = Random.Range(1, 9);
        itemPosition = randomPosition;
        Debug.Log(randomItem.discription + " is in drawer " + (itemPosition+1));
        minigame = GetComponent<Minigame>();
        minigame.beginText = randomItem.discription;
        drawerOpen = new bool[12];
        drawerStartPositions = new Vector3[drawers.Length];
        foundItemObject.transform.localScale = Vector3.zero;
        foundItemObject.sprite = randomItem.look;
        
        for (int i = 0; i < drawers.Length; i++)
        {
            drawerStartPositions[i] = drawers[i].position;
        }

        foundItemObject.transform.position = drawerStartPositions[randomPosition] - new Vector3(0, 0.3f, 0);

    }
    private void Update()
    {
        for (int i = 0; i < drawers.Length; i++)
        {
            if (drawerOpen[i])
            {
                drawers[i].position = Vector3.MoveTowards(drawers[i].position, drawerStartPositions[i] + drawerOpenAmount, 15 * Time.deltaTime);
            }
            else
            {
                drawers[i].position = Vector3.MoveTowards(drawers[i].position, drawerStartPositions[i], 15 * Time.deltaTime);   
            }
            
        }
    }
    public void StartGame()
    {
        allowInput = true;

    }
    public void Input(int input)
    {
        if (allowInput)
        {
            drawerOpen[input-1] = !drawerOpen[input-1];

            if (drawerOpen[itemPosition] && !drawerOpen[itemPosition + 3])
            {
                Debug.Log("Found Item");
                foundItemObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                minigame.EndGame(1);
                allowInput = false;
            }
        }
        
    }
}
