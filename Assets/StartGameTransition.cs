using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTransition : MonoBehaviour
{
    public Animator ani;
    private void OnEnable()
    {
        Transition();
    }
    public void Transition()
    {
        ani.SetBool("In", true);
    }
}
