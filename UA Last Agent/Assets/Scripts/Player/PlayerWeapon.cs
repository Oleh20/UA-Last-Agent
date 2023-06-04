using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Item itemForCheck;
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private List<Weapon> availableWeapons = new List<Weapon>();
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdateWeapon()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            if (inventory.HasItem(itemForCheck))
            {
                GameObject imgWeapon = GameObject.Find("Weapon");
                imgWeapon.GetComponent<Image>().sprite = currentWeapon.Icon;
            }
        }
        else
        {
            Debug.LogError("Missing inventory");
        }
    }
}
