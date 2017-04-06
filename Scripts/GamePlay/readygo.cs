using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class readygo : MonoBehaviour {
	public GameObject UIstart;
	Animator FadeAmin;
	public StereoController centerPlayer;
	public Transform Cam;
	public Transform ParentTran;
	public TextMesh _Text;
	public AudioSource thisAudioSo;
	public AudioSource GameManagerAudioSo;
	public gameManagerBehaviour gameManger;
		public ControlCam ControlC;
	// Use this for initialization
	void Start () {

			centerPlayer = GameObject.FindWithTag("VRCam").transform.GetChild (0).GetChild (0).GetComponent<StereoController> ();
			Cam = GameObject.FindWithTag ("VRCam").transform;
			GameObject.Find("FinishLine").transform.GetChild(0).GetComponent<TextMesh>().text = MutliLang.LangString[72];
			StartCoroutine (readygogo());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator readygogo(){
		this.gameObject.SetActive (true);

		_Text.text = MutliLang.LangString[48];
			Cam.transform.GetChild (0).localPosition = new Vector3 (0, 0, 0);
			Cam.transform.GetChild (0).localEulerAngles = new Vector3 (290, 0, 0);

	
		yield return new WaitForSeconds (1);
	
		centerPlayer.centerOfInterest = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0);
			Cam.GetComponent<Cam_SmoothFollow> ().target = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).FindChild ("LookPt");
			//Cam.parent = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0);
			//Cam.localPosition = new Vector3 (0,2f,-4.5f);
			//Cam.localEulerAngles = new Vector3 (65,0,0);

		thisAudioSo.Play ();
		thisAudioSo.volume = GameStaticData.MusicValue;
		_Text.text = "3";

		yield return new WaitForSeconds (1);
		_Text.text = "2";


		yield return new WaitForSeconds (1);
	//	yield return StartCoroutine (sf.FadeToBlack ());
		_Text.text = "1";

		yield return new WaitForSeconds (1);

		_Text.text = MutliLang.LangString[47];

		UIstart.SetActive (true);

		yield return new WaitForSeconds (0.5f);
		GameStaticData.isStart = true;

		gameManger.gameStaticData.CheckPosD ();
		Time.timeScale = 1;
		GameManagerAudioSo.Play ();
		//GameObject.FindWithTag	("UIUI").transform.FindChild("Speed").GetChild(0).FindChild("MiniMap").GetComponent<MiniMapController>().playerPos = GameObject.Find("CarStartPoint").transform.GetChild(0).GetChild(0);

		this.gameObject.SetActive (false);

	}
}
}
