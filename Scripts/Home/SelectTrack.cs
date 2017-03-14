using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectTrack : MonoBehaviour {
	bool MoveL = false;
	bool MoveR = false;
	int countx;
	public int selectNum;

	int unlockToyCityTrack;
	int unlockCityTrack;
	int unlockSeaTrack;
	int unlockForestTrack;

	public SpriteRenderer[] ComponentSprite;


	public GameObject ScreenLoad;
	public TrackNum[] AllTrack = new TrackNum[4];
	public Sprite LightStar;
	public GameObject SelectMapPage;
	public GameObject StarCount;
	public GameObject ChooseYourView;
	public GameObject ControlPage;
	public GameObject LeftNext;
	public GameObject RightNext;
	[System.Serializable]
	public class TrackNum{

		public Sprite[] Track = new Sprite[4];
	}


	// Use this for initialization
	void Start () {
		StarCount = GameObject.FindWithTag ("UIUI").transform.GetChild (0).GetChild (0).gameObject;
		StarCount.SetActive(true);
		selectNum = 0;
		CreateTrack ();
		if(!Input.gyro.enabled)
			this.transform.parent.position = new Vector3 (0, 1f, 25);
		else
			this.transform.parent.position = new Vector3 (0, 2f, 25);
		LeftNext = GameObject.Find ("Button").transform.FindChild ("Left").gameObject;
		RightNext = GameObject.Find ("Button").transform.FindChild ("Right").gameObject;
	}

	// Update is called once per frame
	void Update () {
		print (selectNum);
		_Input ();
		reset_All_Button ();
		if (selectNum == 0) {
			LeftNext.SetActive (false);
			RightNext.SetActive (true);
		} else if (selectNum >= GameStaticData.MaxTrack - 1) {
			LeftNext.SetActive (true);
			RightNext.SetActive (false);
		} else {
			LeftNext.SetActive (true);
			RightNext.SetActive (true);
		}
	}

	void _Input(){
		if (!MoveL && !MoveR) {
			//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if((Contorl_Example.BLE_aY <-0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)){
				GameStaticData.canButton_aY = false;		
				if (selectNum > 0) {
					selectNum--;
					MoveR = true;
				}	

			}
			//if (Input.GetKeyDown (KeyCode.RightArrow)) {	
			if((Contorl_Example.BLE_aY >0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
				GameStaticData.canButton_aY = false;		
				if (selectNum < GameStaticData.MaxTrack - 1) {
					selectNum++;
					MoveL = true;
				}
			}
		}
		//if (Input.GetKeyDown (KeyCode.A)) {
		if(((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) && !GameObject.Find("ScreenLoad(Clone)")){
			GameStaticData.canButton_RB = false;if (!this.transform.GetChild (selectNum).FindChild ("main").FindChild ("map").GetChild (0).gameObject.activeSelf) {
				if (PlayerPrefs.HasKey ("IsfirstChoose")) {
				

					GameStaticData.canButton_RB = false;

					GameStaticData.SelectedTrack = selectNum;
					GameStaticData.sceneName = (GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1);
					//GameStaticData.sceneName = "5_1";

					GameObject hi = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
					hi.transform.localPosition = new Vector3 (0, 0, 260);





					//GameStaticData.PlayLap = GameStaticData.MapTrackLap[(GameStaticData.SelectedMap+1)+"_"+(GameStaticData.SelectedTrack+1)];
					GameStaticData.PlayLap = GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + GameStaticData.SelectedTrack].Lap;
					//Destroy (this.transform.parent.gameObject);
					this.transform.parent.gameObject.SetActive (false);




				} else {
					print ("first time in IsfirstChoose");

					GameStaticData.ChooseView = Instantiate (ChooseYourView);
					GameStaticData.ChooseView.GetComponent<chooseYourView> ()._SelectTrack = this.transform.parent.gameObject;
					GameStaticData.ChooseView.GetComponent<chooseYourView> ().ST = this;
					GameStaticData.ChooseView.SetActive (false);

					GameObject Con_Page = Instantiate (ControlPage);

					GameStaticData.SelectedTrack = selectNum;
					GameStaticData.sceneName = (GameStaticData.SelectedMap + 1) + "_" + (GameStaticData.SelectedTrack + 1);
					GameStaticData.PlayLap = GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + GameStaticData.SelectedTrack].Lap;

					this.transform.parent.gameObject.SetActive (false);

				}

			}

		}
		//if (Input.GetKeyDown (KeyCode.S)) {
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

			SelectMapPage.SetActive (true);

			//GameObject b = Instantiate (SelectMapPage,Vector2.zero,Quaternion.identity) as GameObject;

			Destroy (this.transform.parent.gameObject);
		}





		if (MoveL) {
			MoveLL ();
			countx -= 20;
			if (countx <= -200) {
				countx = 0;
				MoveL = false;
			}
		}
		if (MoveR) {
			MoveRR ();
			countx -= 20;
			if (countx <= -200) {
				countx = 0;
				MoveR = false;
			}
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

	void CreateTrack(){



        int count;

        Object[] maps = Resources.LoadAll("Track/"+ GameStaticData.SelectedMap);
        count = maps.Length;

        print("How many Track : "+count);
        GameStaticData.MaxTrack = 4;

        for (int i = 0; i < 4; i++) {
			

			//GameObject a = Instantiate (Resources.Load ("Track/" + GameStaticData.SelectedMap + "/" + i), Vector3.zero, Quaternion.identity) as GameObject;
			GameObject a = Instantiate (Resources.Load ("Track/0/1_1" ), Vector3.zero, Quaternion.identity) as GameObject;

			a.transform.parent = this.transform;
            a.transform.localPosition = new Vector2(200*i,0);

			//a.GetComponent<RectTransform> ().offsetMin = new Vector2 (-500,0);
			//a.GetComponent<RectTransform> ().offsetMax = new Vector2 (500,0);


			a.transform.localScale = new Vector3(1.5f,1.5f,0f);

			this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).localScale = new Vector3 (1,1,1);
//			this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetComponent<SpriteRenderer> ().color = new Color (1,1,1,0.5f);


			//Dictionary<string,int> LoadTrackStar = PlayerPrefsUtility.LoadDict<string,int> ("TrackStar");

			for (int j = 0; j < GameStaticData.BestStar [(GameStaticData.SelectedMap+1) + "_" + (i+1)]; j++) {
				
				this.transform.GetChild (i).FindChild("main").FindChild ("Star").GetChild (j).GetComponent<SpriteRenderer> ().sprite = LightStar; 

			}
			this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).gameObject.SetActive (false);
			/*****************************************
			if (i > 0) {
				if (GameStaticData.BestStar [(GameStaticData.SelectedMap+1) + "_" + (i)] >= 1) {
					this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).gameObject.SetActive (false);

				}
			} else {
				this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).gameObject.SetActive (false);
			
			}
*******************************/
			//Dictionary<string,int> LoadTrackBestTime = PlayerPrefsUtility.LoadDict<string,int> ("TrackBestTime");
			int mm = (int)GameStaticData.BestTime[(GameStaticData.SelectedMap + 1) + "_" + (i + 1) + "mm"];
			int ss = (int)GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (i + 1) + "ss"];
			int ms = (int)GameStaticData.BestTime [(GameStaticData.SelectedMap + 1) + "_" + (i + 1) + "ms"];

			if (mm == 99 && ss == 99 && ms == 99) {
				this.transform.GetChild (i).FindChild("main").FindChild ("Time").GetChild (0).GetChild (0).GetComponent<TextMesh> ().text ="--:--:--";
			
			} else {
				this.transform.GetChild (i).FindChild("main").FindChild ("Time").GetChild (0).GetChild (0).GetComponent<TextMesh> ().text = mm.ToString("00") + ":" + ss.ToString("00") + ":" + ms.ToString("00");
			}

		
		
			this.transform.GetChild (i).FindChild("main").FindChild("track").GetComponent<SpriteRenderer>().sprite = AllTrack[GameStaticData.SelectedMap].Track[i];
			this.transform.GetChild (i).FindChild("main").FindChild("Race").GetComponent<TextMesh>().text = "LEVEL "+(i+1);
			//this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).FindChild ("num").GetComponent<TextMesh> ().text = GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + i].Require.ToString ();
			this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).FindChild ("num").gameObject.SetActive(false);

		}

		//PlayerPrefs.SetInt ("UnlockCityTrack",2);
		/*
		int havestar = PlayerPrefs.GetInt("HaveStar");
		print ("Have Star : " + havestar);
		for (int i = 0; i < count; i++) {
			if (havestar >= GameStaticData.loadTrackData.TrackDatas [(4 * GameStaticData.SelectedMap) + i].Require)
				this.transform.GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).gameObject.SetActive (false);
		
		}
		*/


		/*
		for (int i = 0; i < GameStaticData.TrackUnlock [GameStaticData.SelectedMap.ToString()]; i++) {
			this.transform.GetChild(i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);
		}
*/
/*
		 
		unlockToyCityTrack = PlayerPrefs.GetInt ("UnlockToyCityTrack");

		unlockCityTrack = PlayerPrefs.GetInt ("UnlockCity");
		unlockSeaTrack = PlayerPrefs.GetInt ("UnlockSeaTrack");
		unlockForestTrack = PlayerPrefs.GetInt ("UnlockForestTrack");
		switch(GameStaticData.SelectedMap){
		case 0:
			//			this.transform.parent.FindChild("MapName").GetComponent<Text>().text = "Map : City";

			for (int i = 0; i < unlockCityTrack; i++) {

				this.transform.GetChild(i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);
			}
			break;
		case 1:
//			this.transform.parent.FindChild("MapName").GetComponent<Text>().text = "Map : City";

			for (int i = 0; i < unlockToyCityTrack; i++) {

				this.transform.GetChild(i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);
			}
			break;
		case 2:
		//	this.transform.parent.FindChild("MapName").GetComponent<Text>().text = "Map : UnderSea";

			for (int i = 0; i < unlockSeaTrack; i++) {

				this.transform.GetChild(i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);
			}
			break;
		case 3:
		//	this.transform.parent.FindChild("MapName").GetComponent<Text>().text = "Map : Forest";

			for (int i = 0; i < unlockForestTrack; i++) {

				this.transform.GetChild(i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);
			}
			break;
		case 4:
			break;

		}
*/


	
	

	}

	void MoveLL(){
		float nowx= this.transform.localPosition.x;

		this.transform.localPosition = new Vector3 (nowx-20,0,0);

	}
	void MoveRR(){
		float nowx= this.transform.localPosition.x;

		this.transform.localPosition = new Vector3 (nowx+20,0,0);


	}
}
