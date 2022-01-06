using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenuScript : MonoBehaviour
{
    public GameObject objectToShow;
    public GameObject objectToHide;
    public int[] myButtons;
    public void ChangeMenu()
    {
        objectToHide.SetActive(false);
        objectToShow.SetActive(true);
    }
    public void Input(int input)
    {
        for (int i = 0; i < myButtons.Length; i++)
        {
            if(input == myButtons[i])
            {
                ChangeMenu();
                return;
            }
        }
    }
}
