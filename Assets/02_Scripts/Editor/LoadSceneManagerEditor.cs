using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoadSceneManager))]
public class LoadSceneManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); 
        
        var manager = (LoadSceneManager)target;

        if (GUILayout.Button("씬 로드"))
        {
            manager.DownloadAndLoadAsync();
        }
        
        if (GUILayout.Button("캐시 삭제"))
        {
            manager.ClearCache();
        }
        
    }
}