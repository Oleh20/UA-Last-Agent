using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<Item> OnItemChange;
    public Action<InventoryData> OnItemStart;

    public InventoryData InventoryItems = new InventoryData();

    private void Start()
    {
        string json = PlayerPrefs.GetString("inventoryItems");
        if (!string.IsNullOrEmpty(json))
        {
            InventoryItems = JsonUtility.FromJson<InventoryData>(json);
            OnItemStart?.Invoke(InventoryItems);
        }
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            InventoryItems.InventoryItems.Add(item);
            OnItemChange?.Invoke(item);
            SaveInventory();
        }

    }

    public bool HasItem(Item item)
    {
        return InventoryItems.InventoryItems.Contains(item);
    }

    public void RemoveItem(Item item)
    {
        InventoryItems.InventoryItems.Remove(item);
        OnItemChange?.Invoke(item);
        SaveInventory();
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }

    private void SaveInventory()
    {
        string json = JsonUtility.ToJson(InventoryItems);
        PlayerPrefs.SetString("inventoryItems", json);
    }
}
