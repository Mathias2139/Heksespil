using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;


    
    private int currentDialogue;

    [TextArea]
    public string[] dialogue;
    

    private string cachedDialogue;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

        
        cachedDialogue = dialogue[0];
        currentDialogue = 0;
    }


    public void SkipDialogue()
    {
        
        Debug.Log(dialogueVertexAnimator.sPCDebug);
        if(dialogueVertexAnimator.sPCDebug != float.PositiveInfinity)
        {
            if (currentDialogue > dialogue.Length - 1)
            {
                Debug.Log("Dialogue over");
            }
            else
            {
                //Debug.Log(currentDialogue);
                cachedDialogue = dialogue[currentDialogue];
            }
            PlayDialogue(cachedDialogue);
            currentDialogue++;
        }
        else
        {
            dialogueVertexAnimator.ChangeSpeed(150);
        }
    }

    public void AutoPlay()
    {
        Debug.Log("playing Dialogue");
        PlayDialogue(dialogue[0]);
    }



    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
