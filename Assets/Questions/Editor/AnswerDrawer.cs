using UnityEngine;
using UnityEditor;
using System.Collections;

//[CustomPropertyDrawer(typeof(Answer))]
public class AnswerDrawer : PropertyDrawer {

  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    EditorGUI.LabelField(position, "THIS IS THE DRAWER");
  }

}
