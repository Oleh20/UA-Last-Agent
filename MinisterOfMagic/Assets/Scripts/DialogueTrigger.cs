using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private GameObject dialogWindow;
    // Start is called before the first frame update
    private void Start()
    {
        dialogWindow.SetActive(false);
    }
    private void TriggerDialogue()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
        dialogWindow.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }
}
