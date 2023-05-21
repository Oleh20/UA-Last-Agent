using UnityEngine;

public class NoneCondition : Condition
{
    [SerializeField]
    private bool deleteAfter;
    public override bool DeleteAfter
    {
        get { return deleteAfter; }
        set { deleteAfter = value; }
    }
    public override bool CheckCondition()
    {
        return false;
    }
}
