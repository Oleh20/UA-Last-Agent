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

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        heads = new Queue<Sprite>();
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    public void StartDialogue(Dialog dialog)
    {
        dialogWindow = GameObject.Find("Canvas");

        // очистимо черги перед початком нового діалогу
        sentences.Clear();
        names.Clear();
        heads.Clear();

        // додамо всі речення, імена та голови відповідно до їх порядку в Dialog
        for (int i = 0; i < dialog.sentences.Length; i++)
        {
            sentences.Enqueue(dialog.sentences[i]);
            names.Enqueue(dialog.names[i]);
            heads.Enqueue(dialog.heads[i]);
        }

        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        // перевіряємо, чи закінчилися речення
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // беремо наступне речення, ім'я та голову
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Sprite head = heads.Dequeue();

        // запускаємо корутину з виведенням речення посимвольно
        StartCoroutine(TypeSentence(sentence, name, head));
    }

    IEnumerator TypeSentence(string sentence, string name, Sprite head)
    {
        dialogText.text = "";
        nameText.text = name;
        headImage.sprite = head;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        dialogWindow.SetActive(false);
    }
}
