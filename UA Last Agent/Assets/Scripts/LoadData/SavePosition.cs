using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private SetPosition setPosition;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private Vector2 positionForSave;
    public void setPositionBeforeLoadScene()
    {
        setPosition = GameObject.Find("Fade Out").GetComponent<SetPosition>();
        if (setPosition != null)
        {
            setPosition.savePositionPlayer(positionForSave.x, positionForSave.y);
        }
        setDirectionPlayer();
    }
    private void setDirectionPlayer()
    {
        PlayerPrefs.SetFloat("Horizontal", horizontal);
        PlayerPrefs.SetFloat("Vertical", vertical);
    }
}
