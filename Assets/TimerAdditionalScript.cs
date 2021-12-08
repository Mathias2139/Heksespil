using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAdditionalScript : MonoBehaviour
{
    public GameManager manager;
    public void ApplyTime()
    {
        manager.ResetTimeGain();
    }
}
