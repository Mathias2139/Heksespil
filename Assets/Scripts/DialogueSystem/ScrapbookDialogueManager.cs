using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrapbookDialogueManager : MonoBehaviour
{
    public TMP_Text[] textBox;
    [TextArea(2, 16)]
    public string[] dialogue;

    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;
    public Transform cam;
    //public Transform[] camPoints;
    private Coroutine movingCamera;


    
    private int currentDialogue;

    
    

    private string cachedDialogue;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[0], audioSourceGroup);

        
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
                cachedDialogue = dialogue[currentDialogue];
                dialogueVertexAnimator = new DialogueVertexAnimator(textBox[currentDialogue], audioSourceGroup);
                
                
                
                
                PlayDialogue();
            }

        }
        else
        {
            dialogueVertexAnimator.ChangeSpeed(150);
        }
    }
    void Update()
    {
        //Debug.Log("Moving Camera Towards camPoint" + currentDialogue + " at " + camPoints[currentDialogue].position + ". Current progress " + Vector3.MoveTowards(cam.position, camPoints[currentDialogue].position, 100));
        //cam.position = Vector3.MoveTowards(cam.position, camPoints[currentDialogue-1].position, 500 * Time.deltaTime);
    }
    private void PlayDialogue()
    {
        //Debug.Log("Playing Dialogue");
        
        PlayDialogue(cachedDialogue);
        currentDialogue++;
    }
    /*
    IEnumerator MoveCamera()
    {
        while (true)
        {
            Debug.Log(currentDialogue);
            cam.position = Vector3.MoveTowards(cam.position, camPoints[currentDialogue].position, 100);
            //Debug.Log("Moving cam to: " + Vector3.MoveTowards(cam.position, camPoints[currentDialogue].position, 100));
            //Debug.Log(Vector3.Distance(cam.position, camPoints[currentDialogue].position));
            if(Vector3.Distance(cam.position, camPoints[currentDialogue].position) < 1)
            {
                
                //Debug.Log("Stopped Coroutine");
                StopAllCoroutines();
            }
            yield return new WaitForEndOfFrame();
        }
    }
    
    public void AutoPlay()
    {
        Debug.Log("playing Dialogue");
        PlayDialogue(dialogue[0]);
    }

    */

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
