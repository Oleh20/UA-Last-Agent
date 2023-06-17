using UnityEngine;

public class ChestTriggerController : MonoBehaviour
{
    private ChestController childScript;
    [SerializeField] private bool wasOpenBefore = false;
    private string chestKey;

    // Start is called before the first frame update
    void Start()
    {
        childScript = gameObject.GetComponentInChildren<ChestController>();
        chestKey = "Chest_" + gameObject.name;
        wasOpenBefore = PlayerPrefs.GetInt(chestKey, 0) == 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!wasOpenBefore)
        {
            childScript.OpenChest();
            wasOpenBefore = true;
            if(PlayerPrefs.GetInt("MissionFinished", 0) == 1)
            {
                PlayerPrefs.SetInt(chestKey, 1);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        childScript.CloseChest();
    }
}
