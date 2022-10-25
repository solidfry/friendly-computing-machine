using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class LevelProperties : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        public FloatValue gravity;

        void Update() => Physics2D.gravity = new Vector2(0, gravity.Value);

        public void ResetData()
        {
            if (levelData == null)
                return;
            
            levelData.ResetData();
        }
    }
}
