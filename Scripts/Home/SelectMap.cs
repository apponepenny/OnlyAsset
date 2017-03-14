using UnityEngine;
using System.Collections;

public class SelectMap : MonoBehaviour {
	bool MoveL = false;
	bool MoveR = false;
	int countx;
	public int selectNum;
	int unlockMapNum;
	public GameObject SelectTrackPage;
	public GameObject[] AllMap = new GameObject[5];
	public GameObject ScreenLoad;
	public GameObject LeftNext;
	public GameObject RightNext;
	// Use this for initialization
	void Start () {
		selectNum = 0;
		CreateMap ();
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
		} else if (selectNum >= GameStaticData.MaxMap - 1) {
			LeftNext.SetActive (true);
			RightNext.SetActive (false);
		} else {
			LeftNext.SetActive (true);
			RightNext.SetActive (true);
		}
	}

	void _Input(){
	
		if (!MoveL && !MoveR) {
			//	if (Input.GetKeyDown (KeyCode.LeftArrow)) {
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
				if (selectNum < GameStaticData.MaxMap - 1) {
					selectNum++;
					MoveL = true;
				}
			}
		}
		//if (Input.GetKeyDown (KeyCode.A)) {
		if((Contorl_Example.BLE_RB && GameStaticData.canButton_RB)|| Input.GetKeyDown (KeyCode.A)){
			GameStaticData.canButton_RB = false;

			if (selectNum != -1) {
				if (!this.transform.GetChild(0).GetChild (selectNum).FindChild ("main").FindChild ("map").GetChild (0).gameObject.activeSelf) {
					GameStaticData.SelectedMap = selectNum;
					GameObject b = Instantiate (SelectTrackPage, Vector2.zero, Quaternion.identity) as GameObject;
					//Destroy (this.transform.parent.gameObject);
					b.transform.GetChild(0).GetComponent<SelectTrack>().SelectMapPage = this.transform.parent.gameObject;
					this.transform.parent.gameObject.SetActive (false);

				}
			} else {
				GameStaticData.SelectedTrack = selectNum;
				GameStaticData.sceneName = "TestScene";
				//GameStaticData.sceneName = "1_11";

				GameObject hi = Instantiate (ScreenLoad, Vector3.zero, Quaternion.identity) as GameObject;
				hi.transform.localPosition = new Vector3 (0, 0, 260);

			}


		


		}


	

		//if (Input.GetKeyDown (KeyCode.S)) {
		if((Contorl_Example.BLE_LB && GameStaticData.canButton_LB) || Input.GetKeyDown (KeyCode.S)){

	

			GameStaticData.canButton_LB = false;	
			GameObject.Find ("Button").transform.FindChild("allButton").gameObject.SetActive(true);

			Destroy (this.transform.parent.gameObject);

			GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
			if (GameStaticData.isVR && SystemInfo.supportsGyroscope) {

				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = true;
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = true;
			} else {

				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
				GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;
			}
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

	void CreateMap(){
		

        int count;

        Object[] maps = Resources.LoadAll("Map/");
        count = maps.Length;

        print("How many Map : " + count);
        GameStaticData.MaxMap = count;

		for (int i = 0; i < GameStaticData.MaxMap; i++)
        {
            GameObject a = Instantiate(AllMap[i], Vector3.zero, Quaternion.identity) as GameObject;
			a.transform.parent = this.transform.GetChild(0);
            a.transform.localPosition = new Vector2(200 * i, 0);

            a.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
			this.transform.GetChild(0).GetChild (i).FindChild ("main").FindChild ("map").GetChild (0).localScale = new Vector3 (1,1,1);
			this.transform.GetChild(0).GetChild (i).FindChild ("main").FindChild ("map").GetComponent<SpriteRenderer> ().color = new Color (1,1,1,0.5f);

        }

    
        unlockMapNum = PlayerPrefs.GetInt("unlockMapNum");
		//PlayerPrefs.SetInt ("unlockMapNum",1);
		print ("unlockMapNum : "+ unlockMapNum);
		//unlockMapNum = count;
		for (int i = 0; i <  GameStaticData.MaxMap; i++)
        {
			this.transform.GetChild(0).GetChild (i).FindChild ("main").FindChild ("map").GetComponent<SpriteRenderer> ().color = new Color (1,1,1,1);

			this.transform.GetChild(0).GetChild (i).FindChild("main").FindChild("map").GetChild(0).gameObject.SetActive(false);

        }



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
