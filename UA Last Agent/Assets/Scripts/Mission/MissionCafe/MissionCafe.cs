using UnityEngine;

public class MissionCafe : Mission
{
    [SerializeField] private GameObject[] activeObjectDuringMission;
    [SerializeField] private string nameMission;
    [SerializeField] private string additionalText;

    public void Awake()
    {
        if (CheckIsMissionFinished(gameObject.name))
        {
            LogicMission();
        }
        if (PlayerPrefs.GetInt(gameObject.name + "Finished", 0) == 1)
        {
            offObjects();
        }

    }
    public override void LogicMission()
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
    public override void EndMission(StartMission gameObject, string name, string main)
    {
        base.EndMission(gameObject, nameMission, additionalText);
        PlayerPrefs.SetInt("Chest_SafeInCafe", 1);
        PlayerPrefs.SetInt("Destroy_TableTrigger", 1);
        offObjects();
        PlayerPrefs.SetInt(gameObject.name + "Finished", 1);
    }
    public void offObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("DeleteAfterMission");
        foreach (var obj in gameObjects)
        {
            if (obj.CompareTag("DeleteAfterMission"))
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
