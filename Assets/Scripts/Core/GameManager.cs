using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button startSimulation;
        [SerializeField] private Canvas endLevelPanel;
        [SerializeField] private bool levelCompleted = false;
        private void Start() => GameEvents.onBallPauseEvent?.Invoke();

        public bool LevelCompleted
        {
            get => levelCompleted;
            set
            {
                levelCompleted = value;
                if(levelCompleted) EndLevel();
            }
        }
        
        private void OnEnable()
        {
            if (startSimulation != null) 
                startSimulation.onClick.AddListener(() => GameEvents.onBallStartEvent?.Invoke());

            GameEvents.onLevelIsCompletedEvent += IsLevelCompleted;
        }
        private void OnDisable() => GameEvents.onLevelIsCompletedEvent -= IsLevelCompleted;

        private void IsLevelCompleted()
        {
            Debug.Log($"LevelCompleted is {LevelCompleted}"); 
            LevelCompleted = true; 
        }
        
        private void EndLevel() => Instantiate(endLevelPanel);
    }
}
