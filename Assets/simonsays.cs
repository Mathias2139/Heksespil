using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simonsays : MonoBehaviour
{
    private Minigame cimonsays;
    public int et;
    public int to;
    public int tre;
    public int fire;
    public int[] tal;
    private bool allowInput;
    
    void Start()
    {//HVAD DER SKER I STARTEN
        tal = new int[50];
        for (int i = 0; i < tal.Length; i++)
        {
            tal[i] = Random.Range(0, 9);
        }
        cimonsays = GetComponent<Minigame>();
        et = Random.Range(1, 9);
        to = Random.Range(1, 9);
        tre = Random.Range(1, 9);
        fire = Random.Range(1, 9);

        // koden skal vises p� sk�rmen

    }
    public void Input (int input)
    {//hvad der SKER N�R SPILLEREN KLIKKER P� NOGET

       //for hver input skal det checkes om det er rigtigt eller forkert
       //hvis det er rigtigt s� g�r den videre til n�ste tal 
       //hvis det er forkert s� g�r den ikke videre
       //hvis du svare rigtigt p� alle tal, bliver man sendt videre til n�ste spil.

    }
    public void Startgame()
    {
        allowInput = true;
    }
    
}
