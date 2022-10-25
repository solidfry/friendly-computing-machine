using UnityEngine;
using ScriptableObjects;

public class LevelProperties : MonoBehaviour
{
    public FloatValue gravity;

    void Update()
    {
        Physics2D.gravity = new Vector2(0, gravity.Value);
    }
}
