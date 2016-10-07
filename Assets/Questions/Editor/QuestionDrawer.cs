using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(Question))]
public class QuestionDrawer : PropertyDrawer {

  bool showAnswers = true;

  public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
  {
    if (property.objectReferenceValue != null)
    {
      //Debug.Log(property.objectReferenceValue);
      SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
      int arraySize = serializedObject.FindProperty("answers").arraySize;
      float answerHeight = showAnswers ? arraySize + 0.5f : .5f;
      return base.GetPropertyHeight(property, label) * (answerHeight + 3);
    }
    else
      return base.GetPropertyHeight(property, label);
}

  
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    //if no object currently assigned displays an empty field and shortcircuits drawing 
    //the rest of the property
    if (property.objectReferenceValue == null)
    {
      EditorGUI.PropertyField(position, property);
      return;
    } 

    //this line appears to grab a reference to the property?
    SerializedObject serializedObject = new SerializedObject(property.objectReferenceValue);
    float propHeight = EditorGUIUtility.singleLineHeight;
    position.height = propHeight;

    //not really sure if this is doing anything?
    EditorGUI.BeginProperty(position, label, property);

    //PropertyField to display the Question asset type
    EditorGUI.PropertyField(position, property, GUIContent.none);
    //Increment height after every draw to position for the next element
    position.y += propHeight;

    //Cache serializedProperty and read/store its string value in next line
    SerializedProperty questionText = serializedObject.FindProperty("questionText");
    questionText.stringValue = EditorGUI.TextField(position, "Question Text", questionText.stringValue);
    position.y += propHeight;

    //Auto indent everything after here. Remember to reset when done.
    EditorGUI.indentLevel++;
    //Collapsable menu. Wrap collapsable portion in if statement, also tie into
    //GetPropertyHeight() to adjust spacing based on visible area
    showAnswers = EditorGUI.Foldout(position, showAnswers, "Answers");
    if (showAnswers)
    {
      SerializedProperty answers = serializedObject.FindProperty("answers");
      for (int i = 0; i < answers.arraySize; i++)
      {
        position.y += propHeight;

        GUIContent answerLabel = new GUIContent();
        answerLabel.text = (1 + i).ToString() + ")";

        //Retrieve element and data from array
        SerializedProperty answer = answers.GetArrayElementAtIndex(i);
        SerializedProperty answerText = answer.FindPropertyRelative("answerText");
        SerializedProperty correct = answer.FindPropertyRelative("correct");

        //Create GUIStyles for text display, conditionally change color based on class variables
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        GUIStyle answerStyle = new GUIStyle(GUI.skin.textField);
        GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
        if (correct.boolValue)
        {
          labelStyle.normal.textColor = Color.green;
          answerStyle.normal.textColor = Color.green;
        }
        answerText.stringValue = EditorGUI.TextField(position, GUIContent.none, answerText.stringValue, answerStyle);

        EditorGUI.indentLevel++;
        //EditorGUI.PrefixLabel(position, answerLabel, labelStyle);
        //EditorGUI.indentLevel++;
        correct.boolValue = EditorGUI.Toggle(position, correct.boolValue, toggleStyle);

        EditorGUI.indentLevel--;
        //EditorGUI.indentLevel--;
      }
    }
    EditorGUI.indentLevel--;

    EditorGUI.EndProperty();

    serializedObject.ApplyModifiedProperties();
  }
}
