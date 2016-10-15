using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {

	public enum Weapontype{Bolt,Full}

	public Weapontype Type {
		get {
			return Type;
		}
		set {
			Type = value;
		}
	}

	public int MagSize;

	public int Burst;

	public float Accuracy;

	public string Name;

	public Weapon (string WeaponName){

		for (int i = 0; i < WorldManger.Instace.WeaponPreset.WeaponList.Length; i++) {
			
			if (WorldManger.Instace.WeaponPreset.WeaponList[i].Name == WeaponName){
			
				this.MagSize = WorldManger.Instace.WeaponPreset.WeaponList[i].MagSize;
				this.Burst = WorldManger.Instace.WeaponPreset.WeaponList[i].Burst;
				this.Accuracy = WorldManger.Instace.WeaponPreset.WeaponList[i].Accuracy;
				this.Name = WorldManger.Instace.WeaponPreset.WeaponList[i].Name;
			}else {

				Debug.LogError("Not valid Weapon");
			}
		}
	}
}