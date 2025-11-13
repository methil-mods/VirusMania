using System.Linq;
using Core.Item.Holder;
using UnityEngine;

namespace Core.Item.Merge
{
    public static class MergeUtils
    {
        public static HoldItem TryMerge(params Item[] items)
        {
            foreach (var recipe in MergeDatabase.Instance.Database)
            {
                if (recipe.Matches(items))
                {
                    Debug.Log($"Merged {string.Join(", ", items.Select(i => i.itemName))} " +
                              $"into {recipe.GetResultItem().Item.itemName}");
                    return recipe.GetResultItem();
                }
            }

            Debug.Log("No valid merge recipe found.");
            return null;
        }
        
    }
}