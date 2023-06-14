using System;
using UnityEngine;
[Serializable]
public class Dialog
{
    [SerializeField] public string[] names;
    [SerializeField] public Sprite[] heads;
    [SerializeField] [TextArea(3, 10)] public string[] sentences;

}
