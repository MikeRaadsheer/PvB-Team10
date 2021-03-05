using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopItemButton : MonoBehaviour
{
    [SerializeField] private Shop.Hat _currentHat;
    [SerializeField] private GameObject _shop;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener( ()=> 
            {
                _shop.GetComponent<ShopPoints>().BuyItem(_currentHat);
            }); 
    }

}
