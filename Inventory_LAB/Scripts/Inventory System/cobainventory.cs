using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobainventory : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]Item itemA;
    [SerializeField]Item itemB;
    
    void Start()
    {
        Inventory.instance.Add(itemA);
        Inventory.instance.Add(itemB);


        Inventory.instance.Remove(itemA);
    }


}
