using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class WhackAMole_Minigame : MonoBehaviour
{
    private bool allowInput = false;
    public List<GameObject> SpawnPoints;
    public GameObject Mole;
    private float spawnTimer;
    private float spawnTotalTime;
    private GameObject[] moleArray;
    public int moleCounter;
    public AnimationCurve spawnTotalTimeDistribution;
    private Minigame minigame;
    public GameStats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        minigame = GetComponent<Minigame>();
        spawnTotalTime = 100;
        moleArray = new GameObject[9];
    }

    // Update is called once per frame
    void Update()
    {
        // Spawne nye moles
        if (allowInput == true)
        {
            spawnTimer += Time.deltaTime;
        }
        if (spawnTimer >= spawnTotalTime)
        {
            AddMole();
            spawnTotalTime = spawnTotalTimeDistribution.Evaluate(Random.Range(0f, 1f))-Mathf.Min(stats.minigamesPlayed/125,0.4f);
            Debug.Log(spawnTotalTime);
            // Skal være afhængig af antal spillede minigames, og skal laves om til en kurve
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
        allowInput = !allowInput;
        AddMole();
        spawnTotalTime = spawnTotalTimeDistribution.Evaluate(Random.Range(0f, 1f)) - Mathf.Min(stats.minigamesPlayed / 125, 0.4f);
        if (!allowInput)
        {
            for (int i = 0; i < 9; i++)
            {
                if (moleArray[i] != null)
                {
                    moleArray[i].GetComponent<Mole>().timeUp = true;
                }
            }
        }
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
        if (moleCounter < 8 && allowInput == true)
        {
            if (moleArray[randomNumber] == null)
            {
                GameObject RandomSpawn = SpawnPoints[randomNumber];
                GameObject mole = Instantiate(Mole, RandomSpawn.transform.position, Quaternion.identity);
                mole.transform.SetParent(this.gameObject.transform);
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
        moleArray[position].GetComponent<Mole>().MoleHit();
    }
}
