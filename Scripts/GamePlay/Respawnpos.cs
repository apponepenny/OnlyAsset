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
		public GameObject StartJump;
		public GameObject EndJump;
		public GameObject RespawnPt;
		public GameObject Reset;
		public float resetTime = 0;
		public int respawnDistance;

		public bool Jumping = false;
	// Use this for initialization
	void Start () {
			gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();
			waypointC = GameObject.Find ("Waypoints").GetComponent<WaypointCircuit> ();

			if (GameObject.Find ("StartJump")) 
				StartJump = GameObject.Find ("StartJump");

			if(GameObject.Find("EndJump"))
				EndJump = GameObject.Find("EndJump");
			if(GameObject.Find("RespawnPt"))
				RespawnPt = GameObject.Find("RespawnPt");
			if (GameObject.Find ("Reset")) {
				Reset = GameObject.Find ("Reset");
				Reset.SetActive (false);
			}
			respawnDistance = 70;

		}

		/*
		void reset_All_Button(){
			if (!Contorl_Example.BLE_RB) {
				GameStaticData.canButton_RB = true;
			}
			if (!Contorl_Example.BLE_LB) {
				GameStaticData.canButton_LB = true;
			}
			if (!Contorl_Example.BLE_RT) {
				GameStaticData.canButton_RT = true;
			}
			if (!Contorl_Example.BLE_LT) {
				GameStaticData.canButton_LT = true;
			}
			if (Contorl_Example.BLE_aY <= 0.5f && Contorl_Example.BLE_aY >= -0.5f) {
				GameStaticData.canButton_aY = true;
			}
		}
		*/
	// Update is called once per frame
	void Update () {
			//	reset_All_Button();
		//	GameObject.Find ("Canvas").transform.FindChild ("aaa").GetComponent<Text> ().text = distance.ToString ();
			/*
			if(Contorl_Example.BLE_RT){
				
				resetTime += Time.deltaTime;
			}
*/

		if(GameStaticData.isStart)
			cooldownRespawn += Time.deltaTime;
			distance = Vector3.Distance (NormalRespawnPt.position, this.transform.position);
	
			if (player.parent.name == "1" && !GameStaticData.isFinish) {
			//	if (cooldownRespawn > 4 && ((this.transform.parent.parent.GetComponent<RCCCarControllerV2> ().speed < 5f || distance > 45 )||	Contorl_Example.BLE_RT || Input.GetKeyDown(KeyCode.Z))) {
				if (cooldownRespawn > 2 && ((GameStaticData.isCol || distance > respawnDistance) ||	Contorl_Example.BLE_RT || Input.GetKeyDown (KeyCode.Z))) {
			
					GameStaticData.IsRespawn = true;
					GameStaticData.isCol = false;
					//Contorl_Example.BLE_RT = false;

					if (!Jumping) {
						tempRespawnPos = NormalRespawnPt.position;

					} else {
						tempRespawnPos = RespawnPt.transform.position;
					}

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

		void OnTriggerEnter(Collider other){
			if (this.transform.parent.name == "1") {
				if (other.gameObject == StartJump) {
					Jumping = true;
					Reset.SetActive (true);
					respawnDistance = 80;
					GetComponent<WaypointProgressTracker> ().isFlyRes = true;
					print ("Start Jumping");
				}
				if (other.gameObject == EndJump) {
					Jumping = false;
					Reset.SetActive (false);

					respawnDistance = 45;
					print ("End Jumping");
					GetComponent<WaypointProgressTracker> ().isFlyRes = false;

				}

				if (other.gameObject == Reset) {
					GameStaticData.isCol = true;


				}

				if (other.CompareTag ("sea")) {
			
						RenderSettings.fog = true;
					
					RenderSettings.fogColor = new Color (0.22f, 0.65f, 0.77f, 0.5f);
					RenderSettings.fogDensity = 0.03f;
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