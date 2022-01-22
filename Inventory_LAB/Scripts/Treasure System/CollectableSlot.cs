using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSlot : MonoBehaviour
{   
    public Text textnya;
    public Button buttonnya;
    [SerializeField] Item item;
    [SerializeField] treasurescript TargetTreasure;
    int index;

    public void ItemAdded(Item newItem, treasurescript _targetTreasure, int i)
    {
        if(newItem == null)
        {
            item = null;
            textnya.text = null;
            buttonnya.interactable = false;
            TargetTreasure = null;
            index = 0;
        }else
        {
            item = newItem;
            textnya.text = item.name;
            buttonnya.interactable = true;
            TargetTreasure = _targetTreasure;
            index = i;
        }
        
    }

    public void ItemCollected()
    {
        if(Inventory.instance.Add(item))
        {
            if (item.name == "Armor")
            {
                Debug.Log("Armor didapatkan");
                GameObject.Find("Player").GetComponent<HealthSystem>().armorHealth += 30;
            }
            if (item.name == "Celana")
            {
                GameObject.Find("Player").GetComponent<HealthSystem>().armorHealth += 20;
            }
            if (item.name == "Helm")
            {
                GameObject.Find("Player").GetComponent<HealthSystem>().armorHealth += 40;
            }
            if (item.name == "Sepatu")
            {
                GameObject.Find("Player").GetComponent<HealthSystem>().armorHealth += 10;
            }

            TargetTreasure.collectable[index] = null;
            Debug.Log(item.name + " collected.");
            item = null;
            textnya.text = null;
            buttonnya.interactable = false;
            index = 0;
        }
        
    }
}