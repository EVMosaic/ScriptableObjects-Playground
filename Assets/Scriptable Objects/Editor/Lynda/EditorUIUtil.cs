using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorUIUtil {

  public static GUIStyle guiTitleStyle
  {
    get
    {
      var guiTitleStyle = new GUIStyle(GUI.skin.label);
      guiTitleStyle.normal.textColor = Color.cyan;
      guiTitleStyle.fontSize = 16;
      guiTitleStyle.fixedHeight = 30;
      return guiTitleStyle;
    }
  }

  public static GUIStyle guiMessageStyle
  {
    get
    {
      var messageStyle = new GUIStyle(GUI.skin.label);
      messageStyle.wordWrap = true;

      return messageStyle;
    }
  }

}
