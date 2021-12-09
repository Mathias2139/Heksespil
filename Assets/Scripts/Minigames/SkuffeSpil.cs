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
    public Transform[] drawerFronts;
    public float[] drawerOpenAmounts;
    
    private Vector3[] drawerStartPositions;
    private Vector3[] drawerFrontsSP;
    public Vector3 drawerOpenAmount;
    public Image foundItemObject;
    public Transform drawer;
    private Rigidbody2D rb;
    public AudioClip[] drawerOpeningSounds;
    public AudioClip[] drawerClosingSounds;
    private AudioSource audioplayer;
    
    private void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        rb = drawer.GetComponent<Rigidbody2D>();
        randomItem = items[Random.Range(0, items.Length)];
        randomPosition = Random.Range(1, 9);
        itemPosition = randomPosition;
        Debug.Log(randomItem.discription + " is in drawer " + (itemPosition+1));
        minigame = GetComponent<Minigame>();
        minigame.beginText = randomItem.discription;
        drawerOpen = new bool[12];
        drawerStartPositions = new Vector3[drawers.Length];
        drawerFrontsSP = new Vector3[drawerFronts.Length];
        foundItemObject.transform.localScale = Vector3.zero;
        foundItemObject.sprite = randomItem.look;
        
        foundItemObject.transform.position = drawers[randomPosition].transform.position - new Vector3(0, 0.3f, 0);

        for (int i = 0; i < drawers.Length; i++)
        {
            drawerStartPositions[i] = drawers[i].localPosition;
        }
        for (int i = 0; i < drawerFronts.Length; i++)
        {
            drawerFrontsSP[i] = drawerFronts[i].localPosition;
        }
        for (int i = 0; i < 9; i++)
        {
            int ran = Random.Range(0, 2);
            if(ran == 1)
            {
                drawerOpen[i] = true;
            }
            
        }
        drawerOpen[randomPosition] = false;
        for (int i = 0; i < drawers.Length; i++)
        {
            drawers[i].localPosition = drawerStartPositions[i] + drawerOpenAmount;
        }

        

    }
    private void Update()
    {
        for (int i = 0; i < drawers.Length; i++)
        {
            if (drawerOpen[i])
            {
                drawers[i].localPosition = Vector3.MoveTowards(drawers[i].localPosition, new Vector3(drawerStartPositions[i].x, drawerStartPositions[i].y + drawerOpenAmounts[i], drawerStartPositions[i].z), 100 * (1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);
                drawerFronts[i].localPosition = Vector3.MoveTowards(drawerFronts[i].localPosition, new Vector3(drawerFrontsSP[i].x, drawerFrontsSP[i].y + drawerOpenAmounts[i], drawerFrontsSP[i].z), 100 * (1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);
            }
            else
            {
                drawers[i].localPosition = Vector3.MoveTowards(drawers[i].localPosition, drawerStartPositions[i], 100*(1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);
                drawerFronts[i].localPosition = Vector3.MoveTowards(drawerFronts[i].localPosition, drawerFrontsSP[i], 100 * (1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);
            }
            
        }
        
    }
    public void StartGame()
    {
        if (allowInput == true)
        {
            allowInput = false;
        }
        else
        {
            allowInput = true;
        }

    }
    public void Input(int input)
    {
        if (allowInput)
        {
            drawerOpen[input-1] = !drawerOpen[input-1];
            if(drawerOpen[input - 1] == false)
            {
                //Play Random closing sound
                audioplayer.clip = drawerClosingSounds[Random.Range(0, drawerClosingSounds.Length)];
                audioplayer.Play();
                Shake();
            }
            else
            {
                audioplayer.clip = drawerOpeningSounds[Random.Range(0, drawerOpeningSounds.Length)];
                audioplayer.Play();
            }

            if (drawerOpen[itemPosition] && !drawerOpen[itemPosition + 3])
            {
                Debug.Log("Found Item");
                foundItemObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                minigame.EndGame(1);
                allowInput = false;
            }
        }
        
    }
    private void Shake()
    {
        rb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-7, 7), ForceMode2D.Impulse);
       
    }
}
