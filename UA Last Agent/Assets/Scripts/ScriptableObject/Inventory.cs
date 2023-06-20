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
        PlayerPrefs.SetInt("DestroyedInventory", 0);
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
        if (PlayerPrefs.GetInt("MissionFinished", 0) == 1 && (PlayerPrefs.GetInt("DestroyedInventory", 0) == 0))
        {
            SaveInventory();
        }
    }
    private void OnDestroy()
    {
        if (PlayerPrefs.GetInt("MissionFinished", 0) == 1 && (PlayerPrefs.GetInt("DestroyedInventory", 0) == 0))
        {
            SaveInventory();
            PlayerPrefs.SetInt("DestroyedInventory", 1);
        }
    }

    private void SaveInventory()
    {
        string json = JsonUtility.ToJson(InventoryItems);
        PlayerPrefs.SetString("inventoryItems", json);
    }
}
