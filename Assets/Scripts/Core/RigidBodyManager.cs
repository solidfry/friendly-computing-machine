using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class RigidBodyManager : MonoBehaviour
    {
        private const string sim = "Simulation";
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

            if (rb.gameObject.scene.name != sim)
                rb.simulated = false;
        }

        private void StartRigidBody()
        {
            if (rb == null)
                return;

            if (rb.gameObject.scene.name != sim)
                rb.simulated = true;
        }
    }
}