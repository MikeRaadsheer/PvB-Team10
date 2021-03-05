using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Custom namespaces
using Shop;

public class ShopItemButton : MonoBehaviour
{
    [SerializeField] private Hat _currentHat;
    [SerializeField] private GameObject _shop;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener( ()=> 
            {
                //if(!_currentHat.bought)
                _shop.GetComponent<ShopPoints>().BuyItem(_currentHat);
            });

        // Get child text gameobject and set price
        //if(_currentHat.bought) this.transform.Find("Price").GetComponent<Text>().text = "Al gekocht.";
        //else
        this.transform.Find("Price").GetComponent<Text>().text = $"{_currentHat.price} punten";

    }

}
