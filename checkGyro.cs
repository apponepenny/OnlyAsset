using UnityEngine;
using System.Collections;

public class checkGyro : MonoBehaviour {
	public Transform C;
	float startY;
	Quaternion rotFix;
	// Use this for initialization
	void Start () {

		#if UNITY_IPHONE
		if (!GameStaticData.isVR) {
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = false;

			this.transform.GetChild (0).GetComponent<GvrHead> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye>().enabled =false;

			this.transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			this.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
	
		} else if (SystemInfo.supportsGyroscope ) {
			
				this.GetComponent<GvrViewer> ().enabled = true;
				this.GetComponent<GvrViewer> ().VRModeEnabled = true;

				this.transform.GetChild (0).GetComponent<GvrHead> ().enabled = true;
				this.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = true;
				this.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
				this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = true;
				this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = true;

				GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = true;
				GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = true;
				GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
		}else{
			
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;

	
		}
		#elif UNITY_ANDROID
		if (!GameStaticData.isVR) {
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = false;

			this.transform.GetChild (0).GetComponent<GvrHead> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye>().enabled =false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye>().enabled =false;

			this.transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			this.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;

		} else if (SystemInfo.supportsGyroscope ) {

			this.GetComponent<GvrViewer> ().enabled = true;


			this.transform.GetChild (0).GetComponent<GvrHead> ().enabled = true;
	

			this.transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = true;

			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;

			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = true;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = true;
			GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
		}else{

			this.transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
			this.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;


		}
		#endif


	}
			
	
	// Update is called once per frame
	void Update () {

	}

}
