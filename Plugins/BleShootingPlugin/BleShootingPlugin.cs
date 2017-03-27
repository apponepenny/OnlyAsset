
//  1. creat a GameObject, and name  "GSensorPlugin#" 
//  function:
//public static int GetXDegree()  
//public static int GetYDegree()  
//public static int GetZDegree()  
//public static bool GetKey1ButtonEvent ()
//public static bool GetKey2ButtonEvent ()
//public static bool GetKey3ButtonEvent ()
//public static bool GetKey4ButtonEvent ()


using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class BleShootingPlugin : MonoBehaviour {

	public delegate void EventType_String(string name);
	void Start(){

		if (!Application.isEditor){
			//Debug.Log("inital OnUnity1");
			_InitGSensor();
		}

		DontDestroyOnLoad(GameObject.Find("GSensorPlugin#"));

		//		Invoke("onUnityStartScannnnnnn",3);
		Debug.Log("inital OnUnity Start  "+GameObject.Find("GSensorPlugin#"));

	}

	//===========================  unity Send
//	public void initialPluginnnn(){
//		//Debug.Log("inital OnUnity");
//		_InitGSensor();
//	}
//	public void  onUnityStartScan (){
//		//Debug.Log("OnUnityStartScan");
//		_onUnityStartScan();
//	}

	public static void OnUnityStartScan ()
	{
		Debug.Log("OnUnityStartScan");
		_onUnityStartScan();

		DeviceName.Clear();

	}
	public static void OnUnityStopScan ()
	{
		_onUnityStopScan();
	}

	public static void OnUnitySetGSensorData (int type)
	{


		//type 1:12bit的数据,
		//        2:8bit的数据,
		//        3:BLE设备的原始数据， 数据将只会从事件onGSensorRawData上传给UI， 事件onKeyEevent，OnGSensorInfo将不会有数据上传。


		_onUnitySetGSensorData(type);
	}


	public static void onUnityColiderEngine (bool visible)
	{


		//Debug.Log("!!!!!!!!   onUnityColiderEngine in unity");
		_onUnityColiderEngine(visible);
	}
	public static void onChoseToConnectDevice (string key)
	{
		
		if(DeviceName.Contains(key)){
		
			int temp=DeviceName.IndexOf(key) ;
//			if(temp==-1)
//				return;
			Debug.Log("!!!!!!!!   onChoseToConnectDevice in unity"+temp+"   " +key);
			_onChoseToConnectDevice(temp);

		}
			

	}
	//===========================  unity Recept

	public void TimeCheck(){
	
	}
	public  void OnCONNECTNotificationEvent(string key)//forIos
	{
		Debug.Log("OnCONNECTNotificationEvent  onUnity:" + key );
		//BluetoothMesaage=key+ "    unity Receive:"+System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

//				if(key.StartsWith("onBleConnected"))
//					m_Enabled=true;
//
//				else if(key.StartsWith("onBleDisconnect")){
//		
//					m_Enabled=false;
//					OnUnityStartScan ();
//				}




		#if UNITY_IPHONE 

		switch(key){
			case"Disconnect !":
				m_Enabled=false;
				break;
			case"Connected !":
				m_Enabled=true;
				break;
			case"Connect Fail !":
				m_Enabled=false;
				break;
			case"Connecting !":
				break;
			case"Start Connect !":
				break;
			default:
				BluetoothMesaage=key;
			break;
		}

		#elif UNITY_ANDROID 
		if(key.StartsWith("eBleState_Connected"))
			m_Enabled=true;

		else if(key.StartsWith("onBleDisconnect")){

			m_Enabled=false;
			OnUnityStartScan ();
		} 
		#endif


	}
	public static event EventType_String onDeviceRceiveEvent;
	public  void OnRceiveDeviceNameEvent(string key){


		Debug.Log("OnRceiveDeviceNameEvent  onUnity:" + key );
		DeviceName.Add(key);
		onDeviceRceiveEvent(key);
	}

	//	public static event EventType_Int onXDegreeEvent;// 
	public  void OnXDegreeEvent(string key)//forIos
	{
		//Debug.Log("Unity OnXDegreeEvent  onUnity:" + key);
		string[] elements=Regex.Split(key,",");
		XDegree=int.Parse(elements[0]);
		YDegree=int.Parse(elements[1]);
		ZDegree=int.Parse(elements[2]);


	}


	public  void OnKey1ButtonEvent(string key)//forIos
	{
		Debug.Log("Unity OnKey1ButtonEvent  onUnity:" + key);
		int OnTag=int.Parse(key);
		if(OnTag==1)
			Key1=true;
		else
			Key1=false;
		//onSpeedButtonEvent(OnTag);
	}

	public   void OnKey2ButtonEvent(string key)//
	{
		//Debug.Log("Unity OnBrakesButtonEvent onUnity:" + key);
		int OnTag=int.Parse(key);
		if(OnTag==1)
			Key2=true;
		else
			Key2=false;
		//onBrakesButtonEvent(OnTag);
	}
	public   void OnKey3ButtonEvent(string key)//
	{
		//Debug.Log("Unity OnMode1ButtonEvent onUnity:" + key);

		int OnTag=int.Parse(key);

		if(OnTag==1)
			Key3=true;
		else
			Key3=false;



	}
	public   void OnKey4ButtonEvent(string key)//
	{
		//Debug.Log("Unity OnMode2ButtonEvent onUnity:" + key);
		int OnTag=int.Parse(key);
		if(OnTag==1)
			Key4=true;
		else
			Key4=false;
	}
	//=========================================UnityReturn Get

	public static bool GetKey1ButtonEvent (){
		return Key1 ;
	}

	public static bool GetKey2ButtonEvent (){
		return Key2;
	}
	public static bool GetKey3ButtonEvent (){
		return Key3;
	}
	public static bool GetKey4ButtonEvent (){
		return Key4;
	}
	public static bool GetIsEnabled()
	{
		return m_Enabled;
		//return true;
	}
	public static void SetIsEnabled(bool user)
	{
		m_Enabled=user;
		//return true;
	}
	public static bool GetUserEnable(){
		return  UserEnable;
	}
	public static void SetUserEnable(bool user){
		UserEnable=user;

	}
	public static string GetBluetoothMesaage()
	{
		return BluetoothMesaage;
	}
	public static int GetXDegree()
	{
		return XDegree;
	}
	public static int GetYDegree()
	{
		return YDegree;
	}
	public static int GetZDegree()
	{
		return ZDegree;
	}

	private static bool Key1 =false;
	private static bool Key2=false;
	private static bool Key3=false;
	private static bool Key4=false;
	private static int XDegree ;
	private static int YDegree;
	private static int ZDegree;
	private static bool m_Enabled =false;
	private static bool UserEnable =true;
	private static string BluetoothMesaage="Search your Bluetooth !!!!";
	private static List<string> DeviceName=new List<string>();


	#if UNITY_IPHONE  && !UNITY_EDITOR   // iOS Platform
	[DllImport("__Internal")]
	private static extern void _InitGSensor();
	[DllImport("__Internal")]
	private static extern void _onUnityStartScan();
	[DllImport("__Internal")]
	private static extern void _onUnityStopScan();
	[DllImport("__Internal")]
	private static extern void _onUnityColiderEngine(bool visible);
	[DllImport("__Internal")]
	private static extern void _onChoseToConnectDevice(int num);
	private static void _onUnitySetGSensorData(int type){}
	#elif UNITY_ANDROID && !UNITY_EDITOR   // Android Platform  
	private static void  _InitGSensor()
	{

		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
		Debug.Log("HanderPianoPlugin unity  _InitHanderPiano() in  android!!  ");
		mjc.CallStatic("InitGSensor");

		}
	}
	private static void  _onUnityStartScan(){
		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		//using(AndroidJavaClass mjc =  new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
			Debug.Log("HanderPianoPlugin unity  _onUnityStartScan() in  android!!  ");
			mjc.CallStatic("onUnityStartScan");


		}
	}
	private static void  _onUnityStopScan(){
		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		//using(AndroidJavaClass mjc =  new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
			Debug.Log("HanderPianoPlugin unity  _onUnityStopScan() in  android!!  ");
			mjc.CallStatic("onUnityStopScan");


		}
	}
	private static void _onUnityColiderEngine(bool visible){
		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
			Debug.Log("HanderPianoPlugin unity  _InitHanderPiano() in  android!!  ");
			mjc.CallStatic("onUnityColiderEngine",visible);

		}
	}
	private static void _onChoseToConnectDevice(int num){
		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
			Debug.Log("HanderPianoPlugin unity  _onChoseToConnectDevice() in  android!!  ");
			mjc.CallStatic("onChoseToConnectDevice", num);

		}
	}

	private static void _onUnitySetGSensorData(int type){
		AndroidJNI.AttachCurrentThread();
		using(AndroidJavaClass mjc = new AndroidJavaClass("com.innomind.belshooting.ComBleWrapper"))
		{
			Debug.Log("HanderPianoPlugin unity  _onChoseToConnectDevice() in  android!!  ");
			mjc.CallStatic("onsetGSensorData", type);

		}


	}
	#else
	private static  void _InitGSensor(){}
	private static  void _onUnityStartScan(){Debug.Log("_onUnityStartScan");}
	private static  void _onUnityStopScan(){}
	private static void _onUnityColiderEngine(bool visible){Debug.Log("!!!!!_onUnityColiderEngine  "+ visible);}
	private static void _onChoseToConnectDevice(int num){}
	private static void _onUnitySetGSensorData(int type){}
	#endif
}
