using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
using System;

namespace UnityStandardAssets.Vehicles.Car
{

	public class LoadBLE : MonoBehaviour {

		public GameObject BLECanvas;
		public GameObject ReScanBLE;
		public Transform ui;
		// Use this for initialization

		void Start () {
			DontDestroyOnLoad (this.gameObject);
			
			//BLETest = GameObject.Find ("Canvas").GetComponent<BLETestScript> ();
			//BLETest.PanelActive = this.transform.FindChild ("PanelActive");
			//BLETest.PanelInActive = this.transform.FindChild ("PanelInActive");
			//BLETest.PanelTypeSelection = this.transform.FindChild ("PanelInActive").FindChild ("PanelTypeSelection");
			//BLETest.PanelCentral = this.transform.FindChild ("PanelInActive").FindChild ("PanelCentral").GetComponent<CentralScript>();
			Application.targetFrameRate = 45;
		

			GameObject a = Instantiate (BLECanvas) as GameObject;

			a.name = "BLECanvas";


			#if UNITY_EDITOR
			this.enabled = false;
			#endif

		//	this.gameObject.name = "BLECanvas";
		}
		public void BLEScan(){

			StartCoroutine (ClickWait());

		
		}
		public Button ScanButton;
		IEnumerator ClickWait(){
			ScanButton.enabled = false;
			yield return new WaitForSeconds (1f);
			ScanButton.enabled = true;
		}

		
		// Update is called once per frame
		void Update () {
	
		
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
			}
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			if (!GameStaticData.isConnect && !GameStaticData.InReScan  && !GameObject.Find("ScreenLoad(Clone)") ) {
			//if (!GameStaticData.isConnect && !GameStaticData.InReScan &&(!GameObject.Find("ScreenLoadNormal(Clone)") && !GameObject.Find("ScreenLoad(Clone)") )) {

				if (GameStaticData.isGO) {

					Destroy (GameObject.Find ("BluetoothLEReceiver"));
					Destroy (GameObject.Find ("BLECanvas"));
					//StartCoroutine (delay());


					GameObject BLE = Instantiate (ReScanBLE) as GameObject ;
					#if UNITY_IPHONE
					if (GameStaticData.sceneName == "Start") {
						BLE.transform.parent = ui;
						BLE.transform.localPosition = new Vector3 (-3.6f, -1.77f, 2.5f);
					
					} else {
						BLE.transform.parent = GameObject.FindWithTag ("UIUI").transform;
						BLE.transform.localPosition = new Vector3 (-2.59f, -1.77f, 2.5f);
					}
					BLE.transform.localRotation = Quaternion.Euler (0,0,0);
					#elif UNITY_ANDROID
					if(GameStaticData.isStart){
						BLE.transform.parent = GameObject.FindWithTag ("UIUI").transform;
						BLE.transform.localPosition = new Vector3 (-2.59f, -1.77f, 2.5f);
						BLE.transform.localRotation = Quaternion.Euler (0,0,0);
					}



					#endif


					GameStaticData.InReScan = true;

					GameStaticData.canButton_RB = false;
					GameStaticData.canButton_LB = false;
					GameStaticData.canButton_RT = false;
					GameStaticData.canButton_LT = false;
					/*
					//ReScanBLE.SetActive(true);
					if (GameStaticData.isStart && GameStaticData.sceneName != "Game_Home" && GameStaticData.sceneName != "Start" ) {
						Destroy (GameObject.Find ("BluetoothLEReceiver"));
						Destroy (GameObject.Find ("BLECanvas"));
						//StartCoroutine (delay());


						GameObject BLE = Instantiate (Resources.Load ("Prefabs/ReScanBLE")) as GameObject ;
						BLE.transform.parent = GameObject.FindWithTag ("UIUI").transform;
						BLE.transform.localPosition = new Vector3 (-2.59f,-1.77f,2.5f);
						BLE.transform.localRotation = Quaternion.Euler (0,0,0);

						GameStaticData.InReScan = true;


						//GameObject.FindWithTag ("VRCam").transform.GetChild (0).GetChild (0).FindChild ("UI").transform.FindChild ("GamePlaySetting").gameObject.SetActive (true);

						//GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ().isStop = true;


					} else if(GameStaticData.sceneName == "Game_Home") {

						Destroy (GameObject.Find ("BluetoothLEReceiver"));
						Destroy (GameObject.Find ("BLECanvas"));



						GameObject BLE = Instantiate (Resources.Load ("Prefabs/ReScanBLE")) as GameObject ;
						BLE.transform.parent = GameObject.FindWithTag ("UIUI").transform;
						BLE.transform.localPosition = new Vector3 (-2.59f,-1.77f,2.5f);
						BLE.transform.localRotation = Quaternion.Euler (0,0,0);
						GameStaticData.InReScan = true;

					}

					else if(GameStaticData.sceneName == "Start") {
						StartCoroutine (delay());


					}
			


					GameStaticData.canButton_RB = false;
					GameStaticData.canButton_LB = false;
					GameStaticData.canButton_RT = false;
					GameStaticData.canButton_LT = false;



				} else {
					if (GameStaticData.disconnectTimes > 0) {
						StartCoroutine (delaya());


						GameStaticData.canButton_RB = false;
						GameStaticData.canButton_LB = false;
						GameStaticData.canButton_RT = false;
						GameStaticData.canButton_LT = false;
			

					}

					*/
				}
			




			}


//			GameObject.Find ("Canvas").transform.FindChild ("a").GetComponent<Text> ().text = GameStaticData.j.ToString();
		//	GameObject.Find ("Canvas").transform.FindChild ("b").GetComponent<Text> ().text = GameStaticData.b.ToString();

		//	GameObject.Find ("Canvas").transform.FindChild ("d").GetComponent<Text> ().text = Contorl_Example.BLE_aY.ToString();

			if (Input.GetKeyDown (KeyCode.C)) {
				GameStaticData.disconnectTimes++;
			}

		}	
	

		IEnumerator delaya(){
			Destroy (GameObject.Find ("BluetoothLEReceiver"));
			Destroy (GameObject.Find ("BLECanvas"));
			GameStaticData.InReScan = true;

			yield return new WaitForSeconds (0.5f);
			GameObject a = Instantiate (BLECanvas) as GameObject;

			a.name = "BLECanvas";

		}

		IEnumerator delay(){
			Destroy (GameObject.Find ("BluetoothLEReceiver"));
			Destroy (GameObject.Find ("BLECanvas"));
			GameStaticData.InReScan = true;

			yield return new WaitForSeconds (0.5f);

			GameObject BLE = Instantiate (Resources.Load ("Prefabs/ReScanBLE")) as GameObject ;
			BLE.transform.parent = ui;
			BLE.transform.localPosition = new Vector3 (-3.6f,-1.77f,2.5f);
			BLE.transform.localRotation = Quaternion.Euler (0,0,0);
		}
	}

}