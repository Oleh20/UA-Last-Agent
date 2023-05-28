using UnityEngine;

public class Condition : MonoBehaviour
{
    public virtual bool DeleteAfter { get; set; }
    public virtual bool CheckCondition() { return true; }
    public virtual bool FinishMission { get; set; }
}
