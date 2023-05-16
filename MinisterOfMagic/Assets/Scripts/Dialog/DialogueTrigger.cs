using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private TimeLine timeLine;
    [SerializeField] private Dialog alternativeDialog;
    [SerializeField] private GameObject dialogWindow;


    [SerializeField] private bool giveSomething = false;
    [SerializeField] private Item itemToAdd;

    private Inventory inventoryUser;


    [SerializeField] private GameObject loadScene;

    private bool condition = false;
    [SerializeField] private bool turnOffTrigger;

    [SerializeField] private List<Dialog> dialogs;
    [SerializeField] private List<Condition> conditionsToCheck;

    private int currentDialogIndex = -1;


    private void Start()
    {
        inventoryUser = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dialogWindow.SetActive(false);
    }
    private Dialog CheckCurrentDialog(List<Dialog> dialogs, List<Condition> conditionsToCheck)
    {
        Dialog dialog = null;
        for (int i = 0; i < dialogs.Count; i++)
        {

            if (conditionsToCheck[i].CheckCondition())
            {
                giveSomething = true;
                currentDialogIndex = i;
                RemoveCurrentDialog();
            }
            dialog = dialogs[i];
            if (conditionsToCheck[i].DeleteAfter == true)
            {
                currentDialogIndex = i;
                break;
            }
            break;

        }
        return dialog;
    }

    private void TriggerDialogue()
    {

        Dialog choosen = CheckCurrentDialog(dialogs, conditionsToCheck);

        if (choosen != null)
        {
            dialogWindow.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(choosen, needToGiveSomething, LoadNextScene, playNextTimeline, RemoveCurrentDialog);
        }

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
            itemToAdd = null;
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
    public void RemoveCurrentDialog()
    {
        if (currentDialogIndex != -1)
        {
            dialogs.RemoveAt(currentDialogIndex);
            conditionsToCheck.RemoveAt(currentDialogIndex);
            currentDialogIndex = -1;
        }
    }
}
