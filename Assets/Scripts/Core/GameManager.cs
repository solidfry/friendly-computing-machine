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
        private void Awake()
        {
            if(startSimulation != null)
                Time.timeScale = 0;
        }

        private void OnEnable()
        {
            if (startSimulation != null) 
                startSimulation.onClick.AddListener(() => Time.timeScale = 1);

            GameEvents.onLevelFinishedEvent += EndLevel;
        }

        private void OnDisable() => GameEvents.onLevelFinishedEvent -= EndLevel;
        

        private void EndLevel() => Instantiate(endLevelPanel);
        
    }
}
