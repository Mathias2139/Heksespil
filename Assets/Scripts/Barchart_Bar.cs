using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barchart_Bar : MonoBehaviour
{
    public Sprite sprite;
    public Image image;
    public float playedValue;
    public float wonValue;
    private Slider Playedslider;
    public Slider WonSlider;
    private void Start()
    {
        Playedslider = GetComponent<Slider>();
        Playedslider.value = playedValue;
        WonSlider.value = wonValue;
        image.sprite = sprite;
    }
}
