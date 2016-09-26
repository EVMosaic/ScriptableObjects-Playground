using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ConditionData))]
public class ConditionDataDrawer : PropertyDrawer {

  public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label)
  {
    SerializedProperty name = prop.FindPropertyRelative("name");
    SerializedProperty health = prop.FindPropertyRelative("health");
    SerializedProperty color = prop.FindPropertyRelative("color");


    //EditorGUI.Slider(
    //    new Rect(pos.x, pos.y, pos.width - 50, pos.height),
    //    health, 0, 1, label);

    int indent = EditorGUI.indentLevel;
    EditorGUI.indentLevel = 0;
    EditorGUI.Slider(new Rect(pos.x, pos.y, pos.width - 30, pos.height), health, 0, 1, label);
    //name.stringValue = EditorGUI.TextField(new Rect(pos.x + pos.height, pos.y, 75, pos.height), name.stringValue);

    EditorGUI.indentLevel = 1;

    EditorGUI.DrawRect(new Rect(pos.width - 5, pos.y, pos.height, pos.height), Color.red);



    EditorGUI.indentLevel = indent;
  }
}
