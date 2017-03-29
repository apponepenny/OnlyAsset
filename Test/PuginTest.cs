using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuginTest : MonoBehaviour {

	public Text ScanText;
	public Text SeedText;
	public Text BrakesText;
	public Text Mode1Text;
	public Text Mode2Text;
	public Text Key5Text;
	public Text x;
	public Text y;
	public Text z;


	public ScrollViewSet mScroll;
	void Awake(){
	}
	// Use this for initialization
	void Start () {
		Invoke("SetGSensorData",3);
	}


	public void SetGSensorData(){
		BleShootingPlugin.OnUnitySetGSensorData (1);
	}
	// Update is called once per frame
	void Update () {
//		Debug.Log("test");
		if(BleShootingPlugin.GetIsEnabled()){
			if(BleShootingPlugin.GetKey1ButtonEvent ())
				SeedText.text="true";
			else
				SeedText.text="false";
			if(BleShootingPlugin.GetKey2ButtonEvent ())
				BrakesText.text="true";
			else
				BrakesText.text="false";
			if(BleShootingPlugin.GetKey3ButtonEvent ())
				Mode1Text.text="true";
			else
				Mode1Text.text="false";
			if(BleShootingPlugin.GetKey4ButtonEvent ())
				Mode2Text.text="true";
			else
				Mode2Text.text="false";
			if(BleShootingPlugin.GetKey5ButtonEvent ())
				Key5Text.text="true";
			else
				Key5Text.text="false";

			x.text=BleShootingPlugin.GetXDegree().ToString();
			y.text=BleShootingPlugin.GetYDegree().ToString();
			z.text=BleShootingPlugin.GetZDegree().ToString();
			ScanText.text=BleShootingPlugin.GetBluetoothMesaage();
		}
		else{
			ScanText.text=BleShootingPlugin.GetBluetoothMesaage();
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
