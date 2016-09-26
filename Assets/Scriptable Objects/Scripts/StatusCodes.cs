using UnityEngine;
using System.Collections;

public enum Status
{
  Okay,
  Caution,
  Danger,
  Dead
}



public class StatusCodes : MonoBehaviour {

  public Status condition;
}
