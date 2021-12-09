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

    // Start is called before the first frame update
    void Start()
    {
        mole_Animator = GetComponent<Animator>();
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
        }
    }

    public void ExitMole()
    {
            globaltime.Raise(-1);
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
            globaltime.Raise(1);
            Destroy(this.gameObject, 1);
        }    
        
    }
}
