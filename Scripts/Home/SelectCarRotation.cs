using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCarRotation : MonoBehaviour {
	public bool TurnCar = false;
	public bool TurnRCar = false;
	public int countnum;
	public float CarDist;
	public int NumOfCar;
	public Vector3 camPos;
	public float TurnSpeed;
	public Vector3[] CarPos;

	public GameObject ShowCarPropertyGameObject;
	int TopSpeed;
	int Accel;
	bool IsChangeCar;
	float tempTS;
	float tempAS;
	public Image TSImage;
	public Image ASImage;
	bool canPropTSMove;
	bool canPropASMove;

	public GameObject Prop ;
	int TSelectCar;
	public GameObject[] AllCar = new GameObject[12];
	public GameObject CarPro;

	LoadCarProperty LoadCarPropertyData = new LoadCarProperty();



	// Use this for initialization
	void Start () {

		LoadCarPropertyData.LoadDataFromXML();
//		PlayerPrefs.SetInt("UnlockedCarNum",2);
		canPropTSMove = true;
		canPropASMove = true;

		TopSpeed = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].TopSpeed;
		Accel = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].Accel;
		tempTS = 0;
		tempAS = 0;
		CarDist = 20;
		NumOfCar = 4;
		TurnSpeed = 200;
		TSImage = ShowCarPropertyGameObject.transform.GetChild(0).FindChild ("Speed_Text").GetChild (0).GetChild (0).GetComponent<Image>();
		ASImage = ShowCarPropertyGameObject.transform.GetChild(0).FindChild ("Accel_Text").GetChild (0).GetChild (0).GetComponent<Image>();
		CreateCar ();

