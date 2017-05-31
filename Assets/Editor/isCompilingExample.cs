﻿using UnityEditor;
using UnityEngine;

public class isCompilingExample : EditorWindow
{
    [MenuItem("Examples/Is compiling?")]
    static void Init()
    {
        EditorWindow window = GetWindowWithRect(typeof(isCompilingExample), new Rect(0, 0, 10, 10));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Compiling:", EditorApplication.isCompiling ? "Yes" : "No");

        this.Repaint();
    }
}