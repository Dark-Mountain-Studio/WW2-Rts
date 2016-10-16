using UnityEngine;
using System.Collections;

public class SquadSpritesController : MonoBehaviour {

	RaycastHit temp;
	Ray ray;

	bool Iswaiting;

	Squad mysquad;


	void OnMouseDown (){
		//Sets the Squad
		if (mysquad == null){
		
			mysquad = this.transform.parent.gameObject.GetComponent<SoliderAI>().Mysquad;

		}

		print("OnMouseDown");

		Iswaiting = true;

		mysquad.SelectState(true);
		StartCoroutine(CheckInput());

	}

	void Update() 
	{
		//Makes the button always face the cammera
		transform.LookAt(Camera.main.transform.position, -Vector3.up);
	}


	IEnumerator CheckInput(){
		
		while (Iswaiting == true){

			//waits until the player has selected the pos to move to
			if (Input.GetMouseButton(1)) {

				ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				Physics.Raycast(ray,out temp);

				print("Mouse Click");
				mysquad.SquadMove(temp.point);

				//Clean up
				Iswaiting = false;
				mysquad.SelectState(false);


				yield break;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}