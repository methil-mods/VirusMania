using UnityEngine;

namespace Core.Settings
{
    public class FPSLimiter : MonoBehaviour
    {
        private static bool initialized = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            if (!initialized)
            {
                initialized = true;

                // Create a GameObject to hold the limiter
                GameObject go = new GameObject("FPSLimiter");
                DontDestroyOnLoad(go);
                go.AddComponent<FPSLimiter>();
            }
        }

        private void Awake()
        {
            // Read FPS from the ScriptableObject singleton
            if (SettingsData.Instance != null)
            {
                Application.targetFrameRate = SettingsData.Instance.targetFrameRate;
                QualitySettings.vSyncCount = 0; // Ensure VSync does not interfere
            }
            else
            {
                Debug.LogWarning("SettingsData instance not found. Using default FPS 60.");
                Application.targetFrameRate = 60;
                QualitySettings.vSyncCount = 0;
            }
        }
    }

}