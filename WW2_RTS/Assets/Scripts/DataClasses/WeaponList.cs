using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponList{

	List<Weapon> weapons;

	void PopulateList () {
				
		weapons.Add(new Weapon());						//Creates the weapon
		weapons[0].WeaponName = "MK 1";					//Sets the weapons name
		weapons[0].Accuracy = 25;						//Sets the Accuracy
		weapons[0].Burst = 3;							//Sets the Shots per burst
		weapons[0].MagSize = 10;						//Sets the mag size of the weapon
		weapons[0].WeaponType = Weapon.Weapontype.Auto;	//Sets the weapon Type

		weapons.Add(new Weapon());
		weapons[1].WeaponName = "AK 1";
		weapons[1].Accuracy = 100;
		weapons[1].Burst = 1;
		weapons[1].MagSize = 5;
		weapons[1].WeaponType = Weapon.Weapontype.Bolt;

	}

	public Weapon CreateWeapon (string Name){

		//Creates the weaponlist
		if(weapons == null){

			weapons = new List<Weapon>();

			PopulateList();		
		}

		//finds the weapon from the list
		for (int i = 0; i < weapons.Count; i++) {
		
			if (weapons[i].WeaponName == Name){

				return weapons[i];
			}
		}

		Debug.LogError("Weapon not found");

		return null;
	
	}
}
