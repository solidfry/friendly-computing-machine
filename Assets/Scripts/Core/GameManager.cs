using System;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button startSimulation;
        [SerializeField] private Canvas endLevelPanel;
        
        private void Start() => GameEvents.onBallPauseEvent?.Invoke();
        

        private void OnEnable()
        {
            if (startSimulation != null) 
                startSimulation.onClick.AddListener(() => GameEvents.onBallStartEvent?.Invoke());

            GameEvents.onLevelFinishedEvent += EndLevel;
        }

        private void OnDisable() => GameEvents.onLevelFinishedEvent -= EndLevel;
        

        private void EndLevel() => Instantiate(endLevelPanel);
        
    }
}
