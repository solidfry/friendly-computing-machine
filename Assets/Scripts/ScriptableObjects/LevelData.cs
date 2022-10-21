using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData/New LevelData", order = 0)]

public class LevelData : ScriptableObject
{
    [SerializeField] private string levelName;

    [SerializeField][TextArea] private string description;

    [SerializeField] bool isComplete;

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
        private set => isComplete = value;
    }





}
