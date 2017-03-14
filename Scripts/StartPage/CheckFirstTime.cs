using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CheckFirstTime : MonoBehaviour {
	int  countMap;
	int countTrack;
	float a;
	public Transform Gvr;
	public Button StartButton;
	public Image StartImage;
	public Text StartTextImage;
	public Text ScanTextImage;
	public Text HelpTextImage;

	public GameObject ReScanButon;
	public Text _text;

	public GameObject Main;
	public GameObject MotorMode;
	public Image MainBGImage;

	// Use this for initialization
	void Start () {
		checkisfirst ();
	//	GameObject a = Instantiate (Resources.Load("Prefabs/BLECanvas")) as GameObject;
	
	//	a.name = "BLECanvas";
		ScanTextImage.text = " "+MutliLang.LangString[4]+" ";
		HelpTextImage.text = " "+MutliLang.LangString[6]+" ";
		StartTextImage.text = " "+MutliLang.LangString [5]+" ";
		_text.text = MutliLang.LangString[7]+"..";


		//PlayerPrefs.DeleteKey ("Isfirst");
		_text.gameObject.SetActive(true);


	}


	// Update is called once per frame
	void Update () {
		
		a += Time.deltaTime;

		if (a > 0.2f) {
			ScanTextImage.text = MutliLang.LangString[4];
			HelpTextImage.text = MutliLang.LangString[6];
			StartTextImage.text = MutliLang.LangString [5];
			if (GameStaticData.isConnect ) {
				StartButton.enabled = true;
				StartImage.color = new Color (1, 1, 1, 1);
				StartTextImage.color = new Color (0.5f, 0.7f, 0.8f, 1);

				ReScanButon.SetActive (false);

				_text.text = MutliLang.LangString[7]+"...";
		
			} else {
				ReScanButon.SetActive (true);

				StartButton.enabled = false;
				StartImage.color = new Color32 (255, 255, 255, 75);
				StartTextImage.color = new Color32 (124, 216, 225, 75);

				_text.text = MutliLang.LangString[3];

			}
		}
	}
	public void ClickMotoX(){
		GameStaticData.PlayMode = GameStaticData.GameMode.MotoX;
		CheckPlayMode ();
	}
	public void ClickGP(){
		GameStaticData.PlayMode = GameStaticData.GameMode.GP;
		CheckPlayMode ();
	}
	void CheckPlayMode(){
		switch (GameStaticData.PlayMode) {
		case GameStaticData.GameMode.MotoX: 
			
			break;
		case GameStaticData.GameMode.GP: 
			
			break;
		}
		MotorMode.SetActive (false);
		Main.SetActive (true);
	}
	public void BackMotorMode(){
		MotorMode.SetActive (true);
		Main.SetActive (false);
	}


	void checkisfirst(){




		if (PlayerPrefs.HasKey ("Isfirst")) {
			//PlayerPrefs.DeleteKey ("Isfirst");
			PlayerPrefs.DeleteKey ("IsfirstChoose");

			print ("Is not first time in game");

		} else {
			print ("first time in game");

			PlayerPrefs.SetInt ("Isfirst",1);
			//Save Star
			Dictionary<string,int> TrackStar = new Dictionary<string,int>();
			Dictionary<string,int> TrackBestTime = new Dictionary<string,int>();
			Dictionary<string,int> TrackUnlock = new Dictionary<string,int>();





			Object[] maps = Resources.LoadAll("Map/");
			countMap = maps.Length;

			GameStaticData.MaxMap = countMap;

			for (int i = 0; i < countMap; i++) {

				Object[] tracks = Resources.LoadAll("Track/"+ i);
				countTrack = tracks.Length;

				for (int j = 0; j < countTrack; j++) {
					TrackStar.Add ((i+1)+"_"+(j+1),0);
				}

				for (int j = 0; j < countTrack; j++) {
					TrackBestTime.Add ((i+1)+"_"+(j+1)+"mm",99);
					TrackBestTime.Add ((i+1)+"_"+(j+1)+"ss",99);
					TrackBestTime.Add ((i+1)+"_"+(j+1)+"ms",99);

				}

				TrackUnlock.Add (i.ToString(),0);
			}

		
		



			PlayerPrefsUtility.SaveDict<string,int> ("TrackUnlock",TrackUnlock);
			PlayerPrefsUtility.SaveDict<string,int> ("TrackStar",TrackStar);
			PlayerPrefsUtility.SaveDict<string,int> ("TrackBestTime",TrackBestTime);




			//Save unlock


			PlayerPrefs.SetInt("unlockMapNum", 8);


			PlayerPrefs.SetInt ("HaveStar",0);



		}

	}
}
