using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingImageDecider : MonoBehaviour
{
    public GameStats stats;
    [SerializeField]
    public IntImage[] intImage;
    public SpriteRenderer renderer;


    [System.Serializable]
    public class IntImage
    {
        public int i = 0;
        public Sprite aboveI;
        public IntImage(int i, Sprite aboveI)
        {
            this.i = i;
            this.aboveI = aboveI;
        }
    }


    private void Awake()
    {
        if (intImage.Length > 0)
        {
            Sprite spriteToShow = intImage[0].aboveI;
            for (int i = 0; i < intImage.Length; i++)
            {
                if(intImage[i].i <= stats.completedMinigames)
                {
                    spriteToShow = intImage[i].aboveI;
                }
            }
            renderer.sprite = spriteToShow;
        }
    }
}
