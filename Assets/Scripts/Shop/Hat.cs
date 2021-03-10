using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Hat", menuName = "ShopItems/Hat", order = 1)]
    public class Hat : ScriptableObject
    {
        // Main variables
        public string hatName;
        public GameObject model;

        // Shop variables
        public Sprite thumbnail;
        public int price;
        public bool bought;
    }
}
