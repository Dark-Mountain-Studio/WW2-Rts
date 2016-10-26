using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Squad {

	enum SquadType {
	
	Inf,
	Eng

	}

	public List<GameObject> Units;

	public GameObject squadleader;

	List<Weapon> SquadWeapons;

	public bool InPlay;

	int SquadId;

	string TeamId;

	public float ViewDis = 100;

	public int ViewAngle = 100;

	//The Team the Squad is apart of
	public string TeamID {
		get {
			return TeamId;
		}
	}
	//The ID of the Squad
	public int SquadID {
		get {
			return SquadId;
		}
	}

	//The Size of the Squad
	int Squadsize;

	public int SquadSize {
		get {
			return Squadsize;
		}
	}
		
	/// <summary>
	/// Initializes a new instance of the <see cref="Squad"/> class.
	/// </summary>
	/// <param name="Size">Size.</param>
	public Squad (int Size,int SquadID, string Team, List<Weapon> _SquadWeapons){

		InPlay = false;
		TeamId = Team;
		SquadId = SquadID;
		Squadsize = Size;
		SquadWeapons = SquadWeapons;
	
	}

	/// Adds the unit too the List.
	/// </summary>
	/// <param name="unit">Unit.</param>
	public void AddUnit (GameObject unit){

		if(Units == null){

			Units = new List<GameObject>();
		}

		Units.Add(unit);

		if (Units.Count > Squadsize) {

			Squadsize++;
		}

		unit.gameObject.GetComponent<SoliderAI>().UnitNumber = Units.Count;
	
	}
	//Make a new Squad Leader 
	public void NewSquadLeader () {
	
		if (squadleader == null) {

			for (int i = 0; i < Units.Count; i++) {

				if (Units[i] != null) {

					squadleader = WorldManger.Instace.SpawnSquadLeader(Units[i],this);

					squadleader.GetComponent<SoliderAI>().IsSquadLeader = true;

					break;
				}
			}
		}
		else{

			return;
		}
	}
	/// Move the Squad.
	/// </summary>
	/// <param name="MovePos">Move position.</param>
	public void SquadMove(Vector3 MovePos) {

		for (int i = 0; i < Units.Count; i++) {

			Units[i].GetComponent<SoliderAI>().StartPath(MovePos);

		}
	}
	/// <summary>
	/// Selects the state of the Squad.
	/// </summary>
	/// <param name="State">If set to <c>true</c> state.</param>
	public void SelectState(bool State) {

		for (int x = 0; x < Units.Count; x++) {
		
			Units[x].transform.FindChild("Circle").gameObject.SetActive(State);
		}
	}
	/// <summary>
	/// Gives the unit a weapon.
	/// </summary>
	/// <param name="Unit">Unit.</param>
	public void GetWeapon (GameObject Unit) {

		for (int i = 0; i < SquadWeapons.Count; i++) {

			if (SquadWeapons[i].InUse = false) {

				Unit.GetComponent<SoliderAI>().MyWeapon = SquadWeapons[i];
			}
		}
	}
}