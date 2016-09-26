using UnityEngine;
using System.Collections;

[System.Serializable]
[CreateAssetMenu(fileName ="Status Indicator", menuName ="Mosaic Learning/Status")]
public class ScriptableStatus : ScriptableObject {

  public Color color;
  public GameObject target;
  public Texture2D image;
  public string name2;

}
