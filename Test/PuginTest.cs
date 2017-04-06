using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuginTest : MonoBehaviour {



	public ScrollViewSet mScroll;
	void Awake(){
	}
	// Use this for initialization
	void Start () {
		Invoke("SetGSensorData",3);

		DontDestroyOnLoad (this.gameObject);
		DontDestroyOnLoad (GameObject.Find("GSensorPlugin#"));
	}


	public void SetGSensorData(){
		BleShootingPlugin.OnUnitySetGSensorData (1);
	}
	// Update is called once per frame
	void Update () {
//		Debug.Log("test");
		GameStaticData.isConnect = BleShootingPlugin.GetIsEnabled ();
		if(BleShootingPlugin.GetIsEnabled()){

			if (BleShootingPlugin.GetKey1ButtonEvent ())
				Contorl_Example.BLE_RB = true;
			else
				Contorl_Example.BLE_RB = false;

			if(BleShootingPlugin.GetKey2ButtonEvent ())
				Contorl_Example.BLE_LT = true;

			else
				Contorl_Example.BLE_LT = false;

			if(BleShootingPlugin.GetKey3ButtonEvent ())
				Contorl_Example.BLE_RL = true;

			else
				Contorl_Example.BLE_RL = false;

			if (BleShootingPlugin.GetKey4ButtonEvent ())
				Contorl_Example.BLE_LB = true;
			else
				Contorl_Example.BLE_LB = false;

			if(BleShootingPlugin.GetKey5ButtonEvent ())
				Contorl_Example.BLE_RT = true;

			else
				Contorl_Example.BLE_RT = false;


			Contorl_Example.BLE_aX=(float)BleShootingPlugin.GetXDegree()/127;
			Contorl_Example.BLE_aY=(float)-BleShootingPlugin.GetYDegree()/127;
			Contorl_Example.BLE_aZ=(float)BleShootingPlugin.GetZDegree()/127;
			//ScanText.text=BleShootingPlugin.GetBluetoothMesaage();
		}
		else{
			//ScanText.text=BleShootingPlugin.GetBluetoothMesaage();

		}
	}

	public void Scan(){
		Debug.Log("Sacan");
		BleShootingPlugin.OnUnityStartScan(); 
		mScroll.CancelButton();
	}
	public void Disconnect(){
		Debug.Log("Disconnect");
		BleShootingPlugin.OnUnityStopScan(); 

	}
	public void Vibrates(){
		BleShootingPlugin.onUnityColiderEngine(true); 
		//BleShootingPlugin.onUnityColiderEngine(1); 
	}
	public void closeVibrates(){
		BleShootingPlugin.onUnityColiderEngine(false); 
		//GSensorPlugin.onUnityColiderEngine(0); 
	}

	public void SetGSensorRowData( int type){
		BleShootingPlugin.OnUnitySetGSensorData (type);
	}

}
