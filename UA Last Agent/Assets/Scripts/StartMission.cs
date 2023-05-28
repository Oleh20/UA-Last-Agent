using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMission : MonoBehaviour
{
    [SerializeField] private string nameMission;
    [SerializeField] private string nameRegion;
    [SerializeField] private GameObject textMission;
    [SerializeField] private GameObject textStartMission;
    [SerializeField] private Mission mission;

    // Start is called before the first frame update
    void Start()
    {
        //textMission.SetActive(false);
        //textStartMission.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCurrentMision()
    {
        TextMeshProUGUI nameOfMission = textMission.GetComponent<TextMeshProUGUI>();
        nameOfMission.text = nameMission;
        textMission.SetActive(true);
        textStartMission.SetActive(true);
        mission.LogicMission();

    }
}
