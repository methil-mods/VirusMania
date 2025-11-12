using UnityEngine;
using UnityEngine.Rendering;
using Framework.Controller;
using UnityEngine.Rendering.Universal;

namespace Core.PostProcess
{
    public class PostProcessController : BaseController<PostProcessController>
    {
        public Volume postProcessVolume;

        private DepthOfField depthOfFieldEffect;
        private float originalFocusDistance = 2f;
        private int tweenId = -1;

        public void Start()
        {
            if (postProcessVolume != null && postProcessVolume.profile != null)
            {
                postProcessVolume.profile.TryGet<DepthOfField>(out depthOfFieldEffect);
                if (depthOfFieldEffect != null)
                {
                    originalFocusDistance = depthOfFieldEffect.focusDistance.value;
                }
            }
        }

        public void OnShowPanelPostProcess()
        {
            if (depthOfFieldEffect != null)
            {
                depthOfFieldEffect.active = true;
                if (tweenId != -1) LeanTween.cancel(tweenId);
                tweenId = LeanTween.value(gameObject, depthOfFieldEffect.focusDistance.value, 0f, 0.3f)
                    .setOnUpdate((float val) => { depthOfFieldEffect.focusDistance.value = val; })
                    .id;
            }
        }

        public void OnHidePanelPostProcess()
        {
            if (depthOfFieldEffect != null)
            {
                if (tweenId != -1) LeanTween.cancel(tweenId);
                tweenId = LeanTween.value(gameObject, depthOfFieldEffect.focusDistance.value, originalFocusDistance, 0.3f)
                    .setOnUpdate((float val) => { depthOfFieldEffect.focusDistance.value = val; })
                    .setOnComplete(() => { depthOfFieldEffect.active = false; })
                    .id;
            }
        }
    }
}