using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoadAssetManager))]
public class LoadAssetManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        LoadAssetManager manager = (LoadAssetManager)target;

        if (GUILayout.Button("전사 로드"))
        {
            manager.LoadWarriorAsync();
        }
        
        if (GUILayout.Button("전사 해제"))
        {
            manager.ReleaseWarrior();
        }
    }
}