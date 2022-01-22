using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake() {
        if(instance != null)
        {
            Debug.LogWarning("Inventory Lebih Dari 1!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int space = 10;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.LogWarning("Not Enough Space!");
            return false;
        }
        
        items.Add(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
