using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Sprite IconOpenChest;
    [SerializeField] private Sprite IconCloseChest;

    private SpriteRenderer chestImage;

    [SerializeField] private List<Item> ChestItems = new List<Item>();

    private Inventory inventory;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        chestImage = GetComponent<SpriteRenderer>();
    }
    public void OpenChest()
    {
        chestImage.sprite = IconOpenChest;
        foreach (Item item in ChestItems)
        {

            inventory.AddItem(item);
        }
        ChestItems.Clear();
    }
    public void CloseChest()
    {
        chestImage.sprite = IconCloseChest;
    }

}
