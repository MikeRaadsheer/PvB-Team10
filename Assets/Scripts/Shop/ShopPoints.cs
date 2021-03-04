using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopPoints : MonoBehaviour
    {
        [SerializeField]
        private GameObject confirmWindow;
        [SerializeField]
        private GameObject confirmButton;

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
                confirmWindow.SetActive(true);

                confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
                confirmButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Confirm(item);
                });
            }
        }

        public void Confirm(Shop.Hat item)
        {
            item.bought = true;
            PointSystem.Subtract(item.price);

            confirmWindow.SetActive(false);
            confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void Cancel()
        {            
            confirmWindow.SetActive(false);
            confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void DisplayMessage(string msg)
        {
            Debug.LogError(msg);
            // change Text text

            // show message

        }

    }
}


