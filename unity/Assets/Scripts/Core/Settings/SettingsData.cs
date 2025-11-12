using Framework.ScriptableObjects;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Settings/SettingsData")]
    public class SettingsData : SingletonScriptableObject<SettingsData>
    {
        public int targetFrameRate = 60;
    }
}