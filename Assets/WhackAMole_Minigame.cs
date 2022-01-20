using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class WhackAMole_Minigame : MonoBehaviour
{
    private bool allowInput = false;
    public List<GameObject> SpawnPoints;
    public GameObject[] Mole;
    private float spawnTimer;
    private float spawnTotalTime;
    private GameObject[] moleArray;
    public int moleCounter;
    public AnimationCurve spawnTotalTimeDistribution;
    private Minigame minigame;
    public GameStats stats;
    public Transform broomPosition;
    public Animator broomAnimation;
    private int molesSpawned;
    public AudioSource[] BroomSounds;
    public AudioSource[] LossSounds;
    public AudioClip[] voiceOnWin;
    public AudioClip[] voiceOnLose;
    public TimeSinceVoice timeSinceVoice;
    public AudioClipEvent voiceEvent;


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
            spawnTotalTime = Mathf.Clamp(spawnTotalTimeDistribution.Evaluate(Random.Range(0f, 1f))-Mathf.Min(stats.minigamesPlayed/80,0.4f),0,1000);
            Debug.Log(spawnTotalTime);
            // Skal være afhængig af antal spillede minigames, og skal laves om til en kurve
            spawnTimer = 0;
        }
            
        
    }

    public void StartGame()
    {
        allowInput = !allowInput;
        AddMole();
        spawnTotalTime = Mathf.Clamp(spawnTotalTimeDistribution.Evaluate(Random.Range(0f, 1f)) - Mathf.Min(stats.minigamesPlayed / 66, 0.6f),0,1000);
        if (!allowInput)
        {
            for (int i = 0; i < 9; i++)
            {
                if (moleArray[i] != null)
                {
                    moleArray[i].GetComponent<Mole>().timeUp = true;
                }
            }
            //// Spille lyde ved spillets afslutning
            List<int> emptyspots = FindEmptySpots();
            if (emptyspots.Count < 5)
            {
                LossSounds[Random.Range(0, LossSounds.Length)].Play();
                if (timeSinceVoice.time > 5)
                {
                    voiceEvent.Raise(voiceOnLose[UnityEngine.Random.Range(0, voiceOnLose.Length)]);
                }
            }
            else
            {
                if (timeSinceVoice.time > 5)
                {
                    voiceEvent.Raise(voiceOnWin[UnityEngine.Random.Range(0, voiceOnWin.Length)]);
                }
            }
        }
    }


    public void Input(int input)
    {
        if (allowInput)
        {
            broomPosition.position = new Vector3(SpawnPoints[input - 1].transform.position.x, SpawnPoints[input - 1].transform.position.y, broomPosition.position.z);
            broomAnimation.SetTrigger("Smack");
            BroomSounds[Random.Range(0, BroomSounds.Length)].Play();
            if (moleArray[input-1] != null)
            {
                RemoveMole(input-1);
            }
        }
    }

    private List<int> FindEmptySpots()
    {
        List<int> emptyspots = new List<int>();
        for (int i = 0; i < moleArray.Length; i++)
        {
            if (moleArray[i] == null)
            {
                emptyspots.Add(i);
            }
        }
        return emptyspots;
    }

    public void AddMole()
    {
        List<int> emptyspots = FindEmptySpots();
        int randomNumber = Random.Range(0, emptyspots.Count);
        int emptyNumber = emptyspots[randomNumber];
        if (allowInput == true)
        {
            GameObject RandomSpawn = SpawnPoints[emptyNumber];
            int animal = 1;
            if (molesSpawned >3)
            {
                animal = Mathf.Clamp(Random.Range(0, 6), 0, 1);
            }
            GameObject mole = Instantiate(Mole[animal], RandomSpawn.transform.position, Quaternion.identity);
            mole.transform.SetParent(RandomSpawn.transform);
            mole.GetComponent<Mole>().molePosition = emptyNumber;
            moleArray[emptyNumber] = mole;
            molesSpawned++;
        }
    }

    public void RemoveMole(int position)
    {
        moleArray[position].GetComponent<Mole>().MoleHit();
    }
}
