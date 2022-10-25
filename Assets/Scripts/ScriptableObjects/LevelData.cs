using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelData/New LevelData", order = 0)]

    public class LevelData : ScriptableObject
    {
        [SerializeField] private string levelName;
        [SerializeField][TextArea] private string description;
        [SerializeField] private string levelScene;
        [SerializeField] bool isComplete;
        public List<Entry> valuesToTrack = new();

        public string LevelName
        {
            get => levelName;
            private set => levelName = value;
        }

        public string Description
        {
            get => description;
            private set => description = value;
        }

        public string LevelScene
        {
            get => levelScene;
            private set => levelScene = value;
        }

        public bool IsComplete
        {
            get => isComplete;
            private set
            {
                isComplete = value;
                isComplete = valuesToTrack.TrueForAll(v => v.isComplete);
            }
        }

        private void OnValidate()
        {
            if (LevelScene == "")
                LevelScene = LevelName;
        }

        public void ResetData() => valuesToTrack.ForEach(e => e.currentValue = e.initialValue);
        
        [System.Serializable]
        public class Entry
        {
            public ValueBase<float> goal;
            public ValueBase<float> currentValue;
            public ValueBase<float> initialValue;
            public bool isComplete;

            public bool IsComplete
            {
                get => isComplete;
                set => isComplete = value || Math.Abs(currentValue.Value - goal.Value) < .01f;
            }
        }


    }
}


