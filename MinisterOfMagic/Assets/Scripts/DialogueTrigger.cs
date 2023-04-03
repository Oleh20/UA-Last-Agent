using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    private GameObject dialogWindow;

    private void Start()
    {
        dialogWindow = GameObject.Find("Canvas");
        checkDialog(dialogWindow);
        dialogWindow.SetActive(false);
    }

    private void TriggerDialogue()
    {
        dialogWindow.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }

    private void checkDialog(GameObject dialgoWindow)
    {
        if (dialgoWindow == null)
        {
            Debug.LogError("Dialog window not found!");
            return;
        }
    }
}
