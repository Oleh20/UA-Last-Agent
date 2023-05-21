using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    [SerializeField] private bool condition = false;
    [SerializeField] private bool giveSomething = false;
    [SerializeField] private Item itemToAdd;
    private Inventory inventoryUser;

    private void Start()
    {
        inventoryUser = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void CheckCondition()
    {
        if (condition && giveSomething)
        {
            inventoryUser.AddItem(itemToAdd);
        }
    }
}
