using UnityEngine;
using System.Collections;

public class CarmeraController : MonoBehaviour {

	public float SetCamSpeed;
	private float CamRelPosX;
	private float CamRelPosY;
	private float CamRelPosZ;
	private float RealCamSpeed;

	void Awake(){
		if (SetCamSpeed <= 0){
			SetCamSpeed = 2;
		}

		CamRelPosX = transform.position.x;
		CamRelPosY = transform.position.y;
		CamRelPosZ = transform.position.z;
	}
	void Update() {

		RealCamSpeed = SetCamSpeed;
		if (Input.GetKey(KeyCode.LeftShift)){
			RealCamSpeed = SetCamSpeed * 2;	
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.position = new Vector3(CamRelPosX -= RealCamSpeed / 2,CamRelPosY,CamRelPosZ);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.position = new Vector3(CamRelPosX += RealCamSpeed / 2,CamRelPosY ,CamRelPosZ);
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.position = new Vector3(CamRelPosX,CamRelPosY,CamRelPosZ += RealCamSpeed / 2);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.position = new Vector3(CamRelPosX,CamRelPosY,CamRelPosZ -= RealCamSpeed / 2);
		}
	}
}