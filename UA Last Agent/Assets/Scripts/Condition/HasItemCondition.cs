using UnityEngine;

public class HasItemCondition : Condition
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Item keyItem;

    [SerializeField] private bool deleteAfter;
    public override bool DeleteAfter
    {
        get { return deleteAfter; }
        set { deleteAfter = value; }
    }
    public override bool CheckCondition()
    {
        return inventory.HasItem(keyItem);
    }
}
