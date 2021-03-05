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
        private Shop.Hat testItem;
        public void TestBuy()
        {
            BuyItem(testItem);
        }

        public void BuyItem(Shop.Hat item)
        {
            int points;
            // check if user has enough points
            points = PointSystem.Get();

            if (!PointSystem.CanBuy(item.price)) DisplayMessage("Je hebt niet genoeg punten om dit te kopen.");
            else if (item.bought) DisplayMessage("Je hebt dit al gekocht.");
            else
            {
                // show confirmation window
                _confirmWindow.SetActive(true);

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
            PointSystem.Subtract(item.price);

            _confirmWindow.SetActive(false);
            _confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void Cancel()
        {            
            _confirmWindow.SetActive(false);
            _confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void DisplayMessage(string msg)
        {
            _messageDisplay.transform.Find("Message").GetComponent<Text>().text = msg;
            _messageDisplay.SetActive(true);
        }

        public void RemoveDisplayMessage()
        {
            _messageDisplay.SetActive(false);
        }

    }
}


