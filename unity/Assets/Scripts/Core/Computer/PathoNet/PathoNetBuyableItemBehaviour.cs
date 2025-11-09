using Core.Interaction;
using Core.Item;
using Core.Money;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Core.Computer.PathoNet
{
    public class PathoNetBuyableItemBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public Image itemImage;
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI itemPrice;
        private Item.Item itemData;
        private PathoNetItemReceiver pathoNetItemReceiver;

        public void Setup(Item.Item item, PathoNetItemReceiver itemReceiver)
        {
            itemData = item;
            
            pathoNetItemReceiver = itemReceiver;
            
            if (itemImage != null)
                itemImage.sprite = item.itemIcon;

            if (itemName != null)
                itemName.text = item.itemName;

            if (itemPrice != null)
                itemPrice.text = "$" + item.price;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Buy();
        }

        private void Buy()
        {
            if (pathoNetItemReceiver.CanAddItem() && MoneyController.Instance.CanRemoveMoney(itemData.price))
            {
                Debug.Log("Acheté : " + itemData.itemName);
                MoneyController.Instance.RemoveMoney(itemData.price);
                pathoNetItemReceiver.AddItem(new HoldItem(itemData));
            }
            else
            {
                Debug.Log("Ne peut pas acheté : " + itemData.itemName);
            }
        }
    }
}