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
    public AudioSource exit;
    public AudioSource hit;
    private bool exitPlaying = false;
    private Coroutine exitRoutine;
    private bool isHit = false;
    public bool timeUp = false;
    public GameStats stats;

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
                exit.Play();
                mole_Animator.SetTrigger("Exit");
            // Kalder også ExitMole-funktion via animationen
        }
    }

    public void ExitMole()
    {
        if (!timeUp)
        {
            globaltime.Raise(-0.75f);
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
            hit.Play();
            mole_Animator.SetTrigger("Hit");
            globaltime.Raise(0.5f);
            Destroy(this.gameObject, 1);
        }    
        
    }
}
