using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(Quiz))]
public class QuizEditor : Editor {
  private string buttonText = "Add New Question";
  private int clicked;
  Question newQuestion;
  string assetPathAndName;

  public override void OnInspectorGUI()
  {
    Quiz quiz = target as Quiz;

    DrawDefaultInspector();

    if (GUILayout.Button(buttonText))
    {
      buttonText = "button clicked " + clicked++.ToString() + "times";
      newQuestion = ScriptableObject.CreateInstance(typeof(Question)) as Question;

      
      
      string path = AssetDatabase.GetAssetPath(quiz).Split('.')[0];
      path = Path.GetDirectoryName(path);

      assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/NewQuestion.asset");
      //Debug.Log(assetPathAndName);
      AssetDatabase.CreateAsset(newQuestion, assetPathAndName);
      AssetDatabase.SaveAssets();

      EditorUtility.FocusProjectWindow();
      //Selection.activeObject = newQuestion;

      quiz.questions.Add(AssetDatabase.LoadAssetAtPath<Question>(assetPathAndName));
    }

  }
}
