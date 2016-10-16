using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;


public class SoliderAI : MonoBehaviour {

	//The point to move to
	Vector3 targetPosition;

	public float ViewDis = 100;

	public int ViewAngle = 100;

	public Squad Mysquad;

	private Seeker seeker;
	private CharacterController controller;
	private ScanView scanview;

	public Path Path;

	bool IsMoving = false;
	public bool IsSquadLeader = false;

	public float Speed = 500;

	public float NextWaypointDistance = 3;

	public int UnitNumber = 0;

	private int CurrentWaypoint = 0;

	public void Start () {

		seeker = this.GetComponent<Seeker>();

		controller = this.GetComponent<CharacterController>();

		Mysquad = WorldManger.Instace.squadlist[CloesetsSpawnPoint().GetComponent<Spawner>().LastSquad];
			
		Mysquad.AddUnit(this.gameObject);

		if (IsSquadLeader == true) {
		
			scanview = this.GetComponentInChildren<ScanView>();
		}
	}
	public void Update(){

		if(IsSquadLeader == true) {

			scanview.Scan(ViewAngle,ViewDis, Mysquad);
		}
	}

	//start a path whit the passed Vector3 as the end point
	public void StartPath (Vector3 targetpos){
		targetPosition = RandmizePos(targetpos);

		seeker.StartPath (transform.position,targetPosition, OnPathComplete);
	
	}


	//The Path has bein caluculated do this
	void OnPathComplete (Path p) {

		if (!p.error) {
			Path = p;
			//Reset the waypoint counter
			CurrentWaypoint = 0;

			StartCoroutine(Move());
		}
	}

	//Moves The unit
	public IEnumerator Move () {
		

	if (IsMoving == false){

		IsMoving = true;
	
	while (true) {

			if (Path == null) {
			//We have no path to move after yet
				yield break;
		}
			if (CurrentWaypoint >= Path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
					IsMoving = false;

				yield break;
		}
		//Direction to the next waypoint
		Vector3 dir = (Path.vectorPath[CurrentWaypoint]-transform.position).normalized;

			dir *= Speed * Time.deltaTime;

				controller.SimpleMove (dir);

		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,Path.vectorPath[CurrentWaypoint]) < NextWaypointDistance) {
				CurrentWaypoint++;
			
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForEndOfFrame();
			}
		} 
	}

	//Finds SpawnPoint
	GameObject CloesetsSpawnPoint () {

		float Dis = 0;
		float MinDis = 0;
		int RI = 0;

		//Check the array
		for (int i = 0; i < WorldManger.Instace.SpawnPointList.Count; i++) {
			
			Dis = Vector3.Distance(WorldManger.Instace.SpawnPointList[i].transform.position, this.transform.position);
		
			if (i < 1){

				MinDis = Dis;
			}
			if (Dis < MinDis){
				RI = i; 

				MinDis = Dis;
			}
		}
		return WorldManger.Instace.SpawnPointList[RI];
	}

	Vector3 RandmizePos (Vector3 Pos) {

		Vector3 Rpos = new Vector3(Pos.x + Random.Range(-4,4),Pos.y,Pos.z + Random.Range(-4,4));

		return Rpos;
	}
}