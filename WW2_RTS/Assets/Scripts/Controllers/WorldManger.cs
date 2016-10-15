using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManger : MonoBehaviour {

	public GameObject SL;

	public List<Squad> squadlist;

	public WeaponPreSet WeaponPreset;

	public List<GameObject> SpawnPointList;

	public static WorldManger Instace {get; set;} 

	// Use this for initialization
	void Awake () {

		Instace = this;

		WeaponPreset = new WeaponPreSet();

		squadlist = new List<Squad>();
	
		SpawnPointList = new List<GameObject>();

		AddSquad(new Squad(1));
	}

	/// <summary>
	/// Add a Squad to the world mangers list of all squads
	/// </summary>
	/// <param name="SquadToAdd">Squad to add.</param>
	public void AddSquad(Squad SquadToAdd) {

		squadlist.Add(SquadToAdd);
	}
	public GameObject SpawnSquadLeader (GameObject Unit,int Index,Squad PassedSquad) {

		PassedSquad.Units.Remove(Unit);

		var SLobject = Instantiate(SL,Unit.transform.position,Quaternion.identity);

		Destroy(Unit);

		return SLobject as GameObject;
	}
}