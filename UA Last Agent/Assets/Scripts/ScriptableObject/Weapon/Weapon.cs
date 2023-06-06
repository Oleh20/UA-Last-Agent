using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "Tutorial/Weapon")]
public class Weapon : ScriptableObject
{
    public string Name;
    public string IconPath;
    public int Speed;
    public bool canAtackAutomaticaly;

    [NonSerialized] 
    public Sprite Icon;
}
