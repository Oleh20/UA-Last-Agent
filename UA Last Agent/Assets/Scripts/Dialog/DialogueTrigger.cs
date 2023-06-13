using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private StartMission startMission;
    [SerializeField] private TimeLine timeLine;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private List<Item> itemsToAdd;

    [SerializeField] private GameObject loadScene;


    [SerializeField] private bool turnOffTrigger;


    [SerializeField] private List<Dialog> dialogs;
    [SerializeField] private List<Condition> conditionsToCheck;


    private int currentDialogIndex = -1;
    private Inventory inventoryUser;
    private Type typeOfCondition;
    private bool canStartMission;

    private void Start()
    {
        SaveDialogs();
        LoadDialogs();
        inventoryUser = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dialogWindow.SetActive(false);


        dialogWindow.SetActive(false);
        startMission = gameObject.GetComponent<StartMission>();

    }
    private Dialog CheckCurrentDialog(List<Dialog> dialogs, List<Condition> conditionsToCheck)
    {
        Dialog dialog = null;
        for (int i = 0; i < dialogs.Count; i++)
        {

            if (conditionsToCheck[i].CheckCondition())
            {
                typeOfCondition = conditionsToCheck[0].GetType();
                currentDialogIndex = i;
                RemoveCurrentDialog();
            }
            dialog = dialogs[i];
            if (conditionsToCheck.Count > 1 && conditionsToCheck[1].GetType() == typeof(FinishMissionCondition))
            {
                canStartMission = true;
            }
            if (conditionsToCheck[i].DeleteAfter == true)
            {
                currentDialogIndex = i;
                break;
            }
            break;

        }
        return dialog;
    }
    private void SaveDialogs()
    {
        string dialogsJson = JsonUtility.ToJson(dialogs);
        string key = "Dialog_" + gameObject.name;
        PlayerPrefs.SetString(key, dialogsJson);
    }

    private void LoadDialogs()
    {
        string key = "Dialog_" + gameObject.name;
        if (PlayerPrefs.HasKey(key))
        {
            string dialogsJson = PlayerPrefs.GetString(key);
            dialogs = JsonUtility.FromJson<List<Dialog>>(dialogsJson);
        }
    }

    private void TriggerDialogue()
    {

        Dialog choosen = CheckCurrentDialog(dialogs, conditionsToCheck);
        if (choosen != null)
        {
            dialogWindow.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(choosen, needToGiveSomething, LoadNextScene, playNextTimeline, RemoveCurrentDialog, StarMission);
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
        if (typeOfCondition == typeof(FinishMissionCondition))
            inventoryUser.AddItem(startMission.itemAfterMission);
    }
    private void LoadNextScene()
    {
        string tag = gameObject.tag;
        if (tag == "Door")
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
    private void StarMission()
    {
        if (canStartMission)
        {
            startMission.StartCurrentMision();
            inventoryUser.AddItem(startMission.itemForMission);
            canStartMission = false;
        }

    }
}
