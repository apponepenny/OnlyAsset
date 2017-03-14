using UnityEngine;
using System.Collections;

public class AudioSlider : MonoBehaviour {

	int selectNum;
	bool isMusic;
	bool isSound;
	bool isVR;

	float MusicValue;
	float SoundValue;
	float perMusicRo;
	float perSoundRo;

	bool isGameVR;
	public SpriteRenderer VROnSprite;
	public SpriteRenderer VROffSprite;
	public GameObject VROnSelect;
	public GameObject VROffSelect; 
	int VRSelectNum;
	public GameObject LeftNext;
	public GameObject RightNext;
	// Use this for initialization
	void Start () {
		selectNum = 0;
		VRSelectNum = 0;
		isMusic = false;
		isSound = false;
		isVR = false;
		isGameVR = GameStaticData.isVR;
		GameStaticData.canButton_aY = true;
		MusicValue = GameStaticData.MusicValue;
		SoundValue = GameStaticData.SoundValue;
		LeftNext = GameObject.Find ("Button").transform.FindChild ("Left").gameObject;
		RightNext = GameObject.Find ("Button").transform.FindChild ("Right").gameObject;
	
		LeftNext.SetActive (false);
		RightNext.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		input ();
		checkSlider ();
		reset_All_Button ();

		GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = MusicValue;
		GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = SoundValue;


	}
	void checkSlider(){

		perMusicRo = (this.transform.FindChild ("Main").GetChild (0).FindChild("bar").FindChild ("ro").localPosition.x + 7.5f) / 15;
		perSoundRo = (this.transform.FindChild ("Main").GetChild (1).FindChild("bar").FindChild ("ro").localPosition.x + 7.5f) / 15;

		this.transform.FindChild ("Main").GetChild (0).FindChild("bar").FindChild ("smallbar").localScale = new Vector3(8.4f * perMusicRo,1,1);
		this.transform.FindChild ("Main").GetChild (1).FindChild("bar").FindChild ("smallbar").localScale = new Vector3(8.4f * perSoundRo,1,1);
	
		this.transform.FindChild ("Main").GetChild (0).FindChild ("bar").FindChild ("ro").localPosition = new Vector3 (MusicValue*15-7.5f,0,0);
		this.transform.FindChild ("Main").GetChild (1).FindChild ("bar").FindChild ("ro").localPosition = new Vector3 (SoundValue*15-7.5f,0,0);

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

	void input(){


		if (!isMusic && !isSound && !isVR) {
			//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if((Contorl_Example.BLE_aY >0.5f && GameStaticData.canButton_aY ) || Input.GetKeyDown (KeyCode.LeftArrow)){
				GameStaticData.canButton_aY = false;
				selectNum++;
			}
			//if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if((Contorl_Example.BLE_aY <-0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
				GameStaticData.canButton_aY = false;

				selectNum--;
			}

		} else {

			if (isMusic) {
				//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if((Contorl_Example.BLE_aY <-0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)){
					GameStaticData.canButton_aY = false;
					MusicValue -= 0.1f;
				}
				//if (Input.GetKeyDown (KeyCode.RightArrow)) {
					if((Contorl_Example.BLE_aY >0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
					GameStaticData.canButton_aY = false;
					MusicValue += 0.1f;
				}
				if (MusicValue > 1)
					MusicValue = 1;
				if (MusicValue < 0)
					MusicValue = 0;
				GameStaticData.MusicValue = MusicValue;

				this.transform.FindChild ("Main").FindChild ("Music").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);

			}

