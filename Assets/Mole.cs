using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class Mole : MonoBehaviour
{
    public int molePosition;
    private float moleTimer;
    public float totalMoleTime;
    
    public FloatEvent globaltime;

    // Start is called before the first frame update
    void Start()
    {
        // Spille animation af mole der kommer op
    }

    // Update is called once per frame
    void Update()
    {
        moleTimer += Time.deltaTime;
        if (moleTimer >= totalMoleTime)
            {
            // Spille animation af mole der går ned
            globaltime.Raise(-1);
            Destroy(this.gameObject);
        }
    }
}
