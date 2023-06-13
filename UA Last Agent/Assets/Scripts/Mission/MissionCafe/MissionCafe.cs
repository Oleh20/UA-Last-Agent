using UnityEngine;

public class MissionCafe : Mission
{
    [SerializeField] private GameObject[] activeObjectDuringMission;

    public override void LogicMission()
    {
        if(PlayerPrefs.GetInt("MissionStarted", 0) != 0)
        {
            UloadSafeMission();
        }
        else
        {
            foreach (var obj in activeObjectDuringMission)
            {
                if (obj.CompareTag("OffInMission"))
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            }
        }
    }
    public override void UloadSafeMission()
    {
        
    }
    private void OnApplicationQuit()
    {
        SafeMission();
    }
    public override void SafeMission()
    {

    }
    public override bool MissionFinished()
    {
        return base.MissionFinished();
    }


}
