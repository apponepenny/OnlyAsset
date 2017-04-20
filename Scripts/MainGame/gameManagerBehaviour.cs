using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



namespace UnityStandardAssets.Vehicles.Car
{
		public class gameManagerBehaviour : MonoBehaviour {
		public Text Lap;
		public RMCRealisticMotorcycleController Control;
		public Text speedLabel;
		public Text speedLabel1;
		public Text speedLabel2;
		public Text speedLabel3;


		private float speedValue;
		public bool finish;
		public static int Car_Topspeed;
		public int SpeedLevel;
		public int TurnLevel;
		public GameObject startPoint;
		public GameObject StorageObject;
		float tt;
		public bool isStop;
		public GameObject[] AI = new GameObject[7];
		//LoadCarProperty loadCarProperty = new LoadCarProperty ();
		public bool IsAddSpeed;
		public char Showspeed1;
		public char Showspeed2;
		public char Showspeed3;

		public  AudioSource audioSoure;
		public Transform Player;
		bool CanAdd = true;
		public float AIDetectMe = 1;
		public Transform speedometerArrow;
		public GameObject PlaneP;
	
		public GameObject[] PlayCar = new GameObject[12];
	
		public Transform Gvr;

		public AudioSource BGAudio;
		public AudioSource ThisAudio;
		public Storag Storag;

		public TextMesh[] SaveRankText = new TextMesh[4];
		private float Sspeedometer;

		private float rotateAngle;

		private int[] rank = new int[4];
		private bool[] isFront = new bool[3];
		public Transform VRCamUI;
		public Transform MiniMapCanvas;
		public GameObject GamePlaySetting;
		public Text SpeedLevelText;
		public AudioClip AccelClip;
		public AudioClip TopAccelClip;
		public int AINum;
		public int[] usedCar = new int[8];
		public float SpeedValue {
			get { return speedValue; }
			set {
				speedValue = value;
				speedLabel.GetComponent<Text>().text = "" + Mathf.Round(speedValue/2);

			}
		}

		GameObject PlayerCar;
		public int PlayLap;
		public GameObject Finish;
		public bool aaa;
		public GameObject FinishAnim;
		player_position PlayerPos;

		Computer_Script[] Com_Script = new Computer_Script[7];
		public AudioClip[] AllBgMusic;
		public Image FullBoost;

		// Use this for initialization
		void Start () {

		
			EndMusic = false;
			GameStaticData.isFinish = false;
			GameStaticData.isStart = false;
			gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();

			//loadCarProperty.LoadDataFromXML();
			SpeedLevel = 1;
			TurnLevel = 1;
			IsAddSpeed = false;
			finish = true;
			isStop = false;
			GameStaticData.isstop = false;
			switch (GameStaticData.PlayMode) {
			case GameStaticData.GameMode.GP:
				Car_Topspeed = GameStaticData.loadCarProperty.CarProperties [GameStaticData.PlayerUsedCar].TopSpeed;
				break;
			case  GameStaticData.GameMode.MotoX:
				Car_Topspeed = GameStaticData.loadCarProperty.CarProperties [GameStaticData.PlayerUsedCar].TopSpeed/3;
				break;
			}

			StartCoroutine (CreateCar ());

			PlayLap = GameStaticData.PlayLap;
			BGAudio.volume = GameStaticData.SoundValue;

			Lap.text = MutliLang.LangString [39]+" : 1 / "  + PlayLap.ToString ();
			GamePlaySetting = VRCamUI.transform.FindChild ("GamePlaySetting").gameObject;
		}

		int BGnum = 0;
		public bool EndMusic;
		void LoopBGMusic(){
			
			if (!BGAudio.isPlaying) {
				if (!EndMusic) {
					BGnum++;
					if (BGnum > AllBgMusic.Length - 2) {
						BGnum = 1;
					}
					BGAudio.clip = AllBgMusic [BGnum];
					BGAudio.Play ();
				}
				else {
					BGAudio.clip = AllBgMusic [AllBgMusic.Length - 1];
				}

			} 
			


		}


		void ControlSoundEffect(){

			for (int i = 0; i < Player.FindChild ("All Audio Sources").childCount; i++) {
				Player.FindChild ("All Audio Sources").GetChild (i).GetComponent<AudioSource> ().volume *= GameStaticData.SoundValue;

			}

			ThisAudio.volume *= GameStaticData.MusicValue;



		}

