using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SquadLoadout {

	public List<List<Weapon>> LoadOut;


	public SquadLoadout () {

		LoadOut = new List<List<Weapon>>();

		//Sets the Standard Loadouts for Squads

		//New loadout = LoadOut.Add(new List<Weapon> { 
		//WorldManger.Instace.weaponlist.CreateWeapon("MK 1"), <-- High = Higher proity
		//WorldManger.Instace.weaponlist.CreateWeapon("MK 1"), <-- Low = Lower proity
		//});

		LoadOut.Add(new List<Weapon> {  
			WorldManger.Instace.weaponlist.CreateWeapon("MK 1"), 
			WorldManger.Instace.weaponlist.CreateWeapon("AK 1"),
		
		});
	}
}
