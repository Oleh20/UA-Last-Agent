using TMPro;
using UnityEngine;

public class StartMission : MonoBehaviour
{

    [SerializeField] private string nameMission;
    [SerializeField] private string additionalText;
    [SerializeField] private GameObject textMission;
    [SerializeField] private GameObject textStartMission;
    public Mission mission;
    private string nameRegion;
    private TextMeshProUGUI nameOfMission;
    private TextMeshProUGUI secondText;

    public Item itemForMission;
    public Item itemAfterMission;

    private void Start()
    {
        nameOfMission = textMission.GetComponent<TextMeshProUGUI>();
        secondText = textStartMission.GetComponent<TextMeshProUGUI>();
    }
    public void ShowText(string name = null, string main = null)
    {

        if (name != null && name.Length > 0 && main != null && main.Length > 0)
        {
            nameOfMission.text = name;
            secondText.text = main;
        }
        else
        {
            nameOfMission.text = nameMission;
            secondText.text = additionalText;
        }
        textMission.SetActive(true);
        textStartMission.SetActive(true);
    }
    public void StartCurrentMision()
    {
        ShowText();
        if (mission != null)
        {
            mission.LogicMission();
        }
        else
        {
            Debug.LogError("Please add mission");
        }

    }
}
