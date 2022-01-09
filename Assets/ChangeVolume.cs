using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    public AudioManager manager;
    public int AmountToChangeBy = 20;
    public string Target;
    public void Change()
    {
        manager.ChangeVolume(Target, AmountToChangeBy);
    }
}
