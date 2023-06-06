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
        targetInventory.OnItemChange += OnItemAdded;
        targetInventory.OnItemStart = OnItemStart;
        Redraw();
    }
    private void OnItemAdded(Item obj) => Redraw();
    private void OnItemStart(InventoryData obj) => Redraw();

    private void Redraw()
    {
        ClearDrawn();
        for (var i = 0; i < targetInventory.InventoryItems.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems.InventoryItems[i];
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = Resources.Load<Sprite>(item.IconPath);
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
