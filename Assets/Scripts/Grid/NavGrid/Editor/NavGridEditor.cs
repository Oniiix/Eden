using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NavGrid))]
public class NavGridEditor : Editor
{
    NavGrid grid = null;
    SerializedProperty useDebug = null;

    private void OnEnable()
    {
        grid = (NavGrid)target;
        useDebug = serializedObject.FindProperty("useDebug");
        EditorUtility.SetDirty(grid);
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawGridUI();
    }
    private void OnSceneGUI()
    {
        DrawNodesScene();
    }

    void DrawGridUI()
    {
        if (GUILayout.Button("Generate"))
        {
            grid.Generate();
            SceneView.RepaintAll();
        }
    }
    void DrawNodesScene()
    {
        if (!useDebug.boolValue)
            return;

        for (int i = 0; i < grid.Nodes.Count; i++)
        {
            if (grid.Nodes[i].IsOpen)
            {
                bool _click = Handles.Button(grid.Nodes[i].Position, Quaternion.identity, .2f, .1f, Handles.CubeHandleCap);
                Handles.Label(grid.Nodes[i].Position, grid.Nodes[i].F.ToString());

                if (_click)
                    grid.Nodes[i].IsSelected = !grid.Nodes[i].IsSelected;
            }
        }
    }
}
