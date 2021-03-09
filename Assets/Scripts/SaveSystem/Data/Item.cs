using System;

[Serializable]
public class Item
{
    public string name = "Item";  // Name for an item (e.g. 'Top Hat').
    public int price = 100;       // Price for an item is 100by default but can be changed in the inspector.
    public bool isBought = false; // Bool to see if an item has been purchased and can be used.

    public Item(string _name, int _price, bool _isBought)
    {
        this.name = _name;
        this.price = _price;
        this.isBought = _isBought;
    }
}
