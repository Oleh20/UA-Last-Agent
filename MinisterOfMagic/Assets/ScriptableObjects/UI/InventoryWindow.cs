using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;

    readonly List<GameObject> drawIcons = new List<GameObject>();    
    // Start is called before the first frame update
    private void Start()
    {
        targetInventory.OnItemAdded += OnItemAdded;
        Redraw();
    }
    private void OnItemAdded(Item obj) => Redraw();

    private void Redraw()
    {
        ClearDrawn();
        for (var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems[i];
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;
            icon.transform.SetParent(itemsPanel);

            drawIcons.Add(icon);
        }
    }
    private void ClearDrawn()
    {
        for (var i = 0; i < drawIcons.Count; i++)
        {
            Destroy(drawIcons[i]);
        }
        drawIcons.Clear();
    }
}
