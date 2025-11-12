using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Prefab
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Prefab/PrefabDatabase")]
    public class PrefabDatabase : SingletonScriptableObject<PrefabDatabase>
    {
        public GameObject interactionIndicationPrefab;
    }
}