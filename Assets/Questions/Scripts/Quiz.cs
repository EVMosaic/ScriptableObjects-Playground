using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Quiz", menuName = "Mosaic Learning/Quiz")]
public class Quiz : ScriptableObject
{
  //public Question[] questions;
  public List<Question> questions;

}
