using System;
using System.Collections.Generic;

[Serializable]
public class Items
{
    public List<Item> hats = new List<Item>();

    public void AddHat(Item item)
    {
        hats.Add(item);
    }

    public List<Item> GetHats()
    {
        return hats;
    }
    
    public Item GetHat(string item)
    {
        for (int i = 0; i < hats.Count; i++)
        {
            if(hats[i].name == item)
            {
                return hats[i];
            }
        }
        throw new Exception("Could not find item, please make sure that the specified item exists and that the spelling is correct.");
    }

}
