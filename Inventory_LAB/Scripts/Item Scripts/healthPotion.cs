using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/HP-Potion")]
public class healthPotion : Item
{
    public float healingAmount;
    public GameObject player;


    public override void Use()
    {
        base.Use();
        //tambah darah
        player = GameObject.Find("Player");
        player.GetComponent<HealthSystem>().playerHealth += healingAmount;
        SoundManager.PlaySound("Health");
        //kurangin dari inventory
        RemoveFromInventory();

        player.GetComponent<HealthSystem>().particleStatus = true;
    }
}