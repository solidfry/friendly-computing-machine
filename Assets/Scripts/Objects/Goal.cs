using Events;
using UnityEngine;

namespace Objects
{
    public class Goal : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.onLevelFinishedEvent += EndLevel;
        }

        private void OnDisable()
        {
            GameEvents.onLevelFinishedEvent -= EndLevel;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Ball"))
            {
                GameEvents.onLevelFinishedEvent.Invoke();
            }
        }

        void EndLevel()
        {
            //Put something here to end the level, Elliot.
        }
    }
}
