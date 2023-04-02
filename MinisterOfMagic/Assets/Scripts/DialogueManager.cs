using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private Image HeadImage;
    [SerializeField] private Queue <string> sentences;
    [SerializeField] private Queue <string> _name;
    [SerializeField] private Queue <Sprite> _head;
    [SerializeField] private GameObject dialogWindow;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue <string> ();
        _name = new Queue <string> ();
        _head = new Queue <Sprite> ();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDialogue(Dialog dialog)
    {
        sentences.Clear();
        _name.Clear();
        _head.Clear();

        foreach (string name in dialog._name)
        {
            _name.Enqueue(name);
        }
        foreach (Sprite headSprite in dialog.head)
        {
            _head.Enqueue(headSprite);
        }
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentaces();
    }
    public void DisplayNextSentaces()
    {
        string sentence = sentences.Dequeue();
        string name = _name.Dequeue();
        Sprite head = _head.Dequeue();
        StartCoroutine(TypeSentences(sentence, name,head));
    }
    IEnumerator TypeSentences(string sentence, string name, Sprite head)
    {
        DialogText.text = "";
        NameText.text = name;
        HeadImage.sprite = head;
        foreach(char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        dialogWindow.SetActive(false);
    }
}
