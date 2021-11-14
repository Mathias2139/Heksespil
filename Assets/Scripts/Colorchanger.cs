using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Colorchanger : MonoBehaviour
{
    public PlayerControls input;
    public GameObject[] mat;
    public bool[] held;
    void Awake()
    {
        input = new PlayerControls();
        held = new bool[mat.Length];
    }

   
    void Update()
    {
        for (int i = 0; i < mat.Length; i++)
        {
            if (!held[i])
            {
                mat[i].GetComponent<Renderer>().material.color = new Color(0, Mathf.Clamp(mat[i].GetComponent<Renderer>().material.color.g - 2 * Time.deltaTime,0,255), 0);
            }

        }
       
    }

    public void One(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[0] = true;
        }
        if (context.performed)
        {
            mat[0].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[0] = false;
        }
    }
    public void Two(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[1] = true;
        }
        if (context.performed)
        {
            mat[1].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[1] = false;
        }
    }
    public void Three(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[2] = true;
        }
        if (context.performed)
        {
            mat[2].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[2] = false;
        }
    }
    public void Four(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[3] = true;
        }
        if (context.performed)
        {
            mat[3].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[3] = false;
        }
    }
    public void Five(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[4] = true;
        }
        if (context.performed)
        {
            mat[4].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[4] = false;
        }
    }
    public void Six(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            held[5] = true;
        }
        if (context.performed)
        {
            mat[5].GetComponent<Renderer>().material.color = Color.green;
        }
        if (context.canceled)
        {
            held[5] = false;
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
