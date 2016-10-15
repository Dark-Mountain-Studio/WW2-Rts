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
		StartCoroutine(CheckInput());

	}

	void Update() 
	{
		transform.LookAt(Camera.main.transform.position, -Vector3.up);
	}


	IEnumerator CheckInput(){
		
		while (Iswaiting == true){
			
			if (Input.GetMouseButton(1)) {

				ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				Physics.Raycast(ray,out temp);

				print("Mouse Click");
				mysquad.SquadMove(temp.point);

				Iswaiting = false;
				yield break;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}