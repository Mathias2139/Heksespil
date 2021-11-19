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
        //Play animation when spawning
    }

    // Update is called once per frame
    void Update()
    {
        moleTimer += Time.deltaTime;
        if (moleTimer >= totalMoleTime)
            {
            //Play animation before destroying game object
            Destroy(this);
        }
    }
}
