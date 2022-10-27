using System;
using Events;
using UnityEngine;

namespace Objects
{
    public class Goal : MonoBehaviour
    {
        private Collider2D goalCollider;
        public GameObject confettiGameObject;

        private void Awake()
        {
            goalCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Ball"))
            {
                foreach (Transform obj in confettiGameObject.transform)
                {
                    obj.GetComponent<ParticleSystem>().Play();
                }

                goalCollider.enabled = false;
                if (GetComponent<AudioSource>().enabled == true) { GetComponent<AudioSource>().Play(); }
                GameEvents.onLevelFinishedEvent.Invoke();
            }
        }

//        IEnumerator DelayRemoveCollisions(Collider2D collision)
//        {
//            yield return new WaitForSeconds(3f);
//            collision.gameObject.GetComponent<Collider2D>().enabled = false;
//        }
    }
}
