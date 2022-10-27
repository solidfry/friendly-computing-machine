using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "List/New Level List", order = 0)]
    public class LevelList : ScriptableObject
    {
        public List<LevelData> list;
        public bool allLevelsComplete;

        public string GetNextLevel()
        {
            if (SceneManager.GetActiveScene().name.Contains("Level"))
            {
                string currentScene = SceneManager.GetActiveScene().name;
                int sceneNumber = int.Parse(currentScene.Split(" ")[1]);
                Debug.Log(sceneNumber + 1);
                Debug.Log($" List count is {list.Count}");
                return sceneNumber <= list.Count - 1 ? $"Level {sceneNumber + 1}" : "LevelSelect";
            }

            return "LevelSelect";
        }

        public void ResetData()
        {
            foreach (var i in list)
            {
                i.ResetData();
            }
        }

        public void CheckAllComplete()
        {
            allLevelsComplete = list.TrueForAll(e => e.IsComplete);
        }

    }
}
