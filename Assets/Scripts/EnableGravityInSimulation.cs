using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGravityInSimulation : MonoBehaviour
{
    [SerializeField] private string simulationSceneName = "Simulation";

    void Update()
    {
        if (gameObject.scene.name == simulationSceneName)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
