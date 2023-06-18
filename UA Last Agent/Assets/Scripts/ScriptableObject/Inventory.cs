using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<Item> OnItemChange;
    public Action<InventoryData> OnItemStart;

    public InventoryData InventoryItems = new InventoryData();

    [SerializeField] private GameObject letter;

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
        if (item != null && item.name != "List")
        {
            InventoryItems.InventoryItems.Add(item);
            OnItemChange?.Invoke(item);
        }
        else if (item != null && item.name == "List")
        {
            letter.SetActive(true);
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
    }

    private void OnApplicationQuit()
    {
        if (PlayerPrefs.GetInt("MissionFinished", 0) == 1)
        {
            SaveInventory();
        }
    }

    private void SaveInventory()
    {
        string json = JsonUtility.ToJson(InventoryItems);
        PlayerPrefs.SetString("inventoryItems", json);
    }
}
