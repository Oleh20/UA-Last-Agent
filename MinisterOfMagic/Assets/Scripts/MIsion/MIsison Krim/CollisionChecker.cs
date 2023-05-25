using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private FinishMissionCondition finishMissionCondition;

    public GameObject bombZone1;
    public GameObject bombZone2;
    public GameObject bombZone3;

    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;

    private bool bomb1InsideZone = false;
    private bool bomb2InsideZone = false;
    private bool bomb3InsideZone = false;

    private void Update()
    {
        CheckCollision(bomb1, bombZone1, ref bomb1InsideZone);
        CheckCollision(bomb2, bombZone2, ref bomb2InsideZone);
        CheckCollision(bomb3, bombZone3, ref bomb3InsideZone);

        if (bomb1InsideZone && bomb2InsideZone && bomb3InsideZone)
        {
            finishMissionCondition.endMission =true;
        }
    }

    private void CheckCollision(GameObject bomb, GameObject bombZone, ref bool bombInsideZone)
    {
        if (bomb != null && bombZone != null)
        {
            Collider2D bombCollider = bomb.GetComponent<Collider2D>();
            Collider2D zoneCollider = bombZone.GetComponent<Collider2D>();

            if (bombCollider != null && zoneCollider != null)
            {
                Bounds bombBounds = bombCollider.bounds;
                Bounds zoneBounds = zoneCollider.bounds;

                if (zoneBounds.Contains(bombBounds.min) && zoneBounds.Contains(bombBounds.max))
                {
                    bombInsideZone = true;
                }
                else
                {
                    bombInsideZone = false;
                }
            }
        }
    }
}
