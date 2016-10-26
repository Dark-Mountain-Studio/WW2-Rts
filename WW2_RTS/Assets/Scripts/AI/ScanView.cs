using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScanView : MonoBehaviour {

	Vector3 Pos;
	Vector3 Dir;

	List<GameObject> ScanList;

	RaycastHit Hit;

	//Scan The Units FoV
	public void Scan (int ViewAngle, float ViewDis, Squad ThisSquad){

		//Create the Scan List if it dose not exist yet
		if(ScanList == null){

			ScanList = new List<GameObject>();
		}

		//sets the rotation to the parrent rotation
		Pos = this.transform.position;

		this.transform.localRotation = this.transform.parent.rotation;

		//Loop the Feld of view
		for (int i = 0; i < ViewAngle; i++) {
			
			//sets the rotation to the parrent rotation
			Dir = (Quaternion.AngleAxis((ViewAngle / 2) + i,Vector3.up) * this.transform.localRotation) * Vector3.forward * ViewDis;

			//Draws a debug line
			Debug.DrawRay(Pos,Dir,Color.red, 0.1f, true);
		
			if (Physics.Raycast(Pos,Dir,out Hit,ViewDis)) {

				if(Hit.transform.tag != ThisSquad.TeamID){

					if(ScanList.Contains(Hit.transform.gameObject) == false){

						ScanList.Add(Hit.transform.gameObject);

					}
				}
			}
		}
	}
}