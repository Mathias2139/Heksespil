using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public int molePosition;
    private float moleTimer;
    public float totalMoleTime;


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
            Destroy(this.gameObject);
        }
    }
}
