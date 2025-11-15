using Core.Prefab;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Analysis
{
    public class ThreatOfDiseasePrefab : MonoBehaviour
    {
        public Image threatIconImage;
        public RectTransform threatImpactContainer;

        public void Setup(Sprite _threatIconImage, int threatLevel)
        {
            threatIconImage.sprite = _threatIconImage;
            foreach (Transform child in threatImpactContainer)
            {
                Destroy(child.gameObject);
            }

            if (threatLevel > 0)
            {
                for (int i = 0; i < threatLevel; i++)
                {
                    Instantiate(PrefabDatabase.Instance.analysisThreatPlusPrefab, threatImpactContainer);                    
                }
            }

            if (threatLevel < 0)
            {
                for (int i = threatLevel; i < 0; i++)
                {
                    Instantiate(PrefabDatabase.Instance.analysisThreatMinusPrefab, threatImpactContainer);                    
                }
            }
        }
    }
}