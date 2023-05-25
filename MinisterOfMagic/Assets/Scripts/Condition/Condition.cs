using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public virtual bool CheckCondition() { return true; }
    public virtual bool FinishMission { get; set; }
}
