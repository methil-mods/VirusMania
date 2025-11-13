using Core.Item.Holder;
using UnityEngine;

namespace Core.Item.Merge
{
    [CreateAssetMenu(fileName = "MergeVirusRecipe", menuName = "MergeRecipe/MergeVirusRecipe")]
    public class MergeVirusRecipe : MergeRecipe<MicrobeItem, VirusItem>
    {
        public override HoldItem GetResultItem()
        {
            HoldVirusItem holdVirusItem = resultItem.GetHoldItem() as HoldVirusItem;

            foreach (MicrobeItem microbe in this.inputItems)
            {
                holdVirusItem?.AddMicrobe(microbe);
            }
            
            return holdVirusItem;
        }
    }
}