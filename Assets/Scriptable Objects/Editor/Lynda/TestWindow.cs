using UnityEngine;
using System.Collections;
using UnityEditor;

public class TestWindow : EditorWindow
{

  private GameObject currentSelection;

  [MenuItem("Eric/Test Window")]
  static void Init()
  {
    var window = (TestWindow)GetWindow(typeof(TestWindow));

    var content = new GUIContent();
    content.text = "Test Window";

    var icon = new Texture2D(16, 16);
    content.image = icon;

    window.titleContent = content;
  }

  private void OnFocus()
  {
    currentSelection = Selection.activeGameObject;

  }

  private void OnLostFocus()
  {
    currentSelection = null;
  }

  private void OnGUI()
  {
    if (currentSelection != null)
    {
      EditorGUILayout.BeginVertical();

      EditorGUILayout.LabelField("currently selected GameObject:");
      EditorGUILayout.LabelField(currentSelection.name);
      currentSelection.transform.position = EditorGUILayout.Vector3Field("At Position", currentSelection.transform.position);

      EditorGUILayout.EndVertical();
    } else
    {
      EditorGUILayout.LabelField("Select a GameObject first then click here.");
    }

    DropApreaGUI();
  }

  private void DropApreaGUI()
  {
    var e = Event.current.type;

    if (e == EventType.DragUpdated)
    {
      DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
    }
      else if (e == EventType.DragPerform)
     {
       DragAndDrop.AcceptDrag();

      foreach(Object draggedObject in DragAndDrop.objectReferences)
      {
        if (draggedObject is GameObject)
        {
          Debug.Log(draggedObject);
        }
      }
     }
  }

}
