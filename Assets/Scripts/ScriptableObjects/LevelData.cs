using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData/New LevelData", order = 0)]

public class LevelData : ScriptableObject
{
    [SerializeField] private string levelName;

    [SerializeField][TextArea] private string description;

    [SerializeField] bool isComplete;
    public List<Entry> valuesToTrack;
    public string LevelName
    {
        get;
        private set;
    }

    public string Description
    {
        get;
        private set;
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

    [System.Serializable]
    public class Entry
    {
        public Value goal;
        public Value value;
        public bool isComplete;

        public bool IsComplete
        {
            get => isComplete;
            set { if (value == goal) isComplete = true; }
        }
    }


}


