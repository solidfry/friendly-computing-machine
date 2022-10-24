using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class Goal : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.LevelFinished += EndLevel;
    }

    private void OnDisable()
    {
        GameEvents.LevelFinished -= EndLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            GameEvents.LevelFinished.Invoke();
        }
    }

    void EndLevel()
    {
        //Put something here to end the level, Elliot.
    }
}
