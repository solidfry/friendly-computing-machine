using UnityEditor;
using UnityEngine;
using ScriptableObjects;

[CustomEditor(typeof(LevelList))]
public class LevelListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (LevelList)target;

        if (GUILayout.Button("Reset All Data", GUILayout.Height(40)))
        {
            script.ResetData();
        }

    }
}