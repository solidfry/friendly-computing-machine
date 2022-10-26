using System;
using Events;
using UnityEngine;

namespace Core
{
    public class RigidBodyManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        private void Awake() => rb = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        
        private void OnEnable()
        {
            GameEvents.onBallPauseEvent += PauseRigidBody;
            GameEvents.onBallStartEvent += StartRigidBody;
        }

        private void OnDisable()
        {
            GameEvents.onBallPauseEvent -= PauseRigidBody;
            GameEvents.onBallStartEvent -= StartRigidBody;
        }

        private void PauseRigidBody()
        {
            if (rb == null)
                return;

            rb.simulated = false;
        }
        
        private void StartRigidBody()
        {
            if (rb == null)
                return;

            rb.simulated = true;
        }
    }
}