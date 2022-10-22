using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "FloatValue", menuName = "Values/New FloatValue", order = 0)]

    public class FloatValue : Value
    {
        public float value;
    }
}
