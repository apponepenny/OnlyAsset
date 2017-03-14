using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class chooseYourView : MonoBehaviour {
	public GameObject _SelectTrack;
	public SelectTrack ST;
	public int ViewNum;
	public Image Im;
	public Sprite[] _Im = new Sprite[4];
	public Transform ViewSelect;

	// Use this for initialization
	void Start () {
		ViewNum = 3;
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
	// Update is called once per frame
	void Update () {
		reset_All_Button ();

		if ((Contorl_Example.BLE_LT && GameStaticData.canButton_LT ) || Input.GetKeyDown (KeyCode.E)) {
			GameStaticData.canButton_LT = false;
			ViewNum++;
			if (ViewNum > 3) {
				ViewNum = 0;
			}
			Im.sprite = _Im [ViewNum]; 
			for (int i = 0; i < 4; i++) {
				ViewSelect.GetChild (i).GetComponent<Text> ().color = new Color (0,0,0);
			}
			ViewSelect.GetChild (ViewNum).GetComponent<Text> ().color = new Color (1,1,0);
			print (ViewNum);
		}

	
		if (((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) && !GameObject.Find ("ScreenLoad(Clone)")) {

		
				print ("Is not first time in IsfirstChoose");
			PlayerPrefs.SetInt ("IsfirstChoose", 1);

				PlayerPrefs.SetInt ("ViewNum",ViewNum);
				GameStaticData.ViewAngle = ViewNum;

				GameStaticData.canButton_RB = false;
	

					//GameStaticData.sceneName = "5_1";

					GameObject hi = Instantiate (ST.ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
					hi.transform.localPosition = new Vector3 (0, 0, 260);





					//GameStaticData.PlayLap = GameStaticData.MapTrackLap[(GameStaticData.SelectedMap+1)+"_"+(GameStaticData.SelectedTrack+1)];
					Destroy (this.gameObject);
					Destroy (_SelectTrack.gameObject);
					



		}
		if(((Contorl_Example.BLE_LB && GameStaticData.canButton_LB )|| Input.GetKeyDown (KeyCode.S)) && !GameObject.Find("ScreenLoad(Clone)")){
			/*
			if (!SystemInfo.supportsGyroscope) {
				GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;
			} else {

				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = true;
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = true;
			}

			GameObject.Find ("Button").transform.GetChild(0).gameObject.SetActive(true);
*/
			GameStaticData.canButton_LB = false;

			GameObject b = Instantiate (ST.SelectMapPage,Vector2.zero,Quaternion.identity) as GameObject;

			Destroy (this.gameObject);
			_SelectTrack.gameObject.SetActive (true);

		}
	}
}
