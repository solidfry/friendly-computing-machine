using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Utility;


public class EndLevelHandler : MonoBehaviour
{
    [SerializeField] LevelList list;
    [SerializeField] Button button;

    private void OnEnable() => button.onClick.AddListener(LoadNextScene);

    private void OnDisable() => button.onClick.RemoveListener(LoadNextScene);

    void LoadNextScene()
    {
        var nextLevelStr = list.GetNextLevel();
        SceneHelpers.Load(nextLevelStr);
        Debug.Log($"Loading next scene {nextLevelStr}");
    }

}
