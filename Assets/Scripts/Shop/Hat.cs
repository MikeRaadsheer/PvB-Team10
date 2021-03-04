using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Hat", menuName = "ShopItems/Hat", order = 1)]
    public class Hat : ScriptableObject
    {
        // Main variables
        public string hatName;
        public Mesh model;

        // Shop variables
        public int price;
        public bool bought;
    }
}
