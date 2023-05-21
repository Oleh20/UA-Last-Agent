using UnityEngine;
using UnityEngine.UI;

public class AdaptiveGridLayout : MonoBehaviour
{
    public float cellSizeMultiplier = 1.0f;

    private GridLayoutGroup gridLayout;

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
    }

    private void UpdateCellSize()
    {
        float cellSize = Screen.width * cellSizeMultiplier;
        gridLayout.cellSize = new Vector2(cellSize, cellSize);
    }
}