//		print(LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].Accel);


	}
	
	// Update is called once per frame
	void Update () {
		
		_Input();
		ShowCarProperty ();

		reset_All_Button ();



	}

	void ShowCarProperty(){


		float PerTS;
		float PerAS;



		PerTS = (float)tempTS / 400;
		PerAS = (float)tempAS / 30;
		if (canPropTSMove) {
			if (tempTS < TopSpeed) {
				tempTS += Time.deltaTime * 200;
				if (tempTS >= TopSpeed)
					canPropTSMove = false;

			} else {

				tempTS -= Time.deltaTime * 200;
				if (tempTS <= TopSpeed)
					canPropTSMove = false;

			}
		}
		if (canPropASMove) {
			if (tempAS < Accel) {
				tempAS += Time.deltaTime * 30;
				if (tempAS >= Accel)
					canPropASMove = false;	

			} else {
				tempAS -= Time.deltaTime * 30;
				if (tempAS <= Accel)
					canPropASMove = false;
				
			}
		}

		if(!canPropTSMove)
			PerTS = (float)TopSpeed / 400;
		if(!canPropASMove)
			PerAS = (float)Accel / 30;
	//	PerTS = (float)TopSpeed / 200;
	//	PerAS = (float)Accel / 30;





		/*
		if (TSImage.fillAmount < PerTS) {
			TSImage.fillAmount += Time.deltaTime;
			if (TSImage.fillAmount >= PerTS)
				TSImage.fillAmount = PerTS;
		}
		if (ASImage.fillAmount < PerAS) {
			ASImage.fillAmount += Time.deltaTime;
			if (ASImage.fillAmount >= PerAS)
				ASImage.fillAmount = PerAS;
		}
		*/
			
	
		Prop.transform.FindChild ("TopSpeed").FindChild ("BG").GetChild (0).localScale = new Vector3 (PerTS*8.3f,1,1);
		Prop.transform.FindChild ("AccelSpeed").FindChild ("BG").GetChild (0).localScale = new Vector3 (PerAS*8.3f,1,1);

	//	Prop.transform.FindChild ("TopSpeed").FindChild ("BG").GetChild (0).localPosition = new Vector3((-5.11f + (Prop.transform.FindChild ("TopSpeed").FindChild ("BG").GetChild (0).localScale.x * 5.11f)),0,0);
	//	Prop.transform.FindChild ("AccelSpeed").FindChild ("BG").GetChild (0).localPosition = new Vector3((-5.11f + (Prop.transform.FindChild ("AccelSpeed").FindChild ("BG").GetChild (0).localScale.x * 5.11f)),0,0);



	}
		

	void CreateCar(){
	//	CarDist * 360/6 *Mathf.PI;
		int unlocknum ;
		float CarCoorX ;
		float CarCoorZ ;
		int HaveStar;

//		PlayerPrefs.SetInt ("HaveStar",0);a
		HaveStar = PlayerPrefs.GetInt ("HaveStar");
		unlocknum = ((int)(HaveStar / 3))+1;


		//HaveStar = 7;

	

		for (int i = 0; i < NumOfCar; i++){

			CarCoorX = CarDist * Mathf.Cos((360/NumOfCar * (i+1)-360/NumOfCar*4) * Mathf.Deg2Rad);
			CarCoorZ = CarDist * Mathf.Sin ((360/NumOfCar * (i+1)-360/NumOfCar*4)  * Mathf.Deg2Rad);


			//GameObject a = Instantiate(Resources.Load("Car/Car "+(i+1).ToString()),new Vector3(0,0,0),Quaternion.identity) as GameObject;
			GameObject a = Instantiate(AllCar[i],new Vector3(0,0,0),Quaternion.identity) as GameObject;

			a.transform.parent = GameObject.Find ("AllCar").transform;
			a.transform.localPosition = new Vector3 (CarCoorX,0,CarCoorZ);
			a.transform.localRotation = Quaternion.Euler (0,0,0);
			a.transform.FindChild ("lock").localScale = new Vector3 (0.1f, 0.1f, 0.1f);


			if (i < unlocknum)
				a.transform.FindChild ("lock").gameObject.SetActive (false);



		}

	
		//this.transform.localPosition = new Vector3(0,-2,28);
		camPos = this.transform.GetChild (0).localPosition;
		camPos.x = 0;

		camPos.y = 0;
		camPos.z = 0;
		//GameObject.Find("GvrMain").transform.position = camPos;

		GameObject CarProp = Instantiate (CarPro) as GameObject;
		CarProp.transform.parent = this.transform.GetChild (0);
		//CarProp.transform.localPosition = new Vector3 (0, 3, 0);
		CarProp.transform.parent = this.transform.parent.FindChild ("Prop");
		//CarProp.transform.localRotation = Quaternion.Euler (0,0,0);

		Prop = CarProp.transform.GetChild (0).gameObject;




		for (int i = 1; i < NumOfCar; i++) {

				this.transform.GetChild(i).gameObject.SetActive (false);
		}
	

	}

	void _Input(){
		

		int tempSelected = PlayerPrefs.GetInt ("UnlockedCarNum");
		if (TurnCar) {

			for (int i = 0; i < this.transform.childCount; i++) {

				int a = i + 1;
				if (a == this.transform.childCount) {
					a = 0;

				}


				this.transform.GetChild (i).localPosition = Vector3.MoveTowards (this.transform.GetChild (i).localPosition, CarPos [a], Time.deltaTime * TurnSpeed);


				if (this.transform.GetChild (i).localPosition == CarPos [a]) {
					TurnCar = false;
					this.transform.GetChild(TSelectCar).gameObject.SetActive (false);

				}

			}
		} else {


		//	if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if((Contorl_Example.BLE_aY <-0.5f&& GameStaticData.canButton_aY)|| Input.GetKeyDown (KeyCode.LeftArrow)){
				GameStaticData.canButton_aY = false;	
				print ("Left");
				canPropASMove = true;
				canPropTSMove = true;
				TSelectCar = GameStaticData.SelectedCar;
				GameStaticData.SelectedCar--;
				

				if (GameStaticData.SelectedCar < 0) {
					GameStaticData.SelectedCar = NumOfCar - 1;
				} else if (GameStaticData.SelectedCar > NumOfCar - 1) {
					GameStaticData.SelectedCar = 0;

				}



				CarPos = new Vector3[this.transform.childCount];

				for (int i = 0; i < this.transform.childCount; i++) {


					CarPos [i] = this.transform.GetChild (i).localPosition;

				}

				TurnCar = true;
				IsChangeCar = true;
				TopSpeed = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].TopSpeed;
				Accel = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].Accel;
				TSImage.fillAmount = 0;
				ASImage.fillAmount = 0;


				for (int i = 0; i < NumOfCar; i++) {
					
					if(i != TSelectCar)

					this.transform.GetChild(i).gameObject.SetActive (false);
				}
				this.transform.GetChild(GameStaticData.SelectedCar).gameObject.SetActive (true);

			} else 
				//if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if((Contorl_Example.BLE_aY >0.5f&& GameStaticData.canButton_aY) || Input.GetKeyDown (KeyCode.RightArrow)){
					GameStaticData.canButton_aY = false;	
				print ("Right");
				canPropASMove = true;
				canPropTSMove = true;
					TSelectCar = GameStaticData.SelectedCar;

				GameStaticData.SelectedCar++;
	
			

				if (GameStaticData.SelectedCar < 0) {
					GameStaticData.SelectedCar = NumOfCar - 1;
				} else if (GameStaticData.SelectedCar > NumOfCar - 1) {
					GameStaticData.SelectedCar = 0;

				}
		
			

				countnum = 0;
				CarPos = new Vector3[this.transform.childCount];

				for (int i = 0; i < this.transform.childCount; i++) {
					int b = i;
					if (b < 2) {
						b = this.transform.childCount - 2 + i;

					} else {
						b = countnum;
						countnum++;
					}

					CarPos [i] = this.transform.GetChild (b).localPosition;

				}
				TurnCar = true;
				IsChangeCar = true;
				TopSpeed = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].TopSpeed;
				Accel = LoadCarPropertyData.CarProperties [GameStaticData.SelectedCar].Accel;
				TSImage.fillAmount = 0;
				ASImage.fillAmount = 0;

					for (int i = 0; i < NumOfCar; i++) {
						if(i != TSelectCar)
						this.transform.GetChild(i).gameObject.SetActive (false);
					}
					this.transform.GetChild(GameStaticData.SelectedCar).gameObject.SetActive (true);



			} else 
				//if (Input.GetKeyDown (KeyCode.A)) {
					if((Contorl_Example.BLE_RB && GameStaticData.canButton_RB)||Input.GetKeyDown (KeyCode.A)){
						GameStaticData.canButton_RB = false;
						if (!this.transform.GetChild (GameStaticData.SelectedCar).FindChild("lock").gameObject.activeSelf) {
					GameStaticData.PlayerUsedCar = GameStaticData.SelectedCar;
					print (GameStaticData.PlayerUsedCar);
					LeaveSelectCar ();
				}
			
			}


	
		}
	

		//if (Input.GetKeyDown (KeyCode.S)) {
		if((Contorl_Example.BLE_LB && GameStaticData.canButton_LB) || Input.GetKeyDown (KeyCode.S)){

			LeaveSelectCar ();



		}







	}


	void LeaveSelectCar(){


		GameStaticData.canButton_LB = false;

		//	GameObject.Find ("Canvas").transform.FindChild("all").gameObject.SetActive(true);
		//	GameObject.Find ("Canvas").transform.FindChild("background").gameObject.SetActive(true);


		//GameObject.Find ("GvrMain").transform.position = new Vector3 (0,0,0);


		GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(true);
		Destroy (this.transform.parent.gameObject);	
		if (!SystemInfo.supportsGyroscope) {
			GameObject.Find ("GvrMain").transform.FindChild ("Head").rotation = Quaternion.Euler (0, 0, 0);
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = false;
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = false;
		} else {

			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackPosition = true;
			GameObject.Find ("GvrMain").transform.FindChild ("Head").GetComponent<GvrHead> ().trackRotation = true;
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


	
	

}
