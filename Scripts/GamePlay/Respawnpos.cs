using UnityEngine;
using UnityEngine.UI;

using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class Respawnpos : MonoBehaviour {
	public float cooldownRespawn;
	public float distance;
	public bool isStay = false;
	public bool asd;
	
		public Vector3 tempRespawnPos;
		public Rigidbody rigid;
		public Transform player;
		public CarController CarControl;
		public Transform NormalRespawnPt;
		public GameStaticData gameStaticData;
		public WaypointCircuit waypointC;
		public Transform RespawnLookPt;

		public float resetTime = 0;
		public int respawnDistance;

		public bool Jumping = false;
	// Use this for initialization
	void Start () {
			gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();
			waypointC = GameObject.Find ("Waypoints").GetComponent<WaypointCircuit> ();

			respawnDistance = 70;

		}

	
	// Update is called once per frame
	void Update () {


		if(GameStaticData.isStart)
			cooldownRespawn += Time.deltaTime;
			distance = Vector3.Distance (NormalRespawnPt.position, this.transform.position);
	
			if (player.parent.name == "1" && !GameStaticData.isFinish) {
				if (cooldownRespawn > 2 && ((GameStaticData.isCol || distance > respawnDistance) ||	Contorl_Example.BLE_RT || Input.GetKeyDown (KeyCode.Z))) {
			
					GameStaticData.IsRespawn = true;
					GameStaticData.isCol = false;
					//Contorl_Example.BLE_RT = false;
					tempRespawnPos = NormalRespawnPt.position;

			
					player.position = tempRespawnPos;

					rigid.velocity = 0 * rigid.velocity.normalized;


					//player.rotation = this.transform.rotation;
					cooldownRespawn = 0;
					gameStaticData.CheckPosD ();
					StartCoroutine (DelayLook());
					RenderSettings.fog = false;

				} else {
					GameStaticData.isCol = false;
				}


		

			} else {
			
				if (cooldownRespawn > 4 && distance > 9990) {


					print (distance);

					if (!isStay) {
						tempRespawnPos = NormalRespawnPt.position;
						player.position = tempRespawnPos;
					}
					else {
						tempRespawnPos = this.transform.parent.parent.transform.position;
						tempRespawnPos = new Vector3(tempRespawnPos.x,tempRespawnPos.y+1,tempRespawnPos.z+3);
						player.position = tempRespawnPos;
					}
					player.rotation = this.transform.rotation;
					cooldownRespawn = 0;
		
					gameStaticData.CheckPosD ();
				}


		

			
			}


	

	}

	

		IEnumerator DelayLook(){
			yield return new WaitForSeconds (0.1f);
			player.transform.LookAt (NormalRespawnPt.position);

		}
		/*
	void OnTriggerStay(Collider other){
		
			if (other.CompareTag("CarCol")) {
				isStay = true;
			}
		

	}

	void OnTriggerExit(Collider other){

					if (other.CompareTag("CarCol")) {
			isStay = false;
		}


	}
	*/
}
}