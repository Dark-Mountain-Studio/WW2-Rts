using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject unit;

	void Start (){

		WorldManger.Instace.SpawnPointList.Add(this.gameObject);
	}

	public void SpawnSquad (){

		StartCoroutine(SquadSpawn());
	}
		
	int lastSquad;

	public int LastSquad {
		get {
			return lastSquad;
		}
	}

	IEnumerator SquadSpawn (){


		for (int i = 0; i < WorldManger.Instace.squadlist.Count; i++) {
			
			print("Tested_Squad_" + i); 

			if (WorldManger.Instace.squadlist[i].InPlay == false){
				if (WorldManger.Instace.squadlist[i].TeamID == "Team_0") {
					
				print("Found Not InPlay Squad");

				WorldManger.Instace.squadlist[i].InPlay = true;

				lastSquad = i;

				for (int x = 0; x < WorldManger.Instace.squadlist[i].SquadSize; x++) {

					var Unit = Instantiate (unit , new Vector3 (this.transform.position.x + (x + 1f),this.transform.position.y + 1.01f,this.transform.position.z), Quaternion.identity); {

						Unit.name = "Unit_" + x;
					}
						

						yield return new WaitForSeconds(0.5f);

					}
				}
				WorldManger.Instace.squadlist[i].NewSquadLeader();

				yield break;

				} else {

				Debug.LogWarning("No available Squad found");
			}
		}

		yield break;
	}
}
