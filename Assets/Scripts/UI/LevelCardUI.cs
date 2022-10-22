using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelCardUI : MonoBehaviour
    {
        [SerializeField] public LevelData levelData;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Button button;
        [SerializeField] private bool _isComplete;
        [SerializeField] private GameObject completeUI;
        private void Start() => Setup();
    
        private void OnEnable()
        {
            button.onClick.AddListener(LoadScene);
        }
    
        private void OnDisable()
        {
            button.onClick.RemoveListener(LoadScene);
        }

        void LoadScene()
        {
            if (levelData == null)
                return;
        
            SceneManager.LoadScene(levelData.LevelScene);
        }

        void Setup()
        {
            completeUI.SetActive(false);
            if (levelData == null)
                return;

            titleText.text = levelData.LevelName;
            descriptionText.text = levelData.Description;
            _isComplete = levelData.IsComplete;
            if(_isComplete) completeUI.SetActive(true);
        }
    }
}
