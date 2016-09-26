using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StatusCodes))]
public class StatusCodesEditor : Editor {

  public static GUIStyle guiScriptName
  {
    get
    {
      var guiScriptName = new GUIStyle(GUI.skin.label);
      guiScriptName.normal.textColor = Color.yellow;
      guiScriptName.fontSize = 24;
      guiScriptName.fixedHeight = 30;
      guiScriptName.alignment = TextAnchor.UpperCenter;
      return guiScriptName;
    }
  }
  public StatusCodes script;

  void OnEnable ()
  {
    script = target as StatusCodes;
  }

public override void OnInspectorGUI()
  {
    

    //DrawDefaultInspector();
    EditorGUILayout.LabelField(GetType().ToString(), guiScriptName);
    EditorGUILayout.Space();
    EditorGUILayout.Space();
    
    EditorGUILayout.BeginHorizontal();

    EditorGUILayout.BeginVertical();
    EditorGUI.indentLevel++;

    MakeStatus(Status.Okay, Color.green);
    MakeStatus(Status.Caution, Color.yellow);
    MakeStatus(Status.Danger, Color.red);
    MakeStatus(Status.Dead, Color.black);
   
    EditorGUI.indentLevel--;
    EditorGUILayout.EndVertical();

    EditorGUILayout.BeginVertical();
    EditorGUILayout.LabelField("Top one");
    EditorGUILayout.LabelField("Bottom one");
    EditorGUILayout.EndVertical();

    EditorGUILayout.EndHorizontal();
    EditorGUILayout.Space();

    EditorGUILayout.BeginHorizontal();
    script.condition = (Status) EditorGUILayout.EnumPopup(script.condition,GUILayout.ExpandWidth(false),GUILayout.MaxWidth(70));
    script.condition = (Status) EditorGUILayout.IntSlider((int)script.condition, 0, 3);
    EditorGUILayout.EndHorizontal();
  }

  private void MakeStatus(Status condition, Color color)
  {
    EditorGUILayout.LabelField(condition.ToString());
    Rect r = GUILayoutUtility.GetLastRect();
    r.width = r.height;
    if (condition == script.condition)
      EditorGUI.DrawRect(r, color);
  }
}
