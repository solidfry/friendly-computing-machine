using UnityEditor;
using UnityEngine;
using ScriptableObjects;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (LevelData)target;

        if (GUILayout.Button("Reset Data", GUILayout.Height(40)))
        {
            script.ResetData();
        }

    }
}