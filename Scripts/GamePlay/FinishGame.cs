using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets.Vehicles.Car
{

public class FinishGame : MonoBehaviour {
	public int selectBtn;
		public List<GetRank> Rank = new List<GetRank>();
		public GetRank[] AllRank = new GetRank[8];

	public UIControl UI;
	int thisRoundStar = 0;
		public GameObject ScreenLoad;
	int unlock;
		int saveI;
		int saveRankI;

	string unlockname;

		public Sprite nonSelect;
		public Sprite button;
		public Sprite lightStar;
		public Sprite[] CarSprite = new Sprite[12];

		public SpriteRenderer[] StarSprite = new SpriteRenderer[3];
		public Animator[] StarAnim = new Animator[3];
		public Transform CarStartPoint;
		public SpriteRenderer[] ButtonSprite = new SpriteRenderer[3];
	// Use this for initialization
	void Start () {
			CarStartPoint = GameObject.Find ("CarStartPoint").transform;

			GameStaticData.canButton_RB = false;
		

		UI = GameObject.FindWithTag ("VRCam").transform.GetChild(0).GetChild(0).FindChild("UI").GetComponent<UIControl> ();
			GameStaticData.isFinish = true;
		

		selectBtn = 0;
		CheckRank ();
		CheckTime ();
			StartCoroutine(CheckStar ());
			for (int i = 1; i < 4; i++) {
				CarStartPoint.GetChild (i).GetChild(0).GetComponent<CarAIControl>().isStart = false;
			}
			//Destroy (GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).FindChild ("Helpers").gameObject);

			GameStaticData.canMotor= false;
			GameStaticData.isStart = false;

			//GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).GetComponent<RCCCarControllerV2> ().enabled = false;
			//GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).GetComponent<CarController> ().enabled = true;

			//GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).GetComponent<CarUserControl> ().enabled = false;
			//GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).GetComponent<CarAIControl> ().enabled = true;
			//GameObject rayray = Instantiate (Resources.Load ("Prefabs/ray")) as GameObject;
			//rayray.transform.parent = GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).transform;
			//rayray.transform.localPosition = new Vector3 (0,0,0);
			//rayray.name = "ray";
			//GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0).gameObject.AddComponent<RayDetect> ();
			//GameObject.FindWithTag ("VRCam").GetComponent<Cam_SmoothFollow> ().distance = 13;
			//Time.timeScale = 0;
	}

		public class GetRank{
			public int CarID;
			public int CarRank;
		}

	void CheckRank(){
			AllRank [0].CarID = 0;
			AllRank [0].CarRank = CarStartPoint.GetChild (0).GetChild (0).GetComponent<player_position> ().raceposition ;

	
			for (int i = 1; i < 8; i++) {
				AllRank [i].CarID = i;
				AllRank [i].CarRank = CarStartPoint.GetChild (i).GetChild (0).GetComponent<Computer_Script> ().raceposition ;

			}

			for (int i = 0; i < 4; i++) {
				for (int k = 0; k < 8; k++) {
					if (AllRank [k].CarRank == i + 1) {
						Rank.Add(AllRank[k]);
					}
					if (Rank.Count >= 4) {
						i = 4;
						break;
					}
				}
			}
	














			/*

			Rank [0] = CarStartPoint.GetChild (0).GetChild (0).GetComponent<player_position> ().raceposition ;
			Rank [1] = CarStartPoint.GetChild (1).GetChild (0).GetComponent<Computer_Script> ().raceposition ;
			Rank [2] = CarStartPoint.GetChild (2).GetChild (0).GetComponent<Computer_Script> ().raceposition ;
			Rank [3] = CarStartPoint.GetChild (3).GetChild (0).GetComponent<Computer_Script> ().raceposition ;

		

		for (int i = 0; i < 4; i++) {
				print (i+" : "+Rank[i]);
				if (this.transform.FindChild ("Rank").GetChild (Rank [i]).GetChild (0).GetChild (0).GetChild (0).GetComponent<SpriteRenderer> ().sprite == null)
					this.transform.FindChild ("Rank").GetChild (Rank [i]).GetChild (0).GetChild (0).GetChild (0).GetComponent<SpriteRenderer> ().sprite = CarSprite [CarStartPoint.GetChild (i).GetChild (0).GetComponent<makeMapObject>().identity];
				else {
					saveRankI = CarStartPoint.GetChild (i).GetChild (0).GetComponent<makeMapObject>().identity;
				}
				//this.transform.FindChild ("Rank").GetChild (Rank[i]).GetChild (0).GetChild(0).GetComponent<TextMesh> ().text = Rank [i].ToString();

		}



			for (int i = 0; i < 4; i++) {

				if (this.transform.FindChild ("Rank").GetChild (i).GetChild (0).GetChild (0).GetChild (0).GetComponent<SpriteRenderer> ().sprite == null) {
					this.transform.FindChild ("Rank").GetChild (i).GetChild (0).GetChild (0).GetChild (0).GetComponent<SpriteRenderer> ().sprite = CarSprite [saveRankI];
					print ("this OKOKOKOKOKOK");
				}
			}
			this.transform.FindChild ("Rank").GetChild (Rank[0]).GetChild (0).GetChild (0).GetChild (0).GetChild (0).gameObject.SetActive (true);
	*/
	}

	void CheckTime(){
		//display Now Time
		this.transform.FindChild("Result").FindChild("TotalTime_Text").GetChild(0).GetComponent<TextMesh>().text= UI.mm.ToString("00")+":"+UI.ss.ToString("00")+":"+UI.ms.ToString("00");

		//Save Best Time

		//Dictionary<string,int> BestTime = PlayerPrefsUtility.LoadDict<string,int> ("TrackBestTime");

		int Bestmm = GameStaticData.BestTime[(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "mm"];
		int Bestss = GameStaticData.BestTime[(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ss"];
		int Bestms = GameStaticData.BestTime[(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ms"];

		if (UI.mm < Bestmm || (UI.mm == Bestmm && UI.ss < Bestss) || (UI.mm == Bestmm && UI.ss == Bestss && UI.ms < Bestss)) {
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "mm"] = (int)UI.mm;
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ss"] = (int)UI.ss;
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ms"] = (int)UI.ms;
			PlayerPrefsUtility.SaveDict<string,int> ("TrackBestTime",GameStaticData.BestTime);

		}
		//display Best Time
		

		this.transform.FindChild ("Result").FindChild ("BestLap_Text").GetChild (0).GetComponent<TextMesh> ().text = 
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "mm"].ToString("00") + ":" +
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ss"].ToString("00") + ":" +
			GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1) + "ms"].ToString("00");
	}

		IEnumerator CheckStar(){


		//Dictionary<string,int> BestStar = PlayerPrefsUtility.LoadDict<string,int> ("TrackStar");
		//string TempPos = UI.transform.FindChild ("saveRank").GetChild (0).GetComponent<TextMesh> ().text;

		//print ("TempPos : " + TempPos);

		
			/*
			switch (Rank[0]) {
		case 1:
			if (GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] < 3)
				GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] = 3;
			thisRoundStar = 3;

			break;
		case 2:
			
			if(GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] <2)
				GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] = 2;
			thisRoundStar = 2;

			break;
		case 3:
			if(GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] <1)
				GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] = 1;
			thisRoundStar = 1;

			break;
	
		}
		PlayerPrefsUtility.SaveDict<string,int> ("TrackStar",GameStaticData.BestStar);
*/
	//unlockmap or track
			/*
			switch (GameStaticData.SelectedMap) {
			case 0:
				//CITY
				unlockname = "UnlockCityTrack";
				break;
			case 1:
				//TOY CITY
				unlockname = "UnlockToyCityTrack";
				break;
			case 2:
				//FOREST
				unlockname = "UnlockForestTrack";
				break;
			case 3:
				//UNDERWATER
				unlockname = "UnlockSeaTrack";

				break;

			}
*/
			unlock = GameStaticData.TrackUnlock [GameStaticData.SelectedMap.ToString()];

			//unlock = PlayerPrefs.GetInt (unlockname);

					/*
			int count;
			Object[] maps = Resources.LoadAll("Track/"+ GameStaticData.SelectedMap);
			count = maps.Length;
*/

			/*
			if (GameStaticData.SelectedMap + 1 >= GameStaticData.NowUnlockMap) {
				
				if (thisRoundStar >= 1 && thisRoundStar <= 3) {
					if (GameStaticData.SelectedTrack + 1 >= unlock) {
						GameStaticData.TrackUnlock [Mathf.Clamp((GameStaticData.SelectedMap + 1),1,GameStaticData.MaxMap).ToString ()] = 1;
						PlayerPrefsUtility.SaveDict<string,int> ("TrackUnlock", GameStaticData.TrackUnlock);
						int unlockMapNum = PlayerPrefs.GetInt ("unlockMapNum");
						unlockMapNum++;
						PlayerPrefs.SetInt ("unlockMapNum",Mathf.Clamp(unlockMapNum,1,GameStaticData.MaxMap));
					} else {
						unlock++;
						unlock = Mathf.Clamp (unlock,1,GameStaticData.TrackUnlock [GameStaticData.SelectedMap.ToString ()]);


						//PlayerPrefs.SetInt (unlockname, unlock);
						GameStaticData.TrackUnlock [GameStaticData.SelectedMap.ToString ()] = unlock;
						PlayerPrefsUtility.SaveDict<string,int> ("TrackUnlock", GameStaticData.TrackUnlock);

					}

					int HaveStar = PlayerPrefs.GetInt ("HaveStar");
					HaveStar += thisRoundStar;
					PlayerPrefs.SetInt ("HaveStar",HaveStar);
				}

			}
			*/
                                //			thisRoundStar = 3 - Rank [0];
			print ((GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1));
			print ("this Round Star : " + thisRoundStar + " || Best Star : " + GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)]);
			/*
			if (GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] < thisRoundStar) {

				print ("Get Star");
				int HaveStar = PlayerPrefs.GetInt ("HaveStar");
				HaveStar = HaveStar + (thisRoundStar - GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)]);
				PlayerPrefs.SetInt ("HaveStar",HaveStar);

				GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] = thisRoundStar;
				PlayerPrefsUtility.SaveDict<string,int> ("TrackStar",GameStaticData.BestStar);
			}


*/
			PlayerPrefs.SetInt ("HaveStar",PlayerPrefs.GetInt ("HaveStar")+thisRoundStar);
			if (GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] < thisRoundStar) {
				GameStaticData.BestStar [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)] = thisRoundStar;
				PlayerPrefsUtility.SaveDict<string,int> ("TrackStar",GameStaticData.BestStar);
			}
			/*
			if (GameStaticData.SelectedTrack + 1 >= unlock) {
				if (thisRoundStar >= 1 && thisRoundStar <= 3) {
					if (unlock + 1 <= GameStaticData.MaxTrack) {
				
						unlock++;
						//PlayerPrefs.SetInt (unlockname, unlock);
						GameStaticData.TrackUnlock [GameStaticData.SelectedMap.ToString ()] += 1;
						PlayerPrefsUtility.SaveDict<string,int> ("TrackUnlock", GameStaticData.TrackUnlock);

		
					} else {
						if (GameStaticData.SelectedTrack + 1 == unlock) {
							GameStaticData.TrackUnlock [(GameStaticData.SelectedMap + 1).ToString ()] = 1;
							PlayerPrefsUtility.SaveDict<string,int> ("TrackUnlock", GameStaticData.TrackUnlock);
							int unlockMapNum = PlayerPrefs.GetInt ("unlockMapNum");
							unlockMapNum++;
							PlayerPrefs.SetInt ("unlockMapNum", unlockMapNum);
						}
				
					}
				}
				
		}
		*/

		//print ("thisRoundStar : "+ thisRoundStar);

		for (int i = 0; i < thisRoundStar; i++) {
				StarSprite[i].sprite =lightStar; 
				StarAnim [i].enabled = true;
				yield return new WaitForSeconds (0.5f);
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


	// Update is called once per frame
	void Update () {		

			reset_All_Button ();
			if (GameStaticData.CanFinishInput) {
				switch (selectBtn) {
				case 0:
					ButtonSprite [2].sprite = nonSelect; 
					ButtonSprite [1].sprite = nonSelect; 
					ButtonSprite [0].sprite = button; 

					break;
				case 1:
					ButtonSprite [2].sprite = nonSelect; 
					ButtonSprite [0].sprite = nonSelect; 
					ButtonSprite [1].sprite = button; 
					break;
				case 2:
					ButtonSprite [0].sprite = nonSelect; 
					ButtonSprite [1].sprite = nonSelect; 
					ButtonSprite [2].sprite = button; 
					break;
				}


				//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if ((Contorl_Example.BLE_aY < -0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)) {
					GameStaticData.canButton_aY = false;

					selectBtn--;
					if (selectBtn < 0) {
						selectBtn = 0;
					}
				}
				//	if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if ((Contorl_Example.BLE_aY > 0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)) {
					GameStaticData.canButton_aY = false;

					selectBtn++;
					if (selectBtn > 1) {
						selectBtn = 1;
					}
				}
				//	if (Input.GetKeyDown (KeyCode.A)) {
				if ((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) {
					GameStaticData.canButton_RB = false;

	



					switch (selectBtn) {
					case 0:
						GameStaticData.isGameBack = true;
						GameStaticData.sceneName = "Game_Home";


						break;
					case 1:
						GameStaticData.sceneName = (GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1);

						break;
					case 2:


				//	if (unlock <= GameStaticData.SelectedTrack + 1) {
				//		GameStaticData.sceneName = "Game_Home";

						if (GameStaticData.HaveStar < GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + GameStaticData.SelectedTrack + 2].Require) {
							GameStaticData.sceneName = "Game_Home";
						} else {
							GameStaticData.SelectedTrack++;
							if (GameStaticData.SelectedTrack < GameStaticData.MaxTrack)
								GameStaticData.sceneName = (GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1);
							else {
								GameStaticData.sceneName = "Game_Home";
							}

							GameStaticData.PlayLap = GameStaticData.MapTrackLap [(GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1)];
						}
				


						break;
					}

					Time.timeScale = 1;
					GameObject hiNu = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
					hiNu.transform.parent = GameObject.FindWithTag ("VRCam").transform.GetChild (0);
					hiNu.transform.localRotation = Quaternion.Euler (63, 0, 0);
					hiNu.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 100);
					hiNu.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
					hiNu.transform.localPosition = new Vector3 (0, -14f, 6f);

					Destroy (this.gameObject);
				}
			}
	}
}
}