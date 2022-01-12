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
    public SpriteRenderer sprite;
    public SpriteRenderer armSprite;

    // Start is called before the first frame update
    void Start()
    {
        mole_Animator = GetComponent<Animator>();
        totalMoleTime = totalMoleTime - Mathf.Min(stats.minigamesPlayed / 70, 0.3f);

        if (molePosition + 1 >= 1 && molePosition + 1 < 4)
        {
            sprite.sortingOrder = 5;
            if (isFrog == true)
            {
                armSprite.sortingOrder = 5;
            }
        }
        else if (molePosition + 1 >= 4 && molePosition + 1 < 7)
        {
            sprite.sortingOrder = 3;
            if (isFrog == true)
            {
                armSprite.sortingOrder = 3;
            }
        }
        else
        {
            sprite.sortingOrder = 1;
            if (isFrog == true)
            {
                armSprite.sortingOrder = 1;
            }
        }
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
            // Kalder også ExitMole-funktion via animationen
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
