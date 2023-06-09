﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionKrim : Mission
{
    [SerializeField] private GameObject[] allBomb;
    [SerializeField] private GameObject[] BombZone;

    public override void LogicMission()
    {
        GameObject parentObject = GameObject.Find("TriggerBomb");


        if (parentObject != null)
        {

            int childCount = parentObject.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {

                GameObject childObject = parentObject.transform.GetChild(i).gameObject;

            }
        }

        foreach (GameObject bomb in allBomb)
        {
            Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        foreach (GameObject obj in BombZone)
        {
            obj.SetActive(true);
        }

    }



}
