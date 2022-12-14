using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneHelpers : MonoBehaviour
    {
        public static void Load(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public static void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}