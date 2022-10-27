using System;
using System.Collections;
using Events;
using ScriptableObjects;
using UnityEngine;
using Utility;

namespace Core
{
    public class LevelProperties : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        public FloatValue gravity;

        void Update() => Physics2D.gravity = new Vector2(0, gravity.Value);

        public void ResetData()
        {
            if (levelData == null)
                return;

            levelData.ResetData();
            StartCoroutine(ResetScene());
        }

        private void OnEnable()
        {
            GameEvents.onLevelFinishedEvent += CheckCompletion;
        }

        private void OnDisable()
        {
            GameEvents.onLevelFinishedEvent -= CheckCompletion;
        }

        private void CheckCompletion()
        {
            levelData.SetCompleted();
            if (levelData.IsComplete) GameEvents.onLevelIsCompletedEvent?.Invoke();
        }

        IEnumerator ResetScene()
        {
            yield return new WaitForSeconds(2f);
            SceneHelpers.ReloadCurrentScene();
        }
    }
}
