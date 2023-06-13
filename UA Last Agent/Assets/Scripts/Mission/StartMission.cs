using TMPro;
using UnityEngine;

public class StartMission : MonoBehaviour
{

    [SerializeField] private string nameMission;
    [SerializeField] private string additionalText;
    [SerializeField] private GameObject textMission;
    [SerializeField] private GameObject textStartMission;
    [SerializeField] private Mission mission;
    private string nameRegion;


    public Item itemForMission;
     public Item itemAfterMission;
    public void StartCurrentMision()
    {
        TextMeshProUGUI nameOfMission = textMission.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI additionalText = textStartMission.GetComponent<TextMeshProUGUI>();
        nameOfMission.text = nameMission;
        additionalText.text = this.additionalText;
        textMission.SetActive(true);
        textStartMission.SetActive(true);
        if (mission != null )
        {
            mission.LogicMission();
        }
        else
        {
            Debug.LogError("Please add mission");
        }
       
    }
    public void EndCurrentMission()
    {
        mission.EndMission();
    }
}
