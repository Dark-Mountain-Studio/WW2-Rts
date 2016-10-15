using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WeaponPreSet {

	public Weapon[] WeaponList;

	void CreateWeaponList (){

		WeaponList[0].Name = "Ak1";
		WeaponList[0].MagSize = 20;
		WeaponList[0].Burst = 4;
		WeaponList[0].Accuracy = 50f;
		WeaponList[0].Type = Weapon.Weapontype.Full;

		WeaponList[1].Name = "Ak2";
		WeaponList[1].MagSize = 5;
		WeaponList[1].Burst = 1;
		WeaponList[1].Accuracy = 100f;
		WeaponList[1].Type = Weapon.Weapontype.Bolt;
			
	}
}