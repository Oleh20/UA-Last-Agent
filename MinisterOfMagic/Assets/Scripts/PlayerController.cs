using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField] private Item itemForThrow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.InventoryItems.Contains(itemForThrow))
            {
                inventory.RemoveItem(itemForThrow);

                Debug.Log("Ви викинули ключ.");
            }
            else
            {
                Debug.Log("У вас немає ключа в інвентарі.");
            }
        }
    }
}
