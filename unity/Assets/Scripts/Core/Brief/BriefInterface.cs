using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Brief
{
    public class BriefInterface : MonoBehaviour
    {
        public RectTransform briefPanel;
        public TextMeshProUGUI briefNameText;
        public TextMeshProUGUI briefDescriptionText;
        public Button briefEndButton;

        public void Start()
        {
            briefPanel.gameObject.SetActive(false);
            briefEndButton.onClick.AddListener(HideBriefPanel);
        }

        public void SetupNewBriefShow(Brief brief)
        {
            briefPanel.gameObject.SetActive(true);
            briefNameText.text = brief.briefTitle;
            briefDescriptionText.text = brief.briefDescription;
            
        }

        public void HideBriefPanel()
        {
            briefPanel.gameObject.SetActive(false);
        }
    }
}