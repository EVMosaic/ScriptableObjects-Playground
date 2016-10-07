using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Question))]
public class QuestionEditor : Editor
{
  Vector2 scroll;
 

  public override void OnInspectorGUI()
  {
    var question = target as Question;

    EditorGUILayout.LabelField("Question Text");

    question.questionText = EditorGUILayout.TextArea(
      question.questionText,
      GUILayout.Height(EditorGUIUtility.singleLineHeight * 3));
    
    if (question.answers.Count == 0)
    {
      //EditorGUILayout.PropertyField(serializedObject.FindProperty("answers"));
    }
    else {
      EditorGUILayout.Space();
      EditorGUILayout.BeginHorizontal();
      EditorGUILayout.LabelField("Correct", GUILayout.Width(55));
      GUIStyle rightAlign = new GUIStyle(GUI.skin.label);
      rightAlign.alignment = TextAnchor.MiddleRight;
      EditorGUILayout.LabelField("Answers", rightAlign);
      GUILayout.Space(30);
      EditorGUILayout.EndHorizontal();

      EditorGUILayout.BeginVertical();
      for (int i = 0; i < question.answers.Count; i++)
      {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(17);
        question.answers[i].correct = EditorGUILayout.Toggle(question.answers[i].correct, GUILayout.Width(17));
        question.answers[i].answerText = EditorGUILayout.TextField(question.answers[i].answerText);
        GUIStyle removeStyle = new GUIStyle(GUI.skin.button);
        removeStyle.normal.textColor = Color.red;

        if (GUILayout.Button("x", removeStyle, GUILayout.Width(25)))
        {
          question.answers.RemoveAt(i);
        }
        EditorGUILayout.EndHorizontal();
      }
      EditorGUILayout.EndVertical();
    }
    if(GUILayout.Button("Add New Answer"))
    {
      Answer newAnswer = new Answer();
      question.answers.Add(newAnswer);
    }

    serializedObject.ApplyModifiedProperties();
  }

}
