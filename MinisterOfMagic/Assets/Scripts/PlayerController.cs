using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField] private float throwForce = 0;
    [SerializeField] private Item itemForThrow;
    [SerializeField] private GameObject itemApperOnMap;
   
    [SerializeField] private TopDownCharacterController topDownCharacterController;

    private void Start()
    {
        itemApperOnMap.SetActive(false);
    }
    private void Update()
    {
        throwObject();
    }
    private void throwObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.InventoryItems.Contains(itemForThrow))
            {
                inventory.RemoveItem(itemForThrow);
                itemApperOnMap.SetActive(true);
                itemApperOnMap.transform.position = transform.position;
                Debug.Log(topDownCharacterController.horizontal);
                Debug.Log(topDownCharacterController.vertical);
                Vector2 throwDirection = new Vector2(topDownCharacterController.horizontal, topDownCharacterController.vertical).normalized;
                Rigidbody2D throwableObjectRb = itemApperOnMap.GetComponent<Rigidbody2D>();
                throwableObjectRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

            }
        }
    }
}
