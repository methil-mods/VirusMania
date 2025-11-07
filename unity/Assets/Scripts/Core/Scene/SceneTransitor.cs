using System;
using Framework.Controller;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Scene
{
    public class SceneTransitor : BaseController<SceneTransitor>
    {
        public UnityAction OnLoadNewScene;
        public UnityAction OnEndLoadNewScene;
    
        public GameObject loadingScreen;
    
        public void LoadScene(int sceneToLoad){
            OnLoadNewScene?.Invoke();
            var loadingScreenPrefab = GameObject.Instantiate(loadingScreen);
            loadingScreenPrefab.GetComponent<LoadingScreenController>()
                .StartToLoadScene(sceneToLoad, () =>
                {
                    OnEndLoadNewScene?.Invoke();
                });
        }
    
        public void LoadScene(int sceneToLoad, Action onEndCallback){
            OnLoadNewScene?.Invoke();
            var loadingScreenPrefab = GameObject.Instantiate(loadingScreen);
            loadingScreenPrefab.GetComponent<LoadingScreenController>()
                .StartToLoadScene(sceneToLoad, () =>
                {
                    onEndCallback?.Invoke();
                    OnEndLoadNewScene?.Invoke();
                });
        }
    }
}