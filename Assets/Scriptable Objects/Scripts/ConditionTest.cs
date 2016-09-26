using UnityEngine;
using System.Collections;


[System.Serializable]
public class ConditionData
{
  public string name;
  public float health;
  public Color color;
}

public class ConditionTest : MonoBehaviour {

  public ConditionData[] datapoints;
  public ConditionData current;

  // Use this for initialization
  void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
