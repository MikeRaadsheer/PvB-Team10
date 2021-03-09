using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopPoints : MonoBehaviour
    {
        [SerializeField]
        private GameObject _confirmWindow;
        [SerializeField]
        private GameObject _confirmButton;
        [SerializeField]
        private GameObject _messageDisplay;
        [SerializeField]
        private GameObject _points;

        private bool _windowOpen = false;
        private PointSystem _pointSystem;
        private ItemSaver _itemSaver;

        private void Start()
        {
            _pointSystem = FindObjectOfType<PointSystem>();
            _itemSaver = FindObjectOfType<ItemSaver>();

            _points.GetComponent<Text>().text = $"{_pointSystem.Get()} punten";
            _pointSystem.Add(2000);
        }

        public void BuyItem(Shop.Hat item)
        {            
            if (item.bought) DisplayMessage("Je hebt dit al gekocht.");
            else if(!_pointSystem.CanBuy(item.price)) DisplayMessage("Je hebt niet genoeg punten.");
            else if (!_windowOpen)
            {
                // show confirmation window
                _confirmWindow.SetActive(true);
                _windowOpen = true;

                _confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                _confirmButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Confirm(item);
                });
            }
        }

        public void Confirm(Shop.Hat item)
        {

            item.bought = true;
            _itemSaver.SaveHat(item);

            _pointSystem.Subtract(item.price);
            _points.GetComponent<Text>().text = $"{_pointSystem.Get()} punten";

            _confirmWindow.SetActive(false);
            _windowOpen = false;
            _confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void Cancel()
        {            
            _confirmWindow.SetActive(false);
            _windowOpen = false;
            _confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void DisplayMessage(string msg)
        {
            if (_windowOpen) return;

            _messageDisplay.transform.Find("Message").GetComponent<Text>().text = msg;
            _messageDisplay.SetActive(true);
            _windowOpen = true;
        }

        public void RemoveDisplayMessage()
        {
            _messageDisplay.SetActive(false);
            _windowOpen = false;
        }

    }
}


