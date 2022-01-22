using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureContentUI : MonoBehaviour
{
    [SerializeField] GameObject ContentParent;
    CollectableSlot[] slotCollectable;

    void Start()
    {
        slotCollectable = ContentParent.GetComponentsInChildren<CollectableSlot>();
        ContentParent.SetActive(false); 
    }

    public void isiTreasure(treasurescript _Hartakarun)
    {
        for (var i = 0; i < slotCollectable.Length; i++)
        {
            try
            {
                slotCollectable[i].ItemAdded(_Hartakarun.collectable[i], _Hartakarun, i);                
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Debug.Log("Item Habis!");
            }
        }
    }
    
    public void setTreasure(GameObject _TreasureNya)
    {
        if(_TreasureNya != null)
        {
            treasurescript _TS = _TreasureNya.GetComponent<treasurescript>();
            isiTreasure(_TS);
            ContentParent.SetActive(true); 
        }else ContentParent.SetActive(false);
        
    }
}
