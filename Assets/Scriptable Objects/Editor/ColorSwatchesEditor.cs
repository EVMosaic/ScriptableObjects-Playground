using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ColorSwatches))]
public class ColorSwatchesEditor : Editor {

  public override void OnInspectorGUI()
  {
    //DrawDefaultInspector();

    EditorGUILayout.Space();
    EditorGUILayout.LabelField("Default Colors");
    EditorGUILayout.Space();

    Rect r = GUILayoutUtility.GetLastRect();

    float spacing = (EditorGUIUtility.currentViewWidth - 120)/5; 
    EditorGUILayout.BeginHorizontal();

    r.x = 20;
    r.y += 0;
    r.width = 20;
    r.height = r.width;
    GUIContent colorBox = new GUIContent();
    colorBox.text = "red";
    EditorGUI.DrawRect(r, Color.red);
    r.x += spacing;
    EditorGUI.DrawRect(r, Color.Lerp(Color.red, Color.yellow, .5f)) ;
    r.x += spacing;
    EditorGUI.DrawRect(r, Color.yellow);
    r.x += spacing;
    EditorGUI.DrawRect(r, Color.green);
    r.x += spacing;
    EditorGUI.DrawRect(r, Color.blue);
    r.x += spacing;
    EditorGUI.DrawRect(r, Color.Lerp(Color.Lerp(Color.red, Color.blue, .5f), Color.white, .1f));
    //EditorGUILayout.ColorField(colorBox, Color.red, false, false, false, new ColorPickerHDRConfig(0,0,0,0), GUILayout.Width(50.0f));
    //EditorGUILayout.ColorField(Color.green, GUILayout.Height(80.0f));
    EditorGUILayout.EndHorizontal();
    EditorGUILayout.Space();
    EditorGUILayout.Space();
    EditorGUILayout.LabelField("End Colors");
  }

}
