﻿using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

  public float x, y, z;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    transform.Rotate(x, y, z);
	}
}
