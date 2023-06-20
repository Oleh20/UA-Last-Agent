using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Item itemForCheck;
    private GameObject player;
    private GameObject imgWeapon;

    public WeaponsData availableWeapons = new WeaponsData();
    public Weapon currentWeapon;

    private void Start()
    {
        PlayerPrefs.SetInt("DestroyedWeaopon", 0);
        imgWeapon = GameObject.Find("Weapon");
        player = GameObject.FindGameObjectWithTag("Player");

        UploadWeapon();

        if (imgWeapon != null && currentWeapon == null)
        {
            imgWeapon.SetActive(false);
        }

    }

    public void UpdateWeapon()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            if (inventory.HasItem(itemForCheck))
            {
                if (availableWeapons?.WeaponsItems.Count > 0)
                {
                    imgWeapon.GetComponent<Image>().sprite = Resources.Load<Sprite>(availableWeapons.WeaponsItems[0].IconPath);
                    currentWeapon = availableWeapons.WeaponsItems[0];
                    availableWeapons.WeaponsItems.RemoveAt(0);
                    imgWeapon.SetActive(true);
                    inventory.RemoveItem(itemForCheck);
                }
                else
                {
                    if (imgWeapon)
                        imgWeapon.SetActive(false);
                }
            }
        }
    }

    private void SaveWeapon()
    {
        string allWeapon = JsonUtility.ToJson(availableWeapons);
        PlayerPrefs.SetString("availableWeapons", allWeapon);
        string weapon = JsonUtility.ToJson(currentWeapon);
        PlayerPrefs.SetString("currentWeapon", weapon);
    }

    private void UploadWeapon()
    {
        string allWeaponsJson = PlayerPrefs.GetString("availableWeapons");

        WeaponsData tempavailableWeapons = JsonUtility.FromJson<WeaponsData>(allWeaponsJson);
        if(tempavailableWeapons?.WeaponsItems.Count > 0)
        {
            availableWeapons = tempavailableWeapons;
        }
        string currentWeaponJson = PlayerPrefs.GetString("currentWeapon");

        if (currentWeapon == null)
        {
            currentWeapon = ScriptableObject.CreateInstance<Weapon>();
        }
        JsonUtility.FromJsonOverwrite(currentWeaponJson, currentWeapon);


        if (currentWeapon != null && !string.IsNullOrEmpty(currentWeapon.IconPath))
        {
            imgWeapon.GetComponent<Image>().sprite = Resources.Load<Sprite>(currentWeapon.IconPath);
        }
        else
        {
            currentWeapon = null;
            if (imgWeapon)
                imgWeapon.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        if (PlayerPrefs.GetInt("MissionFinished", 0) == 1 && PlayerPrefs.GetInt("DestroyedWeaopon", 0) == 0)
        {
            SaveWeapon();
        }
    }
    private void OnDestroy()
    {
        if (PlayerPrefs.GetInt("MissionFinished", 0) == 1 && PlayerPrefs.GetInt("DestroyedWeaopon", 0) == 0)
        {
            SaveWeapon();
            PlayerPrefs.SetInt("DestroyedWeaopon", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MissionFinished", 1);
        }
    }
}
