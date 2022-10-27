using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "List/New Level List", order = 0)]
    public class LevelList : ScriptableObject
    {
        public List<LevelData> list;

        public string GetNextLevel()
        {
            if (SceneManager.GetActiveScene().name.Contains("Level"))
            {
                string currentScene = SceneManager.GetActiveScene().name;
                int sceneNumber = int.Parse(currentScene.Split(" ")[1]);
                Debug.Log(sceneNumber + 1);
                return sceneNumber <= list.Count ? $"Level {sceneNumber + 1}" : "LevelSelect";
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
    }
}
