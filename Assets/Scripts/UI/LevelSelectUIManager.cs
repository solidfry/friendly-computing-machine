using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectUIManager : MonoBehaviour
    {
        [SerializeField] private LevelList levels;
        [SerializeField] private GameObject levelUIPrefab;
        [SerializeField] private GridLayoutGroup grid;
        [SerializeField] Button button;

        private void Awake() => DestroyDummyLayout();

        private void Start() => CreateLayout();

        void CreateLayout()
        {
            if (levels == null)
                return;

            foreach (var level in levels.list)
            {
                GameObject levelInstance = Instantiate(levelUIPrefab, grid.transform);
                LevelCardUI cardUI = levelInstance.GetComponent<LevelCardUI>();
                cardUI.levelData = level;
            }

            if (levels.CheckAllComplete())
            {
                button.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }

        void DestroyDummyLayout()
        {
            var destroyDummyCards = GetComponentsInChildren<LevelCardUI>();
            foreach (var card in destroyDummyCards) Destroy(card.gameObject);
        }
    }
}
