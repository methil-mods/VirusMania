using System;
using UnityEngine;

namespace Core.Threats
{
    /// <summary>
    /// Base parameters for threats like viruses or bacteria
    /// </summary>
    [CreateAssetMenu(fileName = "ThreatParameters", menuName = "Threats/ThreatParameters")]
    public class ThreatParameters: ScriptableObject
    {
        public string parameterName;
        public float value;
    }
}