using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(Field))]
public class FieldEditor : Editor
{
    private Field field;

    private void OnEnable()
    {
        field = (Field)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate"))
        {
            field.Generate();
        }

        if (GUILayout.Button("Clear"))
        {
            field.Clear();
        }
    }
}
