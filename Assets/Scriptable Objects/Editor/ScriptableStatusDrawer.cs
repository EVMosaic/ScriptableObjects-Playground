using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ScriptableStatus))]
public class ScriptableStatusDrawer : PropertyDrawer {

  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    
    
    EditorGUI.BeginProperty(position, label, property);
    
   // var test = property.FindPropertyRelative("name");
//    Debug.Log(test);
    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
    //int indent = EditorGUI.indentLevel;
    //EditorGUI.indentLevel = 0;

    //Rect colorRect = new Rect(position.x, position.y, 30, position.height);
    //EditorGUI.PropertyField(colorRect, test, GUIContent.none);
    EditorGUI.EndProperty();
  }
}
