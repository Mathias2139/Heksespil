using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndingTextDecider : MonoBehaviour
{
    public GameStats stats;
    public Text text;
    [SerializeField]
    public IntText[] intText;

    [System.Serializable]
    public class IntText
    {
        public int i = 0;
        public string aboveI;
        public IntText(int i, string aboveI)
        {
            this.i = i;
            this.aboveI = aboveI;
        }
    }

    private void Awake()
    {
        if (intText.Length > 0)
        {
            string textToShow = intText[0].aboveI;
            for (int i = 0; i < intText.Length; i++)
            {
                if (intText[i].i <= stats.completedMinigames)
                {
                    Debug.Log(intText[i].i + " Is greater then " + stats.completedMinigames);
                    textToShow = intText[i].aboveI;
                }
            }
            text.text = textToShow;
        }
    }
}
