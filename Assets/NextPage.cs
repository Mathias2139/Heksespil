using BookCurlPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    public AutoFlip book;
    private void OnEnable()
    {
        book.FlipRightPage();
    }
}
