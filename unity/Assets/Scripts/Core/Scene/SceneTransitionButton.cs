using UnityEngine;

namespace Core.Scene
{
    public class SceneTransitionButton : MonoBehaviour
    {
        public int newScene;
        
        public void GoOnNewScene()
        {
            SceneTransitor.Instance.LoadScene(newScene);
        }
    }
}