using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "FloatValue", menuName = "Values/New FloatValue", order = 0)]

    public class FloatValue : ValueBase<float>
    {
        public override float Value
        {
            get => this.value; 
            set => this.value = value;
        }
    }
}
