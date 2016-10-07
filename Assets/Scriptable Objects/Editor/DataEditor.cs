using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (DataContainer))]
[CanEditMultipleObjects]
public class DataEditor : Editor {

  SerializedProperty intProp;
  SerializedProperty stringProp;
  SerializedProperty colorProp;
  //SerializedProperty gameObjProp;

  void OnEnable()
  {
    intProp = serializedObject.FindProperty("myInt");
    stringProp = serializedObject.FindProperty("myString");
    colorProp = serializedObject.FindProperty("myColor");
   // gameObjProp = serializedObject.FindProperty("myGameObject");
  }

  public override void OnInspectorGUI()
  {
    serializedObject.Update();

    EditorGUILayout.IntSlider(intProp, 0, 100, new GUIContent("Inty"));
    EditorGUILayout.IntField("intfield", 0);
    ProgressBar(intProp.intValue / 100.0f, "percent");

    EditorGUILayout.PrefixLabel("This is a prefix label");
    EditorGUILayout.TextArea("This is a text area");
    EditorGUILayout.SelectableLabel("This is a selectable label");
    EditorGUILayout.TextField("This is a text Field");
    EditorGUILayout.LabelField("This is a label field");

    EditorGUILayout.PropertyField(stringProp, new GUIContent("this is a string","this is a tooltip"));
    EditorGUILayout.PropertyField(colorProp, new GUIContent("color"));
    EditorGUI.indentLevel = 0;
    EditorGUI.PrefixLabel(new Rect(10, 320, 20, 30), new GUIContent("COLORBOX"));
    EditorGUIUtility.DrawColorSwatch(new Rect(EditorGUIUtility.currentViewWidth/2 - 10, 350, 30, 30), colorProp.colorValue);
    EditorGUI.indentLevel = 10;
    EditorGUILayout.ColorField(Color.white);

    EditorGUILayout.DelayedIntField(intProp);

    EditorGUI.BoundsField(new Rect(0, 400, 20, 0), "Bounds field", new Bounds(Vector3.zero, Vector3.one));

    //Rect r = EditorGUILayout.BeginHorizontal();
    GUILayout.Label("hlab");
    GUILayout.TextField("htext");
    EditorGUILayout.EndHorizontal();

    serializedObject.ApplyModifiedProperties();
    
  }

  void ProgressBar (float value, string label)
  {
    Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
    EditorGUI.ProgressBar(rect, value, label);
    EditorGUILayout.Space();
  }

}
