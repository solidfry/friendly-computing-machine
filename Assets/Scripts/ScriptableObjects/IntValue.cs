using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "IntValue", menuName = "Values/New IntValue", order = 0)]

    public class IntValue : ValueBase<int>
    {
        public override int Value { get; set; }
    }
}