using UnityEngine;

public class Mission : MonoBehaviour, IMission
{
    public virtual void LogicMission() { }
    public virtual void EndMission() { }
}