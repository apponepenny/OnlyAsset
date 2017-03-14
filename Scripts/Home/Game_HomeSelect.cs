using UnityEngine;
using UnityEngine.UI;

//using startechplus.ble;
using System.Collections;
using System.Collections.Generic;
using System;

namespace startechplus.ble.examples
{
public class Game_HomeSelect : MonoBehaviour {
	public int num = 1;
	public int numm;

	public Quaternion targetpos;
		public GameObject SettingPage;
		public GameObject SelectMapPage;
		public GameObject SelectTrackPage;
		public GameObject SelectCarPage;
		float checktime = 0;
		Quaternion CamRot;
		public Transform Gvr;
		public Text StarCount;
		public GameObject LeftNext;
		public GameObject RightNext;

	// Use this for initialization
	void Start () {
			GameStaticData.HaveStar = PlayerPrefs.GetInt ("HaveStar");
			StarCount.text = GameStaticData.HaveStar.ToString ();
			if (GameStaticData.isGameBack) {
				GameObject a = Instantiate (SelectMapPage,Vector2.zero,Quaternion.identity) as GameObject;
				a.SetActive (false);
				StarCount.gameObject.SetActive(true);

				GameObject b = Instantiate (SelectTrackPage, Vector2.zero, Quaternion.identity) as GameObject;
				GameStaticData.isGameBack = false;
				b.transform.GetChild (0).GetComponent<SelectTrack> ().SelectMapPage = a;
				this.transform.gameObject.SetActive (false);
				GameObject.Find ("GvrMain").transform.rotation = Quaternion.Euler (0, 0, 0);

				GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild (0).rotation = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild (0).GetChild (0).rotation = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild (0).GetChild (1).rotation = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;

			} else {
				GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().trackPosition = true;
				GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().trackRotation = true;
			}
			GameObject.Find ("BLECanvas").GetComponent<BLETestScript> ().bleStopScan ();
			GameStaticData.canMotor = false;
	}


	// Update is called once per frame
	void Update () {

		

		//	Resources.UnloadUnusedAssets ();
		
		//	GameObject.Find ("Canvas").transform.FindChild ("check").GetComponent<Text> ().text = "Connect : "+GameObject.Find ("ButtonControl").GetComponent<HelpButton> ().isConnected.ToString();

			StarCount.gameObject.SetActive(false);
		
				this.transform.localRotation = Quaternion.RotateTowards (this.transform.localRotation, targetpos, 100 * Time.deltaTime);

		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if((Contorl_Example.BLE_aY > 0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)){
				GameStaticData.canButton_aY = false;
				num--;
				CheckNum ();
				numm -= 45;
				//transform.Rotate (new Vector3(0,-45,0));
				if (numm >= -45) {

				targetpos = Quaternion.Euler (0, numm, 0);
						} else {
							numm += 45;
						}
			print (num);
		}

		
		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if((Contorl_Example.BLE_aY <-0.5f&& GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
				GameStaticData.canButton_aY = false;
			num++;
			CheckNum ();
			//transform.Rotate (new Vector3(0,45,0));
			numm += 45;
			if (numm <= 45) {

				targetpos = Quaternion.Euler (0, numm, 0);
			} else {
				numm -= 45;
			}
		
		}
	//	if (Input.GetKeyDown (KeyCode.A)) {
			if((Contorl_Example.BLE_RB && GameStaticData.canButton_RB)|| Input.GetKeyDown (KeyCode.A)){
				GameStaticData.canButton_RB = false;
		
					input_go ();

			}

			reset_All_Button ();
		
			switch(num){
			case 0:
				LeftNext.SetActive (true);
				RightNext.SetActive (false);

				break;
			case 1:
				LeftNext.SetActive (true);
				RightNext.SetActive (true);
				break;
			case 2:
				LeftNext.SetActive (false);
				RightNext.SetActive (true);
				break;

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

	void input_go(){
			//GameObject.Find ("GvrMain").transform.FindChild ("Head").position = new Vector3(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild(0).localPosition = new Vector3(0,0,0);

			GameObject.Find ("GvrMain").transform.rotation = Quaternion.Euler(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild(0).rotation = Quaternion.Euler(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild(0).GetChild(0).rotation = Quaternion.Euler(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetChild(0).GetChild(1).rotation = Quaternion.Euler(0,0,0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;


		switch (num) {
			case 0:
				print ("Go To Setting");
		//	GameObject.Find("Canvas").transform.FindChild("AudioSetting").gameObject.SetActive (true);
				this.transform.gameObject.SetActive (false);
				GameObject a = Instantiate (SettingPage, Vector2.zero, Quaternion.identity) as GameObject;
		//	a.transform.parent = this.transform;
				a.transform.localPosition = new Vector3 (290, 200, 672);
				a.transform.localRotation = Quaternion.Euler (0, 180, 0);
		

			break;
		case 1:
			print ("Go To Race!");
			this.transform.gameObject.SetActive (false);
			GameObject b = Instantiate (SelectMapPage,Vector2.zero,Quaternion.identity) as GameObject;
				StarCount.gameObject.SetActive(true);

			break;
			case 2:
				print ("Go To Garage");
				this.transform.gameObject.SetActive (false);
			//this.transform.parent.parent.FindChild("background").gameObject.SetActive (false);
				StarCount.gameObject.SetActive(true);


				GameObject c = Instantiate (SelectCarPage) as GameObject;
				//c.transform.localPosition = new Vector3 (0,2,2);
			break;

		}

	}

	void CheckNum(){

		if (num > 2)
			num = 2;
		if (num < 0)
			num = 0;
	/*	switch (num) {
		case 0:
			for (int i = 0; i < 3; i++) {
				this.transform.GetChild (i).localScale = new Vector3 (1,1,1);
			}
			this.transform.FindChild ("Setting").SetAsLastSibling();
			this.transform.FindChild ("Setting").localScale = new Vector3 (1.5f, 1.5f, 1.5f);
			break;
		case 1:
			for (int i = 0; i < 3; i++) {
				this.transform.GetChild (i).localScale = new Vector3 (1,1,1);
			}

			this.transform.FindChild ("Race").SetAsLastSibling();
			this.transform.FindChild ("Race").localScale = new Vector3 (1.5f, 1.5f, 1.5f);
			break;
		case 2:
			for (int i = 0; i < 3; i++) {
				this.transform.GetChild (i).localScale = new Vector3 (1,1,1);
			}
			this.transform.FindChild ("Garage").SetAsLastSibling();
			this.transform.FindChild ("Garage").localScale = new Vector3 (1.5f, 1.5f, 1.5f);
			break;

		}
		*/
	}
}
}