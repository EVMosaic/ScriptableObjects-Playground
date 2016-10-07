﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject {

  public string weaponName = "Weapon name here";
  public int cost = 50;
  public string description;

  public float fireRate = 0.5f;
  public int damage = 10;
  public float range = 100;
}
