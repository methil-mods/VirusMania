using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Prefab
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Prefab/PrefabDatabase")]
    public class PrefabDatabase : SingletonScriptableObject<PrefabDatabase>
    {
        [Header("Interaction")]
        public GameObject interactionIndicationPrefab;
        
        [Header("Analysis")]
        public GameObject analysisThreatPrefab;
        public GameObject analysisThreatPlusPrefab;
        public GameObject analysisThreatMinusPrefab;
    }
}