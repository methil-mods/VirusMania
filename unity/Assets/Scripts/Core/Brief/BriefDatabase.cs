using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Brief
{
    [CreateAssetMenu(menuName = "Brief/BriefDatabase", fileName = "BriefDatabase")]
    public class BriefDatabase : SingletonScriptableDatabase<BriefDatabase, Brief>
    {
        
    }
}