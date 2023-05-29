using TMPro;
using UnityEngine;

public class StartMission : MonoBehaviour
{
    public int AfterDialogStartMission;

    [SerializeField] private string nameMission;
    [SerializeField] private string nameRegion;
    [SerializeField] private GameObject textMission;
    [SerializeField] private GameObject textStartMission;
    [SerializeField] private Mission mission;

    public void StartCurrentMision()
    {
        TextMeshProUGUI nameOfMission = textMission.GetComponent<TextMeshProUGUI>();
        nameOfMission.text = nameMission;
        textMission.SetActive(true);
        textStartMission.SetActive(true);
        mission.LogicMission();
    }
}
