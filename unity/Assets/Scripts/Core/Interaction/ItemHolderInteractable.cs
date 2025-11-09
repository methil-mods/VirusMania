using System;
using System.Collections.Generic;
using Core.Item;
using Core.Player;
using Framework.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Interaction
{
    public class ItemHolderInteractable : MonoBehaviour, IInteractable
    {
        [Header("Configuration")]
        [SerializeField] protected int maxHoldableItems = 3;
        [SerializeField] protected List<Item.Item> startItems;
        [SerializeField] protected Transform itemParent;
        [SerializeField] protected Vector3 itemOffset = new Vector3(0, 1f, 0.5f);

        [Header("Events")]
        public UnityEvent<HoldItem> OnItemAdded;
        public UnityEvent<HoldItem> OnItemRemoved;
        public UnityEvent OnItemsChanged;

        [Header("Runtime")]
        public List<HoldItem> HoldingItems = new List<HoldItem>();
        protected List<GameObject> spawnedPrefabs = new List<GameObject>();

        protected virtual void Start()
        {
            if (startItems != null && startItems.Count > 0)
            {
                foreach (var item in startItems)
                {
                    if (item != null && HoldingItems.Count < maxHoldableItems)
                        AddItem(item.GetHoldItem());
                }
            }
        }

        public virtual void Interact(PlayerController playerController)
        {
            PlayerInteraction playerInteraction = playerController.updatables.FirstOfType<PlayerInteraction>();
            if (playerInteraction == null) return;

            if (playerInteraction.HasItem)
            {
                if (HoldingItems.Count < maxHoldableItems)
                {
                    HoldItem removedItem = playerInteraction.RemoveItem();
                    if (removedItem != null)
                        AddItem(removedItem);
                }
            }
            else
            {
                if (HoldingItems.Count > 0)
                {
                    HoldItem itemToGive = HoldingItems[^1];
                    bool givedItem = playerInteraction.GiveItem(itemToGive);
                    if (givedItem)
                        RemoveItem(itemToGive);
                }
            }
        }

        public virtual void AddItem(HoldItem holdItem)
        {
            if (holdItem == null || holdItem.Item == null || HoldingItems.Count >= maxHoldableItems) return;
            HoldingItems.Add(holdItem);

            if (holdItem.Item.itemPrefab != null)
            {
                Vector3 pos = transform.position + itemOffset + Vector3.up * 0.3f * (HoldingItems.Count - 1);
                Transform parent = itemParent != null ? itemParent : transform;
                GameObject spawned = Instantiate(holdItem.Item.itemPrefab, pos, Quaternion.identity, parent);
                spawnedPrefabs.Add(spawned);
            }

            OnItemAdded?.Invoke(holdItem);
            OnItemsChanged?.Invoke();
        }

        public virtual void RemoveItem(HoldItem holdItem)
        {
            if (holdItem == null) return;
            int index = HoldingItems.IndexOf(holdItem);
            if (index >= 0)
            {
                HoldingItems.RemoveAt(index);
                if (index < spawnedPrefabs.Count && spawnedPrefabs[index] != null)
                {
                    Destroy(spawnedPrefabs[index]);
                    spawnedPrefabs.RemoveAt(index);
                }

                OnItemRemoved?.Invoke(holdItem);
                OnItemsChanged?.Invoke();
            }
        }

        public virtual void InteractHold(PlayerController playerController)
        {
            Debug.Log("Interacting hold with " + gameObject.name);
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Vector3 titlePos = transform.position + Vector3.up * 3f;
            GUIStyle titleStyle = new GUIStyle
            {
                normal = new GUIStyleState { textColor = Color.cyan },
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold
            };
            UnityEditor.Handles.Label(titlePos, gameObject.name, titleStyle);

            if (HoldingItems != null && HoldingItems.Count > 0)
            {
                Vector3 basePos = transform.position + Vector3.up * 2f;
                GUIStyle style = new GUIStyle
                {
                    normal = new GUIStyleState { textColor = Color.yellow },
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold
                };

                for (int i = 0; i < HoldingItems.Count; i++)
                {
                    var holdItem = HoldingItems[i];
                    if (holdItem?.Item != null)
                    {
                        Vector3 pos = basePos + Vector3.up * (0.3f * i);
                        UnityEditor.Handles.Label(pos, holdItem.Item.itemName, style);
                    }
                }
            }
        }
#endif
    }
}
