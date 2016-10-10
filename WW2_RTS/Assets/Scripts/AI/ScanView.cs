using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScanView : MonoBehaviour {

	Vector3 Pos;
	Vector3 Dir;

	List<RaycastHit> ScanList;

	RaycastHit Hit;

	//Scan The Units FoV
	public void Scan (int ViewAngle, float ViewDis  ){

		//sets the rotation to the parrent rotation
		Pos = this.transform.position;

		this.transform.localRotation = this.transform.parent.rotation;

		for (int i = 0; i < ViewAngle; i++) {


			//sets the rotation to the parrent rotation
			Dir = (Quaternion.AngleAxis((ViewAngle / 2) + i,Vector3.up) * this.transform.localRotation) * Vector3.forward * ViewDis;

			//draws a debug line
			Debug.DrawRay(Pos,Dir,Color.red, 0.1f, false);
		
		}
	}
}