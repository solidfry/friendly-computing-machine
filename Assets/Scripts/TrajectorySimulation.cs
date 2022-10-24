using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrajectorySimulation : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene2D physicsScene;
    [SerializeField] private Transform obstaclesParent;
    [SerializeField] private LineRenderer line;
    [SerializeField] private int maxPhysicsFramesIterations;

    private void Start()
    {
        CreatePhysicsScene();

        SimulateTrajectory(gameObject, transform.position, GetComponent<Rigidbody2D>().velocity);
    }

    void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        physicsScene = simulationScene.GetPhysicsScene2D();

        foreach (Transform obj in obstaclesParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            if (ghostObj.GetComponent<Renderer>() != null) { ghostObj.GetComponent<Renderer>().enabled = false; }
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        }
    }

    public void SimulateTrajectory(GameObject ball, Vector2 pos, Vector2 velocity)
    {
        var ghostObj = Instantiate(ball, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);

        ghostObj.GetComponent<Rigidbody2D>().AddForce(velocity);

        for (int i = 0; i < maxPhysicsFramesIterations; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.positionCount++;
            line.SetPosition(i, ghostObj.transform.position);
        }

        Destroy(ghostObj);
    }
}
