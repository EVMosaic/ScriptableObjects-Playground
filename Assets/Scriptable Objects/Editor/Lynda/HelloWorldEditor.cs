using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(HelloWorld))]
public class HelloWorldEditor : Editor {

  private bool visible;


  public override void OnInspectorGUI()
  {
    var script = target as HelloWorld;

    EditorGUILayout.Space();

    EditorGUILayout.LabelField(GetType().ToString(), EditorUIUtil.guiTitleStyle);

    EditorGUILayout.Space();

    EditorGUILayout.LabelField("Put text here to explain how to use the editor. Put text here to explain how to use the editor. Put text here to explain how to use the editor. Put text here to explain how to use the editor.", EditorUIUtil.guiMessageStyle);

    EditorGUILayout.BeginVertical("box");
    EditorGUILayout.Space();
    script.speed = EditorGUILayout.Slider("Speed", script.speed, 0, 10);

    script.target = EditorGUILayout.ObjectField("Target", script.target, typeof(HelloWorld), true) as HelloWorld;
    if (script.target == null)
      EditorGUILayout.HelpBox("Add target to get rid of this error message", MessageType.Error);

    EditorGUILayout.Space();
    EditorGUILayout.EndVertical();

    EditorGUILayout.Space();

    EditorGUILayout.BeginVertical("box");
    EditorGUI.indentLevel++;
    visible = EditorGUILayout.Foldout(visible, "Options");

    if (visible)
    {
      EditorGUI.indentLevel++;
      var props = new[] { "startPos", "target", "message" };

      for (var i = 0; i < props.Length; i++)
      {
        var sProp = serializedObject.FindProperty(props[i]);
        var guiContent = new GUIContent();
        guiContent.text = sProp.displayName;
        EditorGUILayout.PropertyField(sProp, guiContent);
        DisplayPropError(sProp);
      }
      EditorGUI.indentLevel--;
    }
    EditorGUI.indentLevel--;
    EditorGUILayout.EndVertical();

    EditorGUILayout.Space();
    EditorGUILayout.BeginVertical();

    EditorGUILayout.LabelField("A Button");

    if (GUILayout.Button("Open Test Window"))
    {
      EditorWindow.GetWindow(typeof(TestWindow));
    }

    EditorGUILayout.EndVertical();

    serializedObject.ApplyModifiedProperties();
  }

  private void DisplayPropError(SerializedProperty prop)
  {
    var empty = false;

    switch (prop.type)
    {
      case "string":
        empty = prop.stringValue == "";
        break;
    }

    if (empty)
      DisplayErrors(prop.displayName);
  }

  private void DisplayErrors(string name)
  {
    var message = name + " field cannot be empty";
    EditorGUILayout.HelpBox(message, MessageType.Error);
  }
}
