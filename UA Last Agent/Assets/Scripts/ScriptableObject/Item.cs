﻿using System;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "Tutorial/Item")]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;
}