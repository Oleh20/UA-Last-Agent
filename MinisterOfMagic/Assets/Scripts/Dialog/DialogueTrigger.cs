using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private Dialog alternativeDialog;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private bool condition = false;

    private void Start()
    {
        dialogWindow.SetActive(false);
    }

    private void TriggerDialogue()
    {
        Dialog choosen = condition ? alternativeDialog : dialog;
        dialogWindow.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(choosen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }

    private bool CheckOfCondition()
    {
        return condition;   
    }
}
