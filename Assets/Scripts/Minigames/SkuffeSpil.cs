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
        foundItemObject.transform.localScale = Vector3.zero;
        foundItemObject.sprite = randomItem.look;

        foundItemObject.transform.position = drawers[randomPosition].transform.position - new Vector3(0, 0.3f, 0);

        for (int i = 0; i < drawers.Length; i++)
        {
            drawerStartPositions[i] = drawers[i].localPosition;
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
                drawers[i].localPosition = Vector3.MoveTowards(drawers[i].localPosition, drawerStartPositions[i] + drawerOpenAmount, 100 * (1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);
            }
            else
            {
                drawers[i].localPosition = Vector3.MoveTowards(drawers[i].localPosition, drawerStartPositions[i], 100*(1 + minigame.currentGameState.completedMinigames / 20) * Time.deltaTime);   
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
        rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-6, 6), ForceMode2D.Impulse);
    }
    IEnumerator ShakeDrawer()
    {
        while (true)
        {

            for (int i = 0; i < 10; i++)
            {
                
                drawer.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-500, 500)) + drawer.rotation.eulerAngles);
                new WaitForSeconds(0.1f);
            }
            drawer.rotation = Quaternion.Euler(Vector3.zero);
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
