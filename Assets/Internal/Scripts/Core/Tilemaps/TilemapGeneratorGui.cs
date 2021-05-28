using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TilemapGenerator))]
public class TilemapGeneratorGui : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            TilemapGenerator.Instance.Generate();
        }
    }
}