using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class TrajectorySimulation : MonoBehaviour
    {
        private Scene simulationScene;
        private PhysicsScene2D physicsScene;
        Vector2 originalPos;
        [SerializeField] private Transform obstaclesParent;
        [SerializeField] private LineRenderer line;
        [SerializeField] private int maxPhysicsFramesIterations;
        private Dictionary<Transform, Transform> spawnedObjects = new();

        private void Start()
        {
            originalPos = transform.position;
            CreatePhysicsScene();
        }

        private void Update()
        {
            ResetTrajectory();
            SimulateTrajectory(gameObject, originalPos);

            foreach (var item in spawnedObjects)
            {
                item.Value.position = item.Key.position;
                item.Value.rotation = item.Key.rotation;
                item.Value.localScale = item.Key.localScale;
            }
        }

        void CreatePhysicsScene()
        {
            simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
            physicsScene = simulationScene.GetPhysicsScene2D();

            foreach (Transform obj in obstaclesParent)
            {
                var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);

                if (ghostObj.GetComponent<SpriteRenderer>() != null)
                {
                    ghostObj.GetComponent<SpriteRenderer>().enabled = false;
                } else
                {
                    SpriteRenderer[] spriteRenderers = ghostObj.GetComponentsInChildren<SpriteRenderer>();

                    for (int i = 0; i < spriteRenderers.Length; i++) { spriteRenderers[i].enabled = false; }
                }

                SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);

                if (!ghostObj.isStatic) { spawnedObjects.Add(obj, ghostObj.transform); }
            }
        }

        public void SimulateTrajectory(GameObject ball, Vector2 pos)
        {
            var ghostObj = Instantiate(ball, pos, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);

            for (int i = 0; i < maxPhysicsFramesIterations; i++)
            {
                physicsScene.Simulate(Time.fixedDeltaTime);
                line.positionCount++;
                line.SetPosition(i, ghostObj.transform.position);
            }

            Destroy(ghostObj);
        }

        void ResetTrajectory() => line.positionCount = 0;
    }
}
