using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action <Item> OnItemAdded;
    [SerializeField] List<Item> StartItems = new List<Item>();

    public List<Item> InventoryItems = new List<Item>();

    private void Start()
    {
        for (int i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }
    public void AddItem(Item item)
    {
        InventoryItems.Add(item);
        OnItemAdded?.Invoke(item);
    }
    public bool HasItem(Item item)
    {
        return InventoryItems.Contains(item);
    }
}