			if (isSound) {
				//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if((Contorl_Example.BLE_aY <-0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)){
					GameStaticData.canButton_aY = false;	
					SoundValue -= 0.1f;
				}
				//if (Input.GetKeyDown (KeyCode.RightArrow)) {
							if((Contorl_Example.BLE_aY >0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
					GameStaticData.canButton_aY = false;	
					SoundValue += 0.1f;
				}
				if (SoundValue > 1)
					SoundValue = 1;
				if (SoundValue < 0)
					SoundValue = 0;
				GameStaticData.SoundValue = SoundValue;
				this.transform.FindChild ("Main").FindChild ("Sound").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);

			}

			if (isVR) {
		
				if((Contorl_Example.BLE_aY <-0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.LeftArrow)){
					GameStaticData.canButton_aY = false;	
					VRSelectNum--;
				}
				//if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if((Contorl_Example.BLE_aY >0.5f && GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
					GameStaticData.canButton_aY = false;	
					VRSelectNum++;
				
				}
				if (VRSelectNum > 1)
					VRSelectNum = 1;
				if (VRSelectNum < 0)
					VRSelectNum = 0;

				switch (VRSelectNum) {
				case 0:
					VROnSelect.SetActive (true);
					VROffSelect.SetActive (false);

					break;
				case 1:
					VROnSelect.SetActive (false);
					VROffSelect.SetActive (true);

					break;
				}


				if ((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) {
					GameStaticData.canButton_RB = false;
					#if UNITY_IPHONE
					switch (VRSelectNum) {
					case 0:
						Destroy(GameStaticData.SaveMidLine);
						GameStaticData.SaveMidLine = Instantiate (GameStaticData.MidLine) as GameObject;
						DontDestroyOnLoad(GameStaticData.SaveMidLine);
						GameStaticData.isVR = true;
			

						GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().enabled = true;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = true;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = true;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = true;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = true;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = true;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = true;
						//GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = true;
						//GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = true;
						//GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).gameObject.SetActive (true);
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).gameObject.SetActive (true);
						break;
					case 1:
						Destroy(GameStaticData.SaveMidLine);
						GameStaticData.isVR = false;

							GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = false;
							GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = false;
							GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
							GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = false;

						GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().enabled = false;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).gameObject.SetActive (false);
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).gameObject.SetActive (false);

						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;

					
						break;
					}

					#elif UNITY_ANDROID
					switch (VRSelectNum) {
					case 0:
					Destroy(GameStaticData.SaveMidLine);
					GameStaticData.SaveMidLine = Instantiate (GameStaticData.MidLine) as GameObject;
					DontDestroyOnLoad(GameStaticData.SaveMidLine);
					GameStaticData.isVR = true;

					if (SystemInfo.supportsGyroscope ) {

							GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = true;


							GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().enabled = true;


							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = false;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = true;

							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;

					GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = true;
					GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = true;
					GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
					}else{

							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<GvrEye> ().enabled = false;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<GvrEye> ().enabled = false;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;
							GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = true;

					}
					
						break;
					case 1:
						GameStaticData.isVR = false;
					Destroy(GameStaticData.SaveMidLine);


						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().VRModeEnabled = false;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableAlignmentMarker = false;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().EnableSettingsButton = false;
						GameObject.Find ("GvrMain").GetComponent<GvrViewer> ().enabled = false;

						GameObject.Find ("GvrMain").transform.GetChild (0).GetComponent<GvrHead> ().enabled = false;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<StereoController> ().enabled = false;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = false;
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Camera> ().enabled = false;

						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
						GameObject.Find ("GvrMain").transform.GetChild (0).GetChild (0).GetComponent<Camera> ().enabled = true;


						break;
					}
					#endif



				}
				this.transform.FindChild ("Main").FindChild ("VR").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);

			}
		
		}

		if (selectNum > 2)
			selectNum = 2;
		if (selectNum < 0)
			selectNum = 0;

		if (!GameStaticData.isVR) {
			VROnSprite.color = new Color32 (50, 50, 50, 255);
			VROffSprite.color = new Color32 (32, 118, 118, 255);

		} else {
			VROnSprite.color = new Color32 (32, 118, 118, 255);
			VROffSprite.color = new Color32 (50, 50, 50, 255);
		}

		if (!isMusic && !isSound && !isVR) {
			switch (selectNum) {
			case 0:
				this.transform.FindChild ("Main").FindChild ("Music").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1);
				this.transform.FindChild ("Main").FindChild ("Sound").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1, 0);
				this.transform.FindChild ("Main").FindChild ("VR").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1,0);


				break;
			case 1:

				this.transform.FindChild ("Main").FindChild ("Music").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1, 0);
				this.transform.FindChild ("Main").FindChild ("Sound").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1);
				this.transform.FindChild ("Main").FindChild ("VR").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1,0);

				break;

			
			case 2:

			this.transform.FindChild ("Main").FindChild ("Music").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1, 0);
			this.transform.FindChild ("Main").FindChild ("Sound").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1,0);
			this.transform.FindChild ("Main").FindChild ("VR").GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1);

			break;

		}
		}
		if((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)){
			GameStaticData.canButton_RB = false;
			if (!isMusic && !isSound && !isVR) {
				switch (selectNum) {
				case 0:
					isMusic = true;
					break;
				case 1:
					isSound = true;
					break;
				case 2:
					isVR = true;
					break;


				}
			} else {
				OutOne ();
			}

		}
	
		//if (Input.GetKeyDown (KeyCode.S)) {
		if((Contorl_Example.BLE_LB && GameStaticData.canButton_LB)|| Input.GetKeyDown (KeyCode.S)){

	

			GameStaticData.canButton_LB = false;
			if (isMusic || isSound || isVR) {
				OutOne ();
			} else {
				Destroy (this.gameObject);
				GameObject.Find ("Button").transform.GetChild (0).gameObject.SetActive (true);
				if (GameStaticData.isVR && SystemInfo.supportsGyroscope) {
					GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
					GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = true;
					GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = true;
				} else {
					GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
					GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
					GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;
				}
			}

		}



	}
	void OutOne(){
	
		isMusic = false;
		isSound = false;
		isVR = false;
		VROnSelect.SetActive (false);
		VROffSelect.SetActive (false);
	}

}
