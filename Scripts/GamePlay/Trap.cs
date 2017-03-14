using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;
using System.Runtime.InteropServices;
namespace UnityStandardAssets.Vehicles.Car
{
	public class Trap : MonoBehaviour {
		public GameObject playerCar;
		float t;
		float speedbar;
		public Image boost;
		public MotionBlur motionblur;
		public gameManagerBehaviour gameManager;
		public Cam_SmoothFollow CamSmooth;
		public ControlCam ControlCamera;
		public GameObject Effect;
		public Transform MainCam;
		float CamView;

		// Use this for initialization
		void Start () {
			StartCoroutine (delayStart());
		}
		IEnumerator delayStart(){
			yield return new WaitForSeconds (2f);
			playerCar = GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).gameObject;
			motionblur = GameObject.Find ("GvrMain").transform.FindChild ("Stereo Render").FindChild ("PostRender").GetComponent<MotionBlur> ();
			gameManager = GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ();
			CamSmooth = GameObject.Find ("GvrMain").GetComponent<Cam_SmoothFollow> ();
			ControlCamera = GameObject.Find ("GvrMain").GetComponent<ControlCam> ();
			MainCam = GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0);
		
		}
		// Update is called once per frame
		void Update () {



		}

		void AddSpeed(){

			if(Effect == null)
				Effect = GameObject.FindWithTag ("UIUI").transform.FindChild("Speed").GetChild(0).FindChild("BoostEffect").gameObject;
			
			//playerCar.transform.FindChild ("Afterburner").gameObject.SetActive (true);
		
			GameStaticData.isAddSpeed = true;
			StartCoroutine (delay ());
	
			motionblur.enabled = true;
			motionblur.blurAmount = 0.75f;
			Effect.SetActive(true);
		}

		void OnTriggerEnter(Collider other){
			if (other.transform.parent.name  == "1") {
				RMCRealisticMotorcycleController RMCCControl = other.GetComponent<RMCRealisticMotorcycleController> ();
				if(RMCCControl.AddSpeedSec <4)
					RMCCControl.AddSpeedSec ++;

			}
		}

		IEnumerator delay(){
			GameStaticData.canMotor = true;
			if (this.name == "TrapBlue") {
				yield return new WaitForSeconds (1f);
			}else if (this.name == "TrapYellow") {
				yield return new WaitForSeconds (2f);
			}else if (this.name == "TrapRed"){
				yield return new WaitForSeconds (3f);
			}
			gameManager.IsAddSpeed = false;
			GameStaticData.isAddSpeed = false;
			//playerCar.transform.FindChild ("Afterburner").gameObject.SetActive (false);
			motionblur.enabled = false;
			GameStaticData.canMotor = false;
			//motionblur.blurAmount = 0.2f;
			//CamSmooth.distance = CamView;
		
			Effect.SetActive(false);
			MainCam.localPosition = new Vector3 (0,0,0);
			//GameObject.FindWithTag ("VRCam").transform.FindChild ("Head").GetChild (0).GetChild (1).GetComponent<MotionBlur> ().enabled = false;
			//Destroy (this.gameObject);
		}
	}
}

