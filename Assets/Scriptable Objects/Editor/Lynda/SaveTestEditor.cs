using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

[CustomEditor(typeof(SaveTest))]
public class SaveTestEditor : Editor
{

  private ReorderableList list;
  private SaveTest saveTestScript;

  private void OnEnable()
  {
    saveTestScript = Selection.activeGameObject.GetComponent<SaveTest>();
    list = new ReorderableList(serializedObject, serializedObject.FindProperty("items"), true, true, true, true);
    saveTestScript = Selection.activeGameObject.GetComponent<SaveTest>();
    list.onRemoveCallback += RemoveCallBack;
    list.drawElementCallback += OnDrawCallback;
  }

  private void OnDisable()
  {
    if (list !=  null)
    {
      list.onRemoveCallback -= RemoveCallBack;
      list.drawElementCallback -= OnDrawCallback;
    }
  }

  private void RemoveCallBack(ReorderableList list)
  {
    if (EditorUtility.DisplayDialog("Warning!", "Are you sure?", "Yes", "No"))
    {
      ReorderableList.defaultBehaviours.DoRemoveButton(list);
      //ReorderableList.defaultBehaviours.DoAddButton(list);
    }
  }

  private void OnDrawCallback(Rect rect, int index, bool isActive, bool isFocused)
  {
    var item = list.serializedProperty.GetArrayElementAtIndex(index);
    EditorGUI.PropertyField(
      new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
      item.FindPropertyRelative("name"),
      GUIContent.none
      );

    EditorGUI.PropertyField(
      new Rect(rect.x + 80, rect.y, 150, EditorGUIUtility.singleLineHeight),
      item.FindPropertyRelative("pos"),
      GUIContent.none
      );

  }

  public override void OnInspectorGUI()
  {

    EditorGUILayout.Space();

    EditorGUILayout.LabelField(GetType().ToString(), EditorUIUtil.guiTitleStyle);

    EditorGUILayout.Space();

    EditorGUILayout.LabelField("Put text here to explain how to use the editor. Put text here to explain how to use the editor. Put text here to explain how to use the editor. Put text here to explain how to use the editor.", EditorUIUtil.guiMessageStyle);


    //DrawDefaultInspector();
    list.DoLayoutList();

    saveTestScript = Selection.activeGameObject.GetComponent<SaveTest>();

    EditorGUILayout.BeginVertical();

    if(GUILayout.Button("Save"))
    {
      var text = saveTestScript.Save();
      WriteData(text);
    }

    if (GUILayout.Button("Load"))
    {
      saveTestScript.Load(ReadDataFromFile());
    }
    EditorGUILayout.EndVertical();

    serializedObject.ApplyModifiedProperties();
  }

  private void WriteData(string data)
  {
    var path = EditorUtility.SaveFilePanel("Save Data", "", "data.txt", "txt");

    using (FileStream fs = new FileStream(path, FileMode.Create))
    {
      using (StreamWriter writer = new StreamWriter(fs))
      {
        writer.Write(data);
      }
    }

    AssetDatabase.Refresh();

  }

  private string ReadDataFromFile()
  {
    var path = EditorUtility.OpenFilePanel("Load Data", "", "txt");

    var reader = new WWW("file:///" + path);

    while(!reader.isDone)
    {
    }

    return reader.text;
  }
}
