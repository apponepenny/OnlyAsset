using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class SettingTurn : MonoBehaviour {

	public Quaternion targetpos;
	public float num;
	private Animator menu;
		public GameObject ScreenLoad;
	int turnNum;
		public GameObject mini;
		public GvrHead VrHead;
		public gameManagerBehaviour gameManager;
		//public 
	// Use this for initialization
	void Start () {
		menu = this.GetComponent<Animator> ();
			GameStaticData.canMotor= false;

		turnNum = 2;

	}
	
	// Update is called once per frame
	void Update () {

			
//			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation,targetpos,200*Time.deltaTime);
		reset_All_Button ();



		//	if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if((Contorl_Example.BLE_aY >0.5f&& GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.DownArrow)){
			GameStaticData.canButton_aY = false;	
				turnNum--;
				print ("Click Up");
				if (turnNum == 0) {
					menu.Play ("turndown");
		
				}
				if (turnNum == 1) {
					menu.Play ("turnUpp");
				}
			Debug.Log (turnNum);

//			transform.Rotate (new Vector3(0,0,30));
//				num += 30;
//			if (num <= 30) {
//				
//				targetpos = Quaternion.Euler (0, 0, num);
//			} else {
//				num -= 30;
//			}
//


			}
			//if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if((Contorl_Example.BLE_aY <-0.5f&& GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.UpArrow)){
			GameStaticData.canButton_aY = false;

			print ("Click Down");

				turnNum++;
				if (turnNum == 2) {

					menu.Play ("turn");
				}
				if (turnNum == 1) {

					menu.Play ("turnUp");
				}
			Debug.Log (turnNum);



				
//			num -= 30;
//			transform.Rotate (new Vector3(0,0,-30));
//			if (num >= -30) {

//				targetpos = Quaternion.Euler (0, 0, num);
//			} else {
//				num += 30;
//			}
				
		}

		if (turnNum >= 3) {
			turnNum = 2;
		}

		if (turnNum <= -1) {
			turnNum = 0;
		}

			if ((Contorl_Example.BLE_LB && GameStaticData.canButton_LB)||Input.GetKeyDown(KeyCode.C)) {
			GameStaticData.canButton_LB = false;
			Time.timeScale = 1;
				VrHead.trackPosition = false;
				VrHead.trackRotation = false;
				gameManager.isStop = false;
				GameStaticData.isstop = false;

				this.gameObject.transform.parent.parent.parent.gameObject.SetActive(false);
				//GameObject.FindWithTag ("VRCam").transform.GetChild (0).localPosition = new Vector3 (0,0,0);
			//	GameObject.FindWithTag ("VRCam").transform.GetChild (0).localRotation = Quaternion.Euler (0,0,0);
		}

		//if (Input.GetKeyDown (KeyCode.A)) {
			if((Contorl_Example.BLE_RB && GameStaticData.canButton_RB ) || Input.GetKeyDown (KeyCode.A)){
		
				GameStaticData.canButton_RB = false;
				VrHead.trackPosition = false;
				VrHead.trackRotation = false;
				GameStaticData.isstop = false;

				gameManager.isStop = false;
			//	GameObject.FindWithTag ("VRCam").transform.GetChild (0).localPosition = new Vector3 (0,0,0);
			//	GameObject.FindWithTag ("VRCam").transform.GetChild (0).localRotation = Quaternion.Euler (0,0,0);


			Time.timeScale = 1;
			switch(turnNum){
			case 0: 
				//exit
				if (!GameObject.Find ("ScreenLoad(Clone)")) {

					GameStaticData.sceneName = "Game_Home";
					//GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
						GameObject hi = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
					hi.transform.parent = VrHead.transform;
					hi.transform.localRotation = Quaternion.Euler (63, 0, 0);
					hi.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 100);
					hi.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
						hi.transform.localPosition = new Vector3 (0, -14f, 6f);
					CarCheck.currentLap = 0;
					CarCheck.currentCheckpoint = 0;
					GameStaticData.currentLap = 0;
				}
					GameStaticData.isStart = false;

				break;
			case 1:
				//restart
				if (!GameObject.Find ("ScreenLoad(Clone)")) {
				GameStaticData.sceneName = (GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1);
				//GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
			

						GameObject hiNu = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
						hiNu.transform.parent = VrHead.transform;
						hiNu.transform.localRotation = Quaternion.Euler (63, 0, 0);
						hiNu.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 100);
						hiNu.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
						hiNu.transform.localPosition = new Vector3 (0, -14f, 6f);
				
				CarCheck.currentLap = 0;
				CarCheck.currentCheckpoint = 0;
				GameStaticData.currentLap = 0;
				}
					GameStaticData.isStart = false;

				break;
				case 2:
				//resume
				//Destroy (this.gameObject.transform.parent.parent.parent.gameObject);
					this.gameObject.transform.parent.parent.parent.gameObject.SetActive (false);
					mini.SetActive (true);
					gameManager.isStop = false;

				break;
			}
		}

	}

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
}
}
