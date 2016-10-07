using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Answer
{
  public string answerText;
  public bool correct;
}

[CreateAssetMenu(fileName = "New Question", menuName = "Mosaic Learning/Question")]
public class Question : ScriptableObject {

  public string questionText;
  public List<Answer> answers; 

}
