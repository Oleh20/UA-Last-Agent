using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTake : MonoBehaviour
{
    [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            targetInventory.AddItem(itemToAdd);
        }
    }
}
