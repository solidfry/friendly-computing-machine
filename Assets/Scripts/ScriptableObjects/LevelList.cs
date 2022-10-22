using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "List/New Level List", order = 0)]
    public class LevelList : ScriptableObject
    {
        public List<LevelData> list;
    }
}
