using UnityEngine;
using System.Collections;

[CreateAssetMenu (fileName ="Data", menuName = "Mosaic Learning/Data", order = 1)]
public class DataContainer : ScriptableObject {

  public int myInt;
  public string myString;
  public Color myColor;
  public GameObject myPrefab;
}
