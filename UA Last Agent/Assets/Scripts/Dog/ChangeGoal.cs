using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGoal : MonoBehaviour
{
    [SerializeField] private AIDestinationSetter destinationSetter;
    [SerializeField] private AIPath aIPath;
    [SerializeField] private GameObject goal;
    [SerializeField] private Inventory player;
    [SerializeField] private Item itemForAdd;

    private bool hasObject = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeGoal()
    {
        aIPath.maxSpeed= 3.2f;
        aIPath.endReachedDistance = 0f;
        destinationSetter.target = goal.transform;
    }
    private void ReturnToPlayer(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal") && !hasObject)
        {
            hasObject= true;
            goal.SetActive(false);
            destinationSetter.target = player.transform;
        }
        if (other.gameObject.CompareTag("Player") && hasObject)
        {
            aIPath.maxSpeed = 2.0f;
            hasObject = false;
            player.AddItem(itemForAdd);
            aIPath.endReachedDistance = 2.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ReturnToPlayer(other);
    }
}
