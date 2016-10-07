using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RgbHsv))]
public class RgbHsvEditor : Editor {

  bool showPosition = true;
  float h, s, v;

  public override void OnInspectorGUI()
  {
    var script = target as RgbHsv;

    //DrawDefaultInspector();
    EditorGUILayout.LabelField("This is the color");
    EditorGUILayout.Space();

    Rect rect = GUILayoutUtility.GetLastRect();
    rect.height = EditorGUIUtility.singleLineHeight;

    EditorGUI.DrawRect(rect, script.color);
    EditorGUILayout.Space();
    EditorGUILayout.Space();

    showPosition = EditorGUILayout.Foldout(showPosition, "Color Sliders");
    if (showPosition)
    {
      EditorGUILayout.BeginHorizontal();

      EditorGUILayout.BeginVertical("box");
      float maxWidth = EditorGUIUtility.currentViewWidth / 2;
      EditorGUILayout.LabelField("Red");
      script.r = EditorGUILayout.Slider(script.r, 0, 1, GUILayout.MaxWidth(maxWidth));
      EditorGUILayout.LabelField("Green");
      script.g = EditorGUILayout.Slider(script.g, 0, 1, GUILayout.MaxWidth(maxWidth));
      EditorGUILayout.LabelField("Blue");
      script.b = EditorGUILayout.Slider(script.b, 0, 1, GUILayout.MaxWidth(maxWidth));
      //Color RGBcolor = new Color(script.r, script.g, script.b);
      EditorGUILayout.EndVertical();

      EditorGUILayout.BeginVertical("box");
      EditorGUILayout.LabelField("Hue");
      script.h = EditorGUILayout.Slider(script.h, 0, 1, GUILayout.MaxWidth(maxWidth));
      EditorGUILayout.LabelField("Saturation");
      script.s = EditorGUILayout.Slider(script.s, 0, 1, GUILayout.MaxWidth(maxWidth));
      EditorGUILayout.LabelField("Value");
      script.v = EditorGUILayout.Slider(script.v, 0, 1, GUILayout.MaxWidth(maxWidth));
      EditorGUILayout.EndVertical();

      EditorGUILayout.EndHorizontal();
    }

    serializedObject.ApplyModifiedProperties();
  }
}
