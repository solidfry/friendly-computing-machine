using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "FloatValue", menuName = "Values/New FloatValue", order = 0)]

    public class FloatValue : Value
    {
        [SerializeReference] private float value;

        public float Value
        {
            get => value;
            set => this.value = value;
        }
        
    }
}
