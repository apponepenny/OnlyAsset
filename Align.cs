using UnityEngine;
using System.Collections;

public class Align : MonoBehaviour {
	public GameObject ScreenLoad;
	public GameObject VRCam;
	public GameObject Cam;

	// Use this for initialization
	void Start () {
		VRCam = GameObject.Find ("GG").transform.GetChild (0).gameObject;
		Cam = GameObject.Find ("Cam");


	}
	IEnumerator delay(){

		VRCam.GetComponent<GvrViewer> ().VRModeEnabled = false;
		VRCam.GetComponent<GvrViewer> ().EnableAlignmentMarker = false;
		VRCam.GetComponent<GvrViewer> ().EnableSettingsButton = false;
		VRCam.GetComponent<GvrViewer> ().enabled = false;

		VRCam.transform.GetChild (0).GetComponent<GvrHead> ().enabled = false;
		VRCam.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
		VRCam.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
		VRCam.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = true;

		VRCam.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = false;


		yield return new WaitForSeconds (0.1f);


		VRCam.GetComponent<GvrViewer> ().enabled = true;
		VRCam.transform.GetChild (0).GetComponent<GvrHead> ().enabled = true;
		VRCam.GetComponent<GvrViewer> ().VRModeEnabled = true;
		VRCam.GetComponent<GvrViewer> ().EnableAlignmentMarker = true;
		VRCam.GetComponent<GvrViewer> ().EnableSettingsButton = false;


		VRCam.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
		VRCam.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = false;
		VRCam.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
		VRCam.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = true;

		VRCam.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
		VRCam.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;

	}
	// Update is called once per frame
	void Update () {
		if (((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) && !GameObject.Find("ScreenLoad(Clone)")) {
			Cam.SetActive (false);
			VRCam.SetActive (true);
			GameStaticData.canButton_RB = false;
			GameStaticData.sceneName = "Game_Home";
			GameObject hi = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
			hi.transform.parent = GameObject.FindWithTag ("UIUI").transform;

			hi.transform.localPosition = new Vector3 (0, 0, 260);
			hi.transform.localRotation = Quaternion.Euler(0, 0, 0);

			hi.transform.localScale = new Vector3 (0.85f,0.85f,0.85f);
			//Destroy (transform.parent.gameObject);
			GameStaticData.isVR = true;

			StartCoroutine (delay());



	


		}
	}
}
