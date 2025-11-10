using System.Collections.Generic;
using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Threats
{
    [CreateAssetMenu(fileName = "ThreatParametersDatabase", menuName = "Threats/ThreatParametersDatabase")]
    public class ThreatParametersDatabase: SingletonScriptableDatabase<ThreatParametersDatabase, ThreatParameters>
    {
        public List<ThreatParameters> threatParameters;
    }
}