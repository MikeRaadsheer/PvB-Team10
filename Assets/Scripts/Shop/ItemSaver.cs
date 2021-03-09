using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaver : MonoBehaviour
{
    private ReadData _load;
    private WriteData _save;

    void Start()
    {
        _load = FindObjectOfType<ReadData>();
        _save = FindObjectOfType<WriteData>();
    }

    public void SaveHat(Shop.Hat hat)
    {
        Items items = (Items)_load.Load<Items>("items");
        items.GetHat(hat.hatName).isBought = hat.bought;
        items.GetHat(hat.hatName).price = hat.price;
        _save.Save<Items>(items, "items");
    }

    public Item GetHat(string name)
    {
        Items items = (Items) _load.Load<Items>("items");
        return items.GetHat(name);
    }
}
