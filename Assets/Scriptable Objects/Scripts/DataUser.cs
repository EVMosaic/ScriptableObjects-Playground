using UnityEngine;
using System.Collections;

public class DataUser : MonoBehaviour {


  public DataList dl;
  private DataContainer dc;
  private GameObject go;
  private int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  [ContextMenu("Spawn")]
  public void Spawn()
  {
    index = (index + 1) % dl.dataPoints.Length;
    dc = dl.dataPoints[index];

    DestroyImmediate(go);

    go = GameObject.Instantiate(dc.myPrefab, transform.position, Quaternion.identity) as GameObject;
    go.GetComponent<Renderer>().sharedMaterial.color = dc.myColor;
    go.transform.localScale = Vector3.one * dc.myInt;
    go.name = dc.myString;
  }

}
