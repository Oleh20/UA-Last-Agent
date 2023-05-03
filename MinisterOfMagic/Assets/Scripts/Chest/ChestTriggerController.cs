using UnityEngine;

public class ChestTriggerController : MonoBehaviour
{
    private ChestController childScript;
    private bool wasOpenBefore = false;

    // Start is called before the first frame update
    void Start()
    {
        childScript = gameObject.GetComponentInChildren<ChestController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!wasOpenBefore)
        {
            childScript.OpenChest();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        wasOpenBefore = true;
        childScript.CloseChest();
    }
}
