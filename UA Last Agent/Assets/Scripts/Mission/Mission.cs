using UnityEngine;

public class Mission : MonoBehaviour, IMission
{
    public virtual void LogicMission() { }
    public virtual void EndMission(StartMission mission, string name = null, string main = null) 
    {
        mission.ShowText(name, main);
    }

    public bool CheckIsMissionFinished(string nameObject)
    {
        if (PlayerPrefs.HasKey(nameObject + "_Finished"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}