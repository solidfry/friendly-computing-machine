using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button startSimulation;
        
        private void Awake()
        {
            if(startSimulation != null)
                Time.timeScale = 0;
        }

        private void OnEnable()
        {
            if (startSimulation != null) 
                startSimulation.onClick.AddListener(() => Time.timeScale = 1);
        }
    }
}
