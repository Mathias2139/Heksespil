using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMole_Minigame : MonoBehaviour
{
    private bool allowInput = false;
    public List<GameObject> SpawnPoints;
    public GameObject Mole;
    private float spawnTimer;
    private float spawnTotalTime;
    private GameObject[] moleArray;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTotalTime = Random.Range(1.5f, 3.5f);
        moleArray = new GameObject[9];
    }

    // Update is called once per frame
    void Update()
    {
        //Spawne nye moles
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTotalTime)
        {
            AddMole();
            spawnTotalTime = Random.Range(1.5f, 2.5f);
            spawnTimer = 0;

        }
            
        
    }

    public void StartGame()
    {
        allowInput = true;
        AddMole();


    }


    public void Input(int input)
    {
        if (allowInput)
        {
            // Hvis input (1-9) har en mole (hvis ikke den position i moleArray er null?)
            // -> slet mole (fjern game object, fjern position på array);
            // giv ekstra tid til global time
            // Hvis ikke -> ikke ske noget? animation af at slå på tomt hul?
        }
    }

    public void AddMole()
    {
        int randomNumber = Random.Range(1, 9);
        Debug.Log(moleArray[randomNumber]);
        if (moleArray[randomNumber] == null)
            {
            GameObject RandomSpawn = SpawnPoints[randomNumber];
            GameObject mole = Instantiate(Mole, RandomSpawn.transform.position, Quaternion.identity);
            mole.GetComponent<Mole>().molePosition = randomNumber;
            moleArray[randomNumber] = mole;
        }
    }

    public void RemoveMole(int position)
    {
        //Modtage en position
        //Finde det game object der er på den position
    }

    public void HitMole(int position)
    {
        //Er der en mole på det felt der er slået på?
        //Hvis der er: fjern mole - point?
        //Hvis der ikke er: ??
    }
}
