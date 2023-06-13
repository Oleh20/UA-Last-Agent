using UnityEngine;
[System.Serializable]
public class Dialog
{
    public string[] names;
    public Sprite[] heads;
    [TextArea(3, 10)] public string[] sentences;

}
