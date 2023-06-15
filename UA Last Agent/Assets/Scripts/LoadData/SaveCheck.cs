using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SaveCheck : MonoBehaviour
{
    
    [SerializeField] private Button continueButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void CheckPosition()
{
    
    
    if (PlayerPrefs.HasKey("SavedPlayerPositionX") != false && PlayerPrefs.HasKey("SavedPlayerPositionY") != false)
    {
        continueButton.gameObject.SetActive(true); 
        buttonText.gameObject.SetActive(true); 
    }
    else
    {
        continueButton.gameObject.SetActive(false); 
        buttonText.gameObject.SetActive(false); 
    }
}

    private void Start()
    {
        CheckPosition();
    }
}
