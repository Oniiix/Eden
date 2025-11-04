using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyGrid))]
public class MyGridEditor : Editor
{
    MyGrid grid = null;

    private void OnEnable()
    {
        grid = (MyGrid)target;
        EditorUtility.SetDirty(grid);
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawGridUI();
    }

    void DrawGridUI()
    {
        if (GUILayout.Button("Generate"))
        {
            grid.GenerateGrid();
            SceneView.RepaintAll();
        }

        if (GUILayout.Button("Clear"))
        {
            grid.ClearGrid();
            SceneView.RepaintAll();
        }
    }
}
