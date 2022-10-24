using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ValueBase<T> : ScriptableObject
    {
        [SerializeField] private T value;

        public virtual T Value
        {
            get => value;
            set => this.value = value;
        }
    }
}
