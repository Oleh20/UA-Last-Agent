using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private Dialog alternativeDialog;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private bool condition = false;
    [SerializeField] private bool giveSomething = false;
    [SerializeField] private Inventory inventoryUser;
    [SerializeField] private Item itemToAdd;

    [SerializeField] private Condition conditionToCheck;


    [SerializeField] private GameObject loadScene;

    private void Start()
    {
        dialogWindow.SetActive(false);
    }

    private void TriggerDialogue()
    {
        if (conditionToCheck.CheckCondition())
        {
            condition = true;
        }
    
        Dialog choosen = condition ? alternativeDialog : dialog;
        dialogWindow.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(choosen, needToGiveSomething, LoadNextScene);
       
    }
    private void DialogExit()
    {
        dialogWindow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogExit();
    }
    private void needToGiveSomething()
    {
        if (giveSomething && !condition)
        {
            condition = true;
            inventoryUser.AddItem(itemToAdd);
        }
    }
    private void LoadNextScene()
    {
        string tag = gameObject.tag;
        if (tag == "Door" && condition) 
        {
            loadScene.SetActive(true);
        }
    }
}
