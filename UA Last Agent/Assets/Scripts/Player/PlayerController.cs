using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ChangeGoal changeGoal;
    private PlayerWeapon playerWeapon;

    [SerializeField] private Inventory inventory;

    [SerializeField] private float throwForce = 0;
    [SerializeField] private Item itemForThrow;
    [SerializeField] private GameObject itemApperOnMap;

    [SerializeField] private TopDownCharacterController topDownCharacterController;
    [SerializeField] private TextMeshProUGUI currentColliderText;

    public GameObject transitionObjectScene;


    private void Start()
    {
        changeGoal = GetComponent<ChangeGoal>();
        LoadText();
    }
    private void Update()
    {
        throwObject();
    }
    private void throwObject()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventory.InventoryItems.InventoryItems.Contains(itemForThrow))
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

    public void LoadText()
    {
        if (currentColliderText != null)
        {
            string savedText = PlayerPrefs.GetString("NameRegion", "Я незнаю де я");
            currentColliderText.text = savedText;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Region"))
        {
            currentColliderText.text = other.name;
            string textValue = currentColliderText.text;
            PlayerPrefs.SetString("NameRegion", textValue);
        }
        if (other.CompareTag("TableCraft"))
        {
            playerWeapon = gameObject.GetComponent<PlayerWeapon>();
            if (playerWeapon != null)
            {
                playerWeapon.UpdateWeapon();
            }
        }
        if (other.CompareTag("DoorOpen"))
        {
            other.GetComponent<SavePosition>()?.setPositionBeforeLoadScene();
            transitionObjectScene.SetActive(true);
        }

    }
}
