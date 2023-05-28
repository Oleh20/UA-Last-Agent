using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image headImage;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> heads;

    private GameObject dialogWindow;

    private System.Action dialogueCallback;
    private System.Action nextSceneCallback;
    private System.Action nextTimeLineCallback;
    private System.Action removeDialogCallback;

    private System.Action startMissionCallback;

    private Coroutine typingCoroutine;

    private string currentSentence;
    
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        heads = new Queue<Sprite>();
    }

    public void StartDialogue(Dialog dialog, System.Action callback = null, System.Action nextScene = null, System.Action nextTimeLine = null, System.Action removeDialog = null, System.Action startMission = null)
    {
        dialogWindow = GameObject.Find("Dialog");
        sentences.Clear();
        names.Clear();
        heads.Clear();

        for (int i = 0; i < dialog.sentences.Length; i++)
        {
            sentences.Enqueue(dialog.sentences[i]);
            names.Enqueue(dialog.names[i]);
            heads.Enqueue(dialog.heads[i]);
        }

        DisplayNextSentences();
        dialogueCallback = callback;
        nextSceneCallback = nextScene;
        nextTimeLineCallback = nextTimeLine;
        removeDialogCallback = removeDialog;
        startMissionCallback = startMission;

    }

    public void DisplayNextSentences()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            dialogText.text = currentSentence;
            typingCoroutine = null;
            return;
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Sprite head = heads.Dequeue();

        typingCoroutine =  StartCoroutine(TypeSentence(sentence, name, head));
    }

    IEnumerator TypeSentence(string sentence, string name, Sprite head)
    {
        currentSentence = sentence;
        dialogText.text = "";
        nameText.text = name;
        headImage.sprite = head;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
        typingCoroutine = null;
    }

    private void EndDialogue()
    {
        dialogWindow.SetActive(false);
        if (dialogueCallback != null) dialogueCallback();
        if (nextSceneCallback != null) nextSceneCallback();
        if (nextTimeLineCallback != null) nextTimeLineCallback();
        if (removeDialogCallback != null) removeDialogCallback();
        if (startMissionCallback != null) startMissionCallback();
    }

}
