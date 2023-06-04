using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "Tutorial/Weapon")]
public class Weapon : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public int Speed;
    public bool canAtackAutomaticaly;

}
