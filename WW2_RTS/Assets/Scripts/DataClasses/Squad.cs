using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Squad {

	public List<GameObject> Units;

	public GameObject squadleader;

	public bool InPlay;


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
	public Squad (int Size){

		InPlay = false;

		Squadsize = Size;
	
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

	public void NewSquadLeader () {
	
		if (squadleader == null) {

			for (int i = 0; i < Units.Count; i++) {

				if (Units[i] != null) {

					squadleader = WorldManger.Instace.SpawnSquadLeader(Units[i],i,this);

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
}