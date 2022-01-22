using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "new item";
    public Sprite icon = null;
    private bool torchStatus = false;

    public virtual void Use()
    {
        //kalo pake ngapain tiap item

        Debug.Log("Using " + name);
        if (name == "Torch")
        {
            torchStatus = !torchStatus;
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Torch");

            foreach (GameObject go in gameObjectArray)
            {
                if (torchStatus)
                {
                    go.transform.localPosition = new Vector3(0, 100, 0);
                } else
                {
                    go.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
        }
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
        Debug.Log(this);
    }
}
