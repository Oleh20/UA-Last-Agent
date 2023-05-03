using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private TimeLine timeLine;
    [SerializeField] private Dialog alternativeDialog;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private bool giveSomething = false;

    private Inventory inventoryUser;

    [SerializeField] private Item itemToAdd;

    [SerializeField] private Condition conditionToCheck;

    [SerializeField] private GameObject loadScene;

    private bool condition = false;
    [SerializeField] private bool turnOffTrigger;

  

    private void Start()
    {
        inventoryUser = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
        FindObjectOfType<DialogueManager>().StartDialogue(choosen, needToGiveSomething, LoadNextScene, playNextTimeline);
       
    }
    private void DialogExit()
    {
        if (turnOffTrigger)
        {
            gameObject.SetActive(false);
            turnOffTrigger = false;
        }
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
    private void playNextTimeline()
    {
        if (timeLine.playableDirector)
        {
            timeLine.playableDirector.playableAsset = timeLine.timelineAsset;
            timeLine.playableDirector.Play();
        }
    }
}