		void BLE_ControlCar(){


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
			if (!Contorl_Example.BLE_RL) {
				GameStaticData.canButton_RL = true;
			}
		}
		// Update is called once per frame

	

		public void checkPosTime(){
			StartCoroutine (checkPosWait());
		}
	
		IEnumerator checkPosWait(){
			GameStaticData.checkPos = true;
			yield return new WaitForSeconds (1f);
			GameStaticData.checkPos = false;

		}

		public GameStaticData gameStaticData;


		IEnumerator DelayFinishGame(){
			GameStaticData.canMotor = false;

			EndMusic = true;
			GameStaticData.CanFinishInput = false;
			GameObject b = Instantiate (FinishAnim) as GameObject;
			b.transform.parent = VRCamUI;
			b.transform.localPosition = new Vector3 (0.9f,0,0.5f);
			b.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			b.transform.localRotation = Quaternion.Euler (0, 0, 0);

			GameObject a = Instantiate (Finish) as GameObject;
			a.transform.localPosition = new Vector3 (10f, 10f, 0f);
			yield return new WaitForSeconds (2.5f);
			/*switch (a.GetComponent<FinishGame>().Rank[0]) {
			case 0:
				b.transform.FindChild("Image").GetChild(0).gameObject.SetActive(true);
				break;
			case 1:
				b.transform.FindChild ("Sliver").gameObject.SetActive(true);

				break;
			case 2:
				b.transform.FindChild ("Bronze").gameObject.SetActive(true);

				break;
			case 3:
				break;

			}*/
			yield return new WaitForSeconds (3f);

		
			GameStaticData.CanFinishInput = true;
			GameStaticData.canButton_RB = false;

			a.SetActive (true);
			a.transform.parent = VRCamUI;
			a.transform.localPosition = new Vector3 (0.85f, 0.1f, 0.3f);
			a.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			a.transform.localRotation = Quaternion.Euler (0, 0, 0);
			Destroy(b);

		}

		void ControlBoost(){
			FullBoost.fillAmount =Mathf.Lerp (FullBoost.fillAmount, Player.GetComponent<RMCRealisticMotorcycleController> ().AddSpeedSec * 0.25f, Time.deltaTime * 5);

		}

		void Update () {

			if (GameStaticData.PlayMode == GameStaticData.GameMode.GP) {
				Gvr.transform.GetChild (0).localEulerAngles = new Vector3 (0,0,10*GameStaticData.steerAngles);
			}

			//GameStaticData.checkPos = aaa;
			ControlBoost();
		
			if (Time.frameCount % 400 == 0) {
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				Screen.sleepTimeout = 0;
				gameStaticData.CheckPosD ();

			}


			if (Time.frameCount % 30 == 0) {
				System.GC.Collect ();

			}


			if (GameStaticData.isStart) {

				if (Input.GetKeyDown (KeyCode.L)) {
					GameStaticData.currentLap = 9;
				}

				if (GameStaticData.currentLap >= (PlayLap + 1) && !GameStaticData.isFinish) {

					if (finish) {
						for (int i = 0; i < VRCamUI.childCount; i++) {
							VRCamUI.GetChild (i).gameObject.SetActive (false);
						}


						GameStaticData.canButton_RB = false;
						GameStaticData.canButton_LB = false;
						GameStaticData.canButton_RT = false;
						GameStaticData.canButton_LT = false;



						MiniMapCanvas.gameObject.SetActive (false);


						StartCoroutine (DelayFinishGame());
						isStop = true;
						GameStaticData.isstop = true;
						finish = false;
						CarCheck.currentLap = 0;
						CarCheck.currentCheckpoint = 0;
						GameStaticData.currentLap = 0;
						Debug.Log ("win");
						GameStaticData.currentLap = -1;
					}
				}








				if (finish && !isStop) {

					if (((Contorl_Example.BLE_LT && GameStaticData.canButton_LT) && (Contorl_Example.BLE_RT && GameStaticData.canButton_RT)) || Input.GetKeyDown (KeyCode.C)) {
						
						print ("Setting");
						GameStaticData.canButton_LT = false;
						GameStaticData.canButton_RT = false;
						MiniMapCanvas.gameObject.SetActive (false);
						GamePlaySetting.SetActive (true);
						isStop = true;
						GameStaticData.isstop = true;
						GameStaticData.canMotor = false;
						Time.timeScale = 0;
					}



				} 






			

		

			}
	



		}


