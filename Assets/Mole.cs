using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class Mole : MonoBehaviour
{
    public int molePosition;
    private float moleTimer;
    public float totalMoleTime;
    public Animator mole_Animator;
    public FloatEvent globaltime;
    private bool exitPlaying = false;
    private Coroutine exitRoutine;
    private bool isHit = false;
    public bool timeUp = false;
    public GameStats stats;
    public float timeOnHit = 0.5f;
    public float timeOnLeave = -0.75f;
    public bool isFrog = false;
    public AudioSource[] Exits;
    public AudioSource[] Hits;

    // Start is called before the first frame update
    void Start()
    {
        mole_Animator = GetComponent<Animator>();
        totalMoleTime = totalMoleTime - Mathf.Min(stats.minigamesPlayed / 70, 0.4f);

    }

    // Update is called once per frame
    void Update()
    {
        moleTimer += Time.deltaTime;
        if (moleTimer >= totalMoleTime && exitPlaying == false) 
        {
            exitPlaying = true;
            Exits[Random.Range(0, Exits.Length)].Play();
            mole_Animator.SetTrigger("Exit");
            // Kalder ogs� ExitMole-funktion via animationen
        }
    }

    public void ExitMole()
    {
        if (!timeUp)
        {
            globaltime.Raise(timeOnLeave);
            //-0,75f
        }
        Destroy(this.gameObject);
    }

    public void MoleHit()
    {
        if (exitRoutine != null)
        {
            StopAllCoroutines();
        }
        if (isHit == false)
        {
            isHit = true;
            Hits[Random.Range(0, Hits.Length)].Play();
            mole_Animator.SetTrigger("Hit");
            globaltime.Raise(timeOnHit);
            //0.5f
            Destroy(this.gameObject, 1);
        }    
        
    }
}
