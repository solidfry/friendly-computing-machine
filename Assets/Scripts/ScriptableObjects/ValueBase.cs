using UnityEngine;

namespace ScriptableObjects
{
    public abstract class ValueBase<T> : ScriptableObject
    {
        [SerializeField] protected T value;

        public virtual T Value
        {
            get => this.value;
            set => this.value = value;
        }
    }
}
