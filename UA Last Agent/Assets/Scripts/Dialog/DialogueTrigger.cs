using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Windows;

public class DialogueTrigger : MonoBehaviour
{
    public ListDialogItems DialogList = new ListDialogItems();
    private DialogData dialogData = new DialogData();
    private List<Dialog> dialogs;
    private StartMission startMission;
    [SerializeField] private TimeLine timeLine;
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private List<Item> itemsToAdd;
    [SerializeField] private GameObject loadScene;

    [SerializeField] private bool turnOffTrigger;

    private List<Condition> conditionsToCheck;

    public List<string> conditionNames;

    private int currentDialogIndex = -1;
    private Inventory inventoryUser;
    private Type typeOfCondition;
    private bool canStartMission;
    private bool canSave;
    private void Start()
    {
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
            canSave = true;
            if (conditionsToCheck[i].CheckCondition())
            {
                typeOfCondition = conditionsToCheck[0].GetType();
                currentDialogIndex = i;
                RemoveCurrentDialog();
            }
            dialog = dialogs[i];
            if (conditionsToCheck.Count > 1 && conditionsToCheck[1].GetType() == typeof(FinishMissionCondition))
            {
                canSave = false;
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
        if (canSave)
        {
            DialogList.Dialog = dialogs;
            string dialogsJson = JsonUtility.ToJson(DialogList);
            string key = "Dialog_" + gameObject.name;
            PlayerPrefs.SetString(key, dialogsJson);
        }

    }
    private void SaveConditions()
    {
        if (canSave)
        {
            List<string> tempConditionNames = new List<string>();
            foreach (Condition condition in conditionsToCheck)
            {
                string conditionName = condition.ToString();
                string pattern = @"\((.*?)\)";
                Match match = Regex.Match(conditionName, pattern);
                if (match.Success)
                {
                    string result = match.Groups[1].Value;
                    tempConditionNames.Add(result);
                }
                else
                {
                    Debug.Log(conditionName + " haven't ()");
                }
            }
            string conditionNamesString = string.Join(",", tempConditionNames.ToArray());
            string key = "Conditions_" + gameObject.name;
            PlayerPrefs.SetString(key, conditionNamesString);
        }
    }
    private void LoadConditions()
    {
        conditionsToCheck.Clear();
        string key = "Conditions_" + gameObject.name;
        if (PlayerPrefs.HasKey(key))
        {
            string conditionNamesString = PlayerPrefs.GetString(key);
            string[] conditionNamesArray = conditionNamesString.Split(',');
            conditionNames = new List<string>(conditionNamesArray);
        }
        foreach (string conditionName in conditionNames)
        {
            var script = GetComponent(conditionName) as MonoBehaviour;
            if (script != null)
            {
                conditionsToCheck.Add((Condition)script);
            }
            else
            {
                Debug.LogError("You make mistake in " + conditionName);
            }
        }
    }
    private void LoadDialogs()
    {
        string key = "Dialog_" + gameObject.name;
        if (PlayerPrefs.HasKey(key))
        {
            string dialogsJson = PlayerPrefs.GetString(key);
            dialogData = JsonUtility.FromJson<DialogData>(dialogsJson);
            dialogs = dialogData.Dialog;
        }
        else
        {
            dialogs = DialogList.Dialog;
        }
    }

    private void TriggerDialogue()
    {
        LoadDialogs();
        LoadConditions();
        Dialog choosen = CheckCurrentDialog(dialogs, conditionsToCheck);
        if (choosen != null)
        {
            dialogWindow.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(choosen, needToGiveSomething, LoadNextScene, playNextTimeline, RemoveCurrentDialog, StarMission, SaveDialogs, SaveConditions);
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
