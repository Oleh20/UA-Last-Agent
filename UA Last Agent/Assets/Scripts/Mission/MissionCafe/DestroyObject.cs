using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Item itemForCheck;
    [SerializeField] private string destroyWithTag;
    [SerializeField] private bool wasDestroyed = false;
    private string key;
    void Start()
    {
        key = "Destroy_" + gameObject.name;
        wasDestroyed = PlayerPrefs.GetInt(key, 0) == 1;
        if(wasDestroyed)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag(destroyWithTag))
        {
            if (inventory.HasItem(itemForCheck))
            {
                wasDestroyed = true;
                PlayerPrefs.SetInt(key, 1);
                gameObject.SetActive(false);
            }
        }
    }
}