		void FixedUpdate () {
			LoopBGMusic();
			GameStaticData.speed = speedValue / 2;


			Sspeedometer = (Control.Speed) / (Control.maxSpeed);
			if (Control.Speed >= 0) {
				rotateAngle = Mathf.Lerp (0, 215, Sspeedometer);
			} else {
				rotateAngle = Mathf.Lerp (0, 215, -Sspeedometer);
			}

			speedometerArrow.localRotation = Quaternion.Euler (0, 0, -rotateAngle);
			if (((int)(speedValue / 2)).ToString ().Length == 1) {
				Showspeed1 = ((int)(speedValue / 2)).ToString () [0];
				Showspeed2 = '0';
				Showspeed3 = '0';
			} else if (((int)(speedValue / 2)).ToString ().Length == 2) {
				Showspeed3 = '0';
				Showspeed2 = ((int)(speedValue / 2)).ToString () [0];
				Showspeed1 = ((int)(speedValue / 2)).ToString () [1];
			} else if (((int)(speedValue / 2)).ToString ().Length == 3) {
				Showspeed3 = ((int)(speedValue / 2)).ToString () [0];
				Showspeed2 = ((int)(speedValue / 2)).ToString () [1];
				Showspeed1 = ((int)(speedValue / 2)).ToString () [2];
			}

			speedLabel1.text = Showspeed1.ToString ();
			speedLabel2.text = Showspeed2.ToString ();
			speedLabel3.text = Showspeed3.ToString ();



			Control.maxSpeed = Car_Topspeed / 6 * SpeedLevel;

			reset_All_Button ();


			if ((speedValue / 2) > (Car_Topspeed / 6 * 5) / 2 - 3) {  // > 26 - 6

				SpeedLevel = 6;

			} else if ((speedValue / 2) > (Car_Topspeed / 6 * 4) / 2 - 3) { // > 52 - 6
				SpeedLevel = 5;


			} else if ((speedValue / 2) > (Car_Topspeed / 6 * 3) / 2 - 3) {
				SpeedLevel = 4;

			} else if ((speedValue / 2) > (Car_Topspeed / 6 * 2) / 2 - 3) {
				SpeedLevel = 3;
	

			} else if ((speedValue / 2) > (Car_Topspeed / 6 * 1) / 2 - 3) {
				
				SpeedLevel = 2;
			} else {
				SpeedLevel = 1;
			}

			if (SpeedLevel < 6) {
				audioSoure.Stop ();
				audioSoure.loop = false;
			}

		

			SpeedLevelText.text = SpeedLevel.ToString ();

			SpeedValue = Control.Speed;
			Control.speedlevel = SpeedLevel;

		
		}

