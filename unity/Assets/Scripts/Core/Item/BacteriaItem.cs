using System;
using Core.Threats;
using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(fileName = "BacteriaItem", menuName = "Item/BacteriaItem")]
    public class BacteriaItem : Item
    {
        [SerializeField]
        public ThreatParameter[] threatParameters;
    }

    [Serializable]
    public class ThreatParameter
    {
        public ThreatType threatType;
        public float threatImpact;
    }
}