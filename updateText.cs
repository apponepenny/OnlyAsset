using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class updateText : MonoBehaviour {
	public Transform Gvr;
	public Transform Head;

	public Transform MainC;
	public Transform cameraLeft;
	public Transform cameraRight;
	public Transform UI;
	public StereoController MainCSC;

	public bool a = false;
	public bool b = false;
	public bool c = false;
	public bool d = false;



	// Use this for initialization
	void Start () {
//		GvrProfile.GetKnownProfile (GvrProfile.ScreenSizes.iPhone5,GvrProfile.ViewerTypes.CarVR);
	}
	
	// Update is called once per frame
	void Update () {




		this.GetComponent<Text> ().text = "aY : " + Contorl_Example.BLE_aY + " \n"

			/*
		+ "Profile.width : " + Gvr.GetComponent<GvrViewer> ().Profile.screen.width + " \n"
		+ "Profile.border : " + Gvr.GetComponent<GvrViewer> ().Profile.screen.border + " \n"
		+ "Profile.height : " + Gvr.GetComponent<GvrViewer> ().Profile.screen.height + " \n"


		+ "Profile.inner : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.maxFOV.inner + " \n"
		+ "Profile.lower : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.maxFOV.lower + " \n"
		+ "Profile.outer : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.maxFOV.outer + " \n"
		+ "Profile.upper : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.maxFOV.upper + " \n"

		+ "Profile.alignment : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.lenses.alignment + " \n"
		+ "Profile.offset : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.lenses.offset + " \n"
		+ "Profile.screenDistance : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.lenses.screenDistance + " \n"
		+ "Profile.separation : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.lenses.separation + " \n"
		+ "Profile.distortion.Coef : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.distortion.Coef [0] + " | " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.distortion.Coef [1] + " \n"

		+ "Profile.inverse.Coef : " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.inverse.Coef [0] + " | " + Gvr.GetComponent<GvrViewer> ().Profile.viewer.inverse.Coef [1] + " \n"
*/



		

			+ "Camera Field : " + cameraLeft.GetComponent<Camera>().fieldOfView+" \n"
			+ "Camera nearClipPlane : " + cameraLeft.GetComponent<Camera>().nearClipPlane+" \n"
			+ "Camera farClipPlane : " + cameraLeft.GetComponent<Camera>().farClipPlane+" \n"
	

	

			+ "Connect : " + GameStaticData.isConnect.ToString()+" \n";




	}
}
