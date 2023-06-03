using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private SetPosition setPosition;
    [SerializeField] private Vector2 positionForSave;
    public void setPositionBeforeLoadScene()
    {
        setPosition = GameObject.Find("Fade Out").GetComponent<SetPosition>();
        if (setPosition != null)
        {
            setPosition.savePositionPlayer(positionForSave.x, positionForSave.y);
        }
    }
}
