using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Scene
{
    public class LoadingScreenController : MonoBehaviour
    {
        public Image loadingScreenImage;
        [SerializeField]
        private Slider loadingSlider;
        private bool _sceneIsSwapping;

        public void StartToLoadScene(int sceneToLoad){
            StartToLoadScene(sceneToLoad, () => {});
        }

        public void StartToLoadScene(int sceneToLoad, Action onEndCallback){
            CanvasGroup canvasGroup = loadingScreenImage.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            if(_sceneIsSwapping == true)
                return;
            DontDestroyOnLoad(this.gameObject);
            StartCoroutine(LoadScene(sceneToLoad, onEndCallback));
        }

        private IEnumerator LoadScene(int sceneToLoad, Action onEndCallback){
            _sceneIsSwapping = true;
            float startPosition = loadingScreenImage.rectTransform.position.y;
            CanvasGroup canvasGroup = loadingScreenImage.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            LeanTween.alphaCanvas(canvasGroup, 1f, 1f)
                .setEase( LeanTweenType.easeOutQuart )
                .setIgnoreTimeScale(true);
            yield return new WaitForSecondsRealtime(1f); 

            AsyncOperation asyncSceneToLoad = SceneManager.LoadSceneAsync(sceneToLoad);
            asyncSceneToLoad.allowSceneActivation = false; // stop the level from activating

            while (asyncSceneToLoad.progress < 0.9f){
                loadingSlider.value = asyncSceneToLoad.progress;
                yield return new WaitForEndOfFrame();
            } 

            loadingSlider.value = 1f;
            asyncSceneToLoad.allowSceneActivation = true; // this will enter the level now
            yield return new WaitForEndOfFrame();
            yield return new WaitForFixedUpdate();
            onEndCallback.Invoke();
            yield return new WaitForSeconds(0.2f);
            LeanTween.alphaCanvas(canvasGroup, 0f, 1f)
                .setEase( LeanTweenType.easeOutQuart )
                .setIgnoreTimeScale(true);
            yield return new WaitForSecondsRealtime(1.2f);
            Destroy(this.gameObject);
            _sceneIsSwapping = false;
        }
    }
}