using Events;
using UnityEngine;

namespace Objects
{
    public class Goal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Ball"))
            {
                GameEvents.onLevelFinishedEvent.Invoke();
            }
        }
    }
}
