using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    private int sortingOrderBase = 0;
    private Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        rend.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset);
    }
}