		bool isEq =true;
		int randNum;
		IEnumerator CreateCar(){
			//Create Player Car
			usedCar = new int[8];
			 PlayerCar = Instantiate (PlayCar[GameStaticData.PlayerUsedCar])as GameObject;

			PlayerCar.GetComponent<makeMapObject> ().identity = GameStaticData.PlayerUsedCar;
			PlayerCar.transform.parent = startPoint.transform.FindChild ("1");
			PlayerCar.transform.localPosition = new Vector3 (0,0,0);
			PlayerCar.transform.localRotation = Quaternion.Euler (0,0,0);
			if (GameStaticData.PlayMode == GameStaticData.GameMode.GP)
				PlayerCar.transform.localScale = new Vector3 (1, 1, 1f);
			else {
				PlayerCar.transform.localScale = new Vector3 (0.7f,0.7f,0.7f);

			}
			PlayerCar.AddComponent<player_position> ();

			PlayerPos = PlayerCar.GetComponent<player_position> ();
			PlayerPos.position_height = 50;
			PlayerPos.position_width = 100;


			PlayerPos.computercars = new Computer_Script[7];
			PlayerPos.numberofpositions = StorageObject.transform.childCount-1;


			Player = PlayerCar.transform;
			Control = PlayerCar.GetComponent<RMCRealisticMotorcycleController> ();
		
			for (int O = 0; O < 8; O++) {
				usedCar [O] = 99;

			}

			usedCar [0] = GameStaticData.PlayerUsedCar;

			//Create AI Car
			yield return new WaitForSeconds (0.5f);
			for (int i = 0; i < 7; i++) {

				isEq = true;

				while (isEq) {
					randNum = Random.Range(0,8);
				
					for (int O = 0; O < 8; O++) {
					
						if (randNum == usedCar [O]) {
							isEq = true;
							break;
						}
						else {
							isEq = false;
						}
					}
				
				}

				usedCar [1 + i] = randNum;
				print ("randNum : "+ randNum);
				GameObject AICar = Instantiate (PlayCar[randNum])as GameObject;

				AICar.transform.parent = startPoint.transform.FindChild ((i+2).ToString());
				AICar.transform.localPosition = new Vector3 (0,0,0);
				AICar.transform.localRotation = Quaternion.Euler (0,0,0);
				if (GameStaticData.PlayMode == GameStaticData.GameMode.GP)
					AICar.transform.localScale = new Vector3 (1, 1, 1f);
				else {
					AICar.transform.localScale = new Vector3 (0.7f,0.7f,0.7f);
				
				}

				AICar.GetComponent<makeMapObject> ().identity = randNum+AINum;

				AICar.AddComponent<Computer_Script> ();
				Computer_Script AI_Script = AICar.GetComponent<Computer_Script>();


				AI_Script.playercar = PlayerCar;
				AI_Script.othercomputercars = new Computer_Script[6];
				RMCRealisticMotorcycleController AI_RMCControl = AICar.GetComponent<RMCRealisticMotorcycleController> ();


				AI_RMCControl.isAIControl = true;
				AICar.GetComponent<RMCAI> ().enabled = true;

				int randSpeed ;
			/*
				if (i == 0) {
					randSpeed = GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + GameStaticData.SelectedTrack].EnemyTopSpeed;
				
				} else {
					randSpeed = (GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + GameStaticData.SelectedTrack].EnemyTopSpeed) - i * 8;

				}
			*/
				AI_RMCControl.maxSpeed =  100;

				yield return new WaitForSeconds (0.02f);

			}


			Storag.playercar = PlayerCar;
			Storag.playercarscript = PlayerCar.GetComponent<player_position>();
			Storag.allcomputercars = new Computer_Script[7];
			for (int k = 0; k < 7; k++) {
				Com_Script [k] = startPoint.transform.FindChild ((k+2).ToString()).GetChild(0).GetComponent<Computer_Script>();
			}



			for (int k = 0; k < 7; k++) {
				PlayerPos.computercars [k] = Com_Script[k]; 
				Storag.allcomputercars[k] = Com_Script[k];
			}

			int n;
			for (int k = 0; k < 7; k++) {
				n = 0;
				for (int l = 0; l < 6; l++) {
					if (n == k) {
						n++;
					}
					Com_Script[k].othercomputercars [l] = Com_Script[n++];

				
				}
			}


			/*
			Com_Script [0] = startPoint.transform.FindChild ("2").GetChild(0).GetComponent<Computer_Script>();
			Com_Script [1] = startPoint.transform.FindChild ("3").GetChild(0).GetComponent<Computer_Script>();
			Com_Script [2] = startPoint.transform.FindChild ("4").GetChild(0).GetComponent<Computer_Script>();

			PlayerPos.computercars [0] = Com_Script[0]; 
			PlayerPos.computercars [1] = Com_Script[1];
			PlayerPos.computercars [2] = Com_Script[2];

			Com_Script[0].othercomputercars [0] = Com_Script[1];
			Com_Script[0].othercomputercars [1] = Com_Script[2];
			Com_Script[1].othercomputercars [0] = Com_Script[0];
			Com_Script[1].othercomputercars [1] = Com_Script[2];
			Com_Script[2].othercomputercars [0] = Com_Script[0];
			Com_Script[2].othercomputercars [1] = Com_Script[1];

			Storag.playercar = PlayerCar;
			Storag.playercarscript = PlayerCar.GetComponent<player_position>();
			Storag.allcomputercars[0] = Com_Script[0];
			Storag.allcomputercars[1] = Com_Script[1];
			Storag.allcomputercars[2] = Com_Script[2];
*/

			//ControlSoundEffect ();

		}



	}



}
