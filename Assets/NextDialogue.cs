using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    [SerializeField]
    public ScrapbookDialogueManager dialogue;
    private void OnEnable()
    {
        dialogue.SkipDialogue();
    }
}
