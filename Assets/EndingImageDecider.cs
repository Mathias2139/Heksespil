using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingImageDecider : MonoBehaviour
{
    public GameStats stats;
    [SerializeField]
    public IntImage[] intImage;
    public Image renderer;
    public Image cake;


    [System.Serializable]
    public class IntImage
    {
        public int i = 0;
        public Sprite aboveI;
        public Sprite aboveICake;
        public IntImage(int i, Sprite aboveI, Sprite aboveICake)
        {
            this.i = i;
            this.aboveI = aboveI;
            this.aboveICake = aboveICake;
        }
    }


    private void Awake()
    {
        if (intImage.Length > 0)
        {
            Sprite spriteToShow = intImage[0].aboveI;
            Sprite cakeToShow = intImage[0].aboveICake;
            for (int i = 0; i < intImage.Length; i++)
            {
                if(intImage[i].i <= stats.completedMinigames)
                {
                    spriteToShow = intImage[i].aboveI;
                    cakeToShow = intImage[i].aboveICake;
                }
            }
            renderer.sprite = spriteToShow;
            cake.sprite = cakeToShow;
        }
    }
}
