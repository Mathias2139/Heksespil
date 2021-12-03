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
    private bool exitPlaying;
    private Coroutine exitRoutine;

    // Start is called before the first frame update
    void Start()
    {
        mole_Animator = GetComponent<Animator>();
        exitPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        moleTimer += Time.deltaTime;
        if (moleTimer >= totalMoleTime && exitPlaying == false) 
        {
            exitPlaying = true;
            if (exitRoutine == null)
            {
                exit.Play();
                mole_Animator.SetTrigger("Exit");
                exitRoutine = StartCoroutine(MoleDelay(true));
            }
        }
    }

    IEnumerator MoleDelay(bool delay)
    {
        while (true)
        {
            if (!delay)
            {
                ExitMole();
                StopAllCoroutines();
            }
            delay = false;
            yield return new WaitForSeconds(0.5f);

        }
    }

    private void ExitMole()
    {
            globaltime.Raise(-1);
            Destroy(this.gameObject);
    }

    public void MoleHit()
    {
        if (exitRoutine != null)
        {
            StopCoroutine(exitRoutine);
        }
            hit.Play();
            mole_Animator.SetTrigger("Hit");
            globaltime.Raise(1);
            Destroy(this.gameObject,1);
    }
}
