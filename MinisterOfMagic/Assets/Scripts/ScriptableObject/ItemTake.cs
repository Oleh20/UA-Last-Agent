using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTake : MonoBehaviour
{
    [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;
    private void Update()
    {
  
    }
    public void TakeItem()
    {
            targetInventory.AddItem(itemToAdd);
    }
}
