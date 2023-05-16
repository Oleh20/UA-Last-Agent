using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionKrim : Mission
{
    private Rigidbody rb;
    [SerializeField] private GameObject[] allBomb;

    private void Start()
    {

    }


    public override void LogicMission()
    {
        foreach (GameObject bomb in allBomb)
        {
            Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
