using UnityEngine;
using UnityEditor;
using System.Collections;

public class MakeWeaponObject
{
  
  [MenuItem("Assets/Create/WeaponObject")]
  public static void Create()
  {
    WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject>();
    AssetDatabase.CreateAsset(asset, "Assets/NewWeaponObject.asset");
    AssetDatabase.SaveAssets();
    EditorUtility.FocusProjectWindow();
    Selection.activeObject = asset;
  }
  
}
