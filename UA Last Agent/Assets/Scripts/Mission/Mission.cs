using UnityEngine;

public class Mission : MonoBehaviour, IMission
{
    public virtual void LogicMission() { }
    public virtual void EndMission() { }

    public virtual void UloadSafeMission() { }
    public virtual void SafeMission() { }
    public virtual bool MissionFinished() { return false; }
}