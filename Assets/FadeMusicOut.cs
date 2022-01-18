using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;

public class FadeMusicOut : MonoBehaviour
{
    public FloatEvent fadeOut;
    private void OnEnable()
    {
        fadeOut.Raise(0.1f);
    }
}
