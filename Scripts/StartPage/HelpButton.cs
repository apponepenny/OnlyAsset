using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;


	public class HelpButton : MonoBehaviour {

		public Text logText;
		public ScrollRect scrollRect;

		public Text debugText;
		public GameObject Align;
		public GameObject Canvass;
		public GameObject VRCam;
		public Transform UIUI;

		private string BLEServerID = "0000FFF0-0000-1000-8000-00805F9B34FB";

		private string BLECharacteristicID = "0000FFF2-0000-1000-8000-00805F9B34FB";
		public GameObject ScreenLoad;
		public GameObject EventSystem;
		public GameObject Mode;
		public GameObject Button;
		public GameObject Cam;
		public void SelectMode(){
			Button.SetActive(false);
			Mode.SetActive (true);

		}

		public void NonVRStartGame(){
			
			Canvass.SetActive(false);
			VRCam.SetActive(true);
		
			Mode.SetActive (false);

			GameStaticData.sceneName = "Game_Home";
			GameObject hi = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
			hi.transform.parent = GameObject.FindWithTag ("UIUI").transform;

			hi.transform.localPosition = new Vector3 (-20, 0, 230);
			hi.transform.localRotation = Quaternion.Euler(0, 0, 0);

			hi.transform.localScale = new Vector3 (0.85f, 0.85f, 0.85f);
//			Destroy (transform.parent.gameObject);
			GameStaticData.isGO = true;
			GameStaticData.isVR = false;

				Cam.SetActive (false);
		}
		public void VRStartGame(){
			Mode.SetActive (false);
//			GameObject.Find ("BLECanvas").transform.FindChild ("AlignLine").gameObject.SetActive (true);
				//GameStaticData.sceneName = "Game_Home";
				GameObject hi = Instantiate (Align, Vector2.zero, Quaternion.identity) as GameObject;

			GameStaticData.SaveMidLine = Instantiate (GameStaticData.MidLine) as GameObject;
			DontDestroyOnLoad(GameStaticData.SaveMidLine);



			//	hi.transform.localScale = new Vector2 (Screen.width, Screen.height);
				Canvass.SetActive(false);
				//VRCam.SetActive(true);
			Cam.SetActive(true);
				//hi.transform.parent = UIUI;

				hi.transform.localPosition = new Vector3 (0,50,350);
				GameStaticData.isGO = true;

			Destroy (EventSystem);



		}
		public void Help(){
			
			Application.OpenURL ("https://www.youtube.com/channel/UCM6K4iVaIomWc-VHOKvbgoA");
		}


}
