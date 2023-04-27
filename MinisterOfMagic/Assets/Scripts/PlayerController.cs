using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ChangeGoal changeGoal;

    [SerializeField] private Inventory inventory;

    [SerializeField] private float throwForce = 0;
    [SerializeField] private Item itemForThrow;
    [SerializeField] private GameObject itemApperOnMap;
   
    [SerializeField] private TopDownCharacterController topDownCharacterController;
    [SerializeField] private TextMeshProUGUI currentColliderText;

    private void Start()
    {
     
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
                Vector2 throwDirection = new Vector2(topDownCharacterController.horizontal, topDownCharacterController.vertical).normalized;
                Rigidbody2D throwableObjectRb = itemApperOnMap.GetComponent<Rigidbody2D>();
                throwableObjectRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
                changeGoal.changeGoal();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentColliderText.text = other.name;
    }
}
