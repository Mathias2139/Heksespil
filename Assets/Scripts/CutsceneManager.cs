using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] images;
    public Transform cam;
    private Vector3 camPos;
    private PlayerControls input;
    private Vector2 pos;
    private int currentImage = 0;
    //public Image imageRenderer;
    private ScrapbookDialogueManager dialogue;
    public UnityEvent events;
    public string sceneToLoad;
    public Animator animator;
    void Start()
    {
        input = new PlayerControls();
        
        camPos = cam.transform.position;
        dialogue = GetComponent<ScrapbookDialogueManager>();
        dialogue.SkipDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.localPosition = camPos + (new Vector3((pos.x - (Screen.width/2)) / 400, (pos.y - (Screen.height / 2)) / 300, 0) );
    }

    
    public void NextImage()
    {

        currentImage++;
        if (currentImage < images.Length)
        {
            //imageRenderer.sprite = images[currentImage];
            dialogue.SkipDialogue();
        }
        else
        {
            animator.SetBool("In", true);
            //SceneManager.LoadScene(sceneToLoad);
        }
    }
    public void NextDialogue(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentImage++;
            if (currentImage < images.Length)
            {
                //imageRenderer.sprite = images[currentImage];
                    dialogue.SkipDialogue();
            }
            else
            {
                animator.SetBool("In", true);
                //SceneManager.LoadScene(sceneToLoad);
            }

            
        }
    }
    public void MousePos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pos = context.ReadValue<Vector2>();
        }
    }
    private void onEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
}
