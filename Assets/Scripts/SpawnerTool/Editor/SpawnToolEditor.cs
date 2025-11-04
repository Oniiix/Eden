using UnityEditor;
using UnityEngine;

public class SpawnToolEditor : Editor
{
    //SpawnerTool spawner = null;
    //SerializedProperty radius, densityType, density, useSingleItem, item, items;

    //private void OnEnable()
    //{
    //    spawner = (SpawnerTool)target;
    //    radius = serializedObject.FindProperty("spawnerRadius");
    //    densityType = serializedObject.FindProperty("densityType");
    //    density = serializedObject.FindProperty("density");
    //    useSingleItem = serializedObject.FindProperty("useSingleItem");
    //    item = serializedObject.FindProperty("item");
    //    items = serializedObject.FindProperty("items");
    //    EditorUtility.SetDirty(spawner);
    //}
    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();
    //    DrawGridUI();
    //    serializedObject.ApplyModifiedProperties();
    //}

    //void DrawGridUI()
    //{ 

    //    radius.floatValue = EditorGUILayout.FloatField(new GUIContent("Radius"), radius.floatValue);
    //    EditorGUILayout.PropertyField(densityType, new GUIContent("Density type"));

    //    if (densityType.intValue == (int)ESpawnerToolDensity.Multiple)
    //        density.intValue = EditorGUILayout.IntField(new GUIContent("Density"), density.intValue);

    //    useSingleItem.boolValue = EditorGUILayout.Toggle(new GUIContent("Use single item"), useSingleItem.boolValue);

    //    if (useSingleItem.boolValue)
    //        EditorGUILayout.PropertyField(item, new GUIContent("Item"));
    //    else
    //        EditorGUILayout.PropertyField(items, new GUIContent("Items"));

    //    if (GUILayout.Button("Spawn"))
    //    {
    //        spawner.Spawn(spawner.transform.position);
    //        SceneView.RepaintAll();
    //    }

    //    if (GUILayout.Button("Erase test"))
    //    {
    //        spawner.EraseTest();
    //        SceneView.RepaintAll();
    //    }

    //    if (GUILayout.Button("Clear all"))
    //    {
    //        spawner.Clear();
    //        SceneView.RepaintAll();
    //    }
    //}
}
