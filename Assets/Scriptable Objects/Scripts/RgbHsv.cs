using UnityEngine;
using System.Collections;

public class RgbHsv : MonoBehaviour {

  public Color color;

  public float r
  {
    get { return color.r; }
    set { color.r = value; }
  }
    
  public float g
  {
    get { return color.g; }
    set { color.g = value; }
  }

  public float b
  {
    get { return color.b; }
    set { color.b= value; }
  }

  public float H, S, V;
  public float h
  {
    get
    {
      Color.RGBToHSV(color, out H, out S, out V);
      return H;
    }        
    set { color = Color.HSVToRGB(value, S, V); } 
  }

  public float s
  {
    get
    {
      Color.RGBToHSV(color, out H, out S, out V);
      return S;
    }
    set { color = Color.HSVToRGB(H, value, V); }
  }

  public float v
  {
    get
    {
      Color.RGBToHSV(color, out H, out S, out V);
      return V;
    }
    set { color = Color.HSVToRGB(H, S, value); }
  }
  // Use this for initialization
  void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
