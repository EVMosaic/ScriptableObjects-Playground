using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class CustomDataStructure
{
  public string name;
  public GameObject target;
  public Vector3 position;
}

public class HelloWorld : MonoBehaviour {

  [Range(0f,10f)]
  public float speed;
  public Vector3 startPos;

  [Tooltip("What the gameobject should follow")]
  public HelloWorld target;
  public string message = "Hello world!";

  [Header("Array Tests")]
  public string[] strings;
  public int[] numbers;
  public Vector3[] positions;
  public GameObject[] gameObjects;

  public CustomDataStructure[] customTarget;

  [HideInInspector]
  public List<string> stringList;
  public Dictionary<string, Vector3> childrenPositions;

  public int life { get; set; }
}

