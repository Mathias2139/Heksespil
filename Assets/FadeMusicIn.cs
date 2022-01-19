using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;


public class FadeMusicIn : MonoBehaviour
{
    public FloatEvent fadeIn;
    
    public void OnEnable()
    {
        fadeIn.Raise(0.5f);
    }
}
