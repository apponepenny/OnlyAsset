using UnityEngine;
using System.Collections;

public class ControlCam : MonoBehaviour {
	float t;
	public float dis;
	public Transform Player;
	public RectTransform miniMap;
	public RMCRealisticMotorcycleController Control;
	public Cam_SmoothFollow  CamSmooth;
//	public GameObject FirstPersion;
	public GameObject MainCar;
	public Transform LookPt;
	public GameObject VRCam;
	public bool isFirstPersionView = false;
	public Vector3 firstpersionVecter3;
	// Use this for initialization
	void Start () {
		//dis = 7.5f;
		CamSmooth = this.GetComponent<Cam_SmoothFollow> ();
		StartCoroutine (delayStart());

	}
	public void ChangeFirstPerson(){
		if (dis == 129) {
			
			isFirstPersionView = true;
//			FirstPersion.SetActive (true);
		//	MainCar.SetActive (false);
			//LookPt.localPosition = new Vector3 (-0.46f,0.85f,2.46f);

			VRCam.transform.parent = Player.transform;
			VRCam.transform.localPosition = new Vector3(-0.42f,0.9f,0.38f);

			//Player.GetComponent<RMCRealisticMotorcycleController> ().FrontLeftWheelTransform.gameObject.SetActive (false);
			//Player.GetComponent<RMCRealisticMotorcycleController> ().FrontRightWheelTransform.gameObject.SetActive (false);
			VRCam.transform.LookAt (LookPt);
	//		FirstPersion.SetActive (true);

			CamSmooth.enabled = false;
			VRCam.transform.localRotation = Quaternion.Euler(0,0,0);

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
	bool speeding = false;
	// Update is called once per frame
	void Update () {


		if (GameStaticData.PlayMode == GameStaticData.GameMode.GP) {
			VRCam.transform.GetChild (0).localEulerAngles = new Vector3 (290,0,10*GameStaticData.steerAngles);
		}


		reset_All_Button ();
		//upRoad ();

		if (isFirstPersionView) {
		
		
		
			//CamSmooth.distance = 2.4f;
			//CamSmooth.height = 0f;

		} else {
		
			if (GameStaticData.isAddSpeed) {
				speeding = true;
				CamSmooth.distance = Mathf.Lerp(CamSmooth.distance,15,10*Time.deltaTime);

			} else {
				if (speeding) {
					CamSmooth.distance = Mathf.Lerp (CamSmooth.distance, dis, 10 * Time.deltaTime);		
					if (CamSmooth.distance <= dis + 0.5f) {
						speeding = false;
					}
				}
				else
					CamSmooth.distance = dis;

			}
		}


		if (((Contorl_Example.BLE_LT && GameStaticData.canButton_LT) || Input.GetKeyDown (KeyCode.E)) && GameStaticData.isStart) {
				dis += 1.5f;
				if (dis == 129) {
					ChangeFirstPerson ();
			
				} else {
					isFirstPersionView = false;
				//	FirstPersion.SetActive (false);
		
					//MainCar.SetActive (true);
					LookPt.localPosition = new Vector3 (0,0.85f,2.46f);

					VRCam.transform.parent = null;
				CamSmooth.enabled = true;
				//Player.GetComponent<RMCRealisticMotorcycleController> ().FrontLeftWheelTransform.gameObject.SetActive (true);
				//Player.GetComponent<RMCRealisticMotorcycleController> ().FrontRightWheelTransform.gameObject.SetActive (true);

				}
				if (dis > 12f) {
					dis = 7.5f;
				}
			GameStaticData.ViewAngle = (int)((dis - 7.5) / 1.5f);
			PlayerPrefs.SetInt ("ViewNum",GameStaticData.ViewAngle);
			GameStaticData.canButton_LT = false;
			}
		
	}

	IEnumerator delayStart(){
		yield return new WaitForSeconds(1f);
		CamSmooth.target = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).FindChild("LookPt");
		CamSmooth.distance = dis;
		CamSmooth.height = 1;

		Player = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0);
//		miniMap.GetChild (0).GetComponent<MiniMapController>().playerPos = Player;
	//	miniMap.parent = GameObject.FindWithTag ("UIUI").transform.GetChild (0).GetChild (0);
	//	miniMap.GetComponent<RectTransform> ().localPosition = new Vector3 (0,0,0);

	//	miniMap.GetChild (0).GetComponent<RectTransform> ().localPosition = new Vector3 (0.5f,2.846f,1.297f);
	//	miniMap.GetChild (0).GetChild (0).GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0,0,0);
		Control = GameObject.Find("CarStartPoint").transform.GetChild(0).GetChild(0).GetComponent<RMCRealisticMotorcycleController>();

	//	FirstPersion = Player.FindChild ("FirstPerson").transform.FindChild("Main").gameObject;
//		MainCar = Player.FindChild ("carMain").gameObject;
		LookPt = Player.FindChild ("LookPt");
		VRCam = GameObject.FindWithTag ("VRCam");
	}


	void upRoad(){
		if (Player.transform.localRotation.eulerAngles.x < 358 && Player.transform.localRotation.eulerAngles.x > 345) {
		//	this.GetComponent<Cam_SmoothFollow> ().height = 2f;
			print("UPUP");

		} else {
		//	this.GetComponent<Cam_SmoothFollow> ().height = 1;
		}

		
	}
}
