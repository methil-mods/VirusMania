using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Item.Merge
{
    [CreateAssetMenu(fileName = "MergeDatabase", menuName = "MergeRecipe/MergeDatabase")]
    public class MergeDatabase : SingletonScriptableDatabase<MergeDatabase, MergeRecipeBase> 
    {
        
    }
}