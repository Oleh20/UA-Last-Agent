using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "Tutorial/Item")]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;

    public bool IsInInventory { get; set; }

    private void OnEnable()
    {
        // При створенні об'єкту IsInInventory встановлюється на false
        IsInInventory = false;
    }
}
