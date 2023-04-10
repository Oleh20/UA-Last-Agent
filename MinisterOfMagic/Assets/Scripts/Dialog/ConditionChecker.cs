using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    [SerializeField] private bool condition = false;
    [SerializeField] private bool giveSomething = false;
    [SerializeField] private Inventory inventoryUser;
    [SerializeField] private Item itemToAdd;

    public void CheckCondition()
    {
        if (condition && giveSomething)
        {
            inventoryUser.AddItem(itemToAdd);
        }
    }
}
