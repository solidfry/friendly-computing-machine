using UnityEngine;
using ScriptableObjects;

public class LevelProperties : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    public FloatValue gravity;

    void Update() => Physics2D.gravity = new Vector2(0, gravity.Value);
}
