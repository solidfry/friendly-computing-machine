using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ToggleUIElement : MonoBehaviour
    {
        [SerializeField] GameObject uiPrefab;
        [SerializeField] Button button;
        [SerializeField] private float animationDuration = .2f;
        [Range(0,1)][SerializeField] private float scaleFactor = .9f;
        private CanvasGroup _uiCanvasGroup;
        private Transform _uiTransform;
        private void Start()
        {
             _uiTransform = uiPrefab.transform;
             _uiCanvasGroup = uiPrefab.GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Toggle);
        }
    
        private void OnDisable()
        {
            button.onClick.RemoveListener(Toggle);
        }
    
        void Toggle()
        {
            if (uiPrefab.activeInHierarchy)
            {
                _uiCanvasGroup.DOFade(0, animationDuration);
                Tween scale = _uiTransform.DOScale(Vector3.one * scaleFactor, animationDuration);
                scale.OnComplete(() => { uiPrefab.SetActive(false); });
            }
            else
            {
                _uiTransform.localScale = Vector3.one * scaleFactor;
                _uiTransform.DOScale(Vector3.one, animationDuration);
                _uiCanvasGroup.DOFade(1, animationDuration);
                uiPrefab.SetActive(true);
            }
        }
        
    }
}