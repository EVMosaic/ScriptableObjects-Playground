using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ConditionData))]
public class Condition : MonoBehaviour {

  public  void OaenGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


  }

}
