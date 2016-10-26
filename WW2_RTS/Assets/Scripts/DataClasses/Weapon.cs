using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour{

	public enum Weapontype{Bolt,Auto}

	Weapontype weaponType;

	public Weapontype WeaponType {
		get {
			return weaponType;
		}
		set {
			weaponType = value;
		}
	}

	public bool InUse = false;

	public int MagSize;

	public int Burst;

	public float Accuracy;

	public string WeaponName;

} 