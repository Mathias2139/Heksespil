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
    public int moleCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTotalTime = 1.5f;
        moleArray = new GameObject[9];
    }

    // Update is called once per frame
    void Update()
    {
        // Spawne nye moles
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTotalTime)
        {
            AddMole();
            spawnTotalTime = Random.Range(0.5f, 1.5f);
            spawnTimer = 0;
        }
            
        
    }
    private void FixedUpdate()
    {
        // Holder styr på hvor mange moles der er i banen samtidigt
        int moleCounter = 0;
        for (int i = 0; i < moleArray.Length; i++)
        {
            moleCounter++;
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
            if (moleArray[input-1] != null)
            {
                // Spille animation af kost 
                // Animation.Play();
                RemoveMole(input-1);
            }
            else
            {
                // Spille animation af kost
            }
        }
    }

    public void AddMole()
    {
        int randomNumber = Random.Range(0, 9);
        Debug.Log(moleArray[randomNumber]);
        if (moleCounter < 8)
        {
            if (moleArray[randomNumber] == null)
            {
                GameObject RandomSpawn = SpawnPoints[randomNumber];
                GameObject mole = Instantiate(Mole, RandomSpawn.transform.position, Quaternion.identity);
                mole.GetComponent<Mole>().molePosition = randomNumber;
                moleArray[randomNumber] = mole;
                // moleCounter = moleCounter+1;
            }
            else
            {
                AddMole();
            }
        }
    }

    public void RemoveMole(int position)
    {
        // Spille animation af mole der bliver slået
        Destroy(moleArray[position]);
        // moleCounter = moleCounter - 1;
    }
}
