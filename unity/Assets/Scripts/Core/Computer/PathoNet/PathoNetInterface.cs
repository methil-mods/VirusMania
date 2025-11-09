using Core.Interaction;
using UnityEngine;
using Core.Item;

namespace Core.Computer.PathoNet
{
    public class PathoNetInterface : MonoBehaviour
    {
        public GameObject pathoBuyableItemPrefab;
        public Transform pathoBuyableItemContainer;
        [SerializeField] private PathoNetItemReceiver pathoItemReceiver;

        protected void Start()
        {
            foreach (var item in ItemDatabase.Instance.BuyableItems)
            {
                GameObject go = Instantiate(pathoBuyableItemPrefab, pathoBuyableItemContainer);
                var buyableBehaviour = go.GetComponent<PathoNetBuyableItemBehaviour>();
                if (buyableBehaviour != null)
                    buyableBehaviour.Setup(item, pathoItemReceiver);
            }
        }
    }
}