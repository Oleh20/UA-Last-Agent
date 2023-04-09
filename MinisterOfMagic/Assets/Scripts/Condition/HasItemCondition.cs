using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItemCondition : Condition
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Item keyItem;

    public override bool CheckCondition()
    {
        return inventory.HasItem(keyItem);
    }
}
