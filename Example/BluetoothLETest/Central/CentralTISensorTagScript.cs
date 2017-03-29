using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;


public class CentralTISensorTagScript : MonoBehaviour
{
	public Transform PanelCentral;
	public Text Name;
	public Text Address;
	public Text TextConnectButton;

	public GameObject PanelTemperature;
	public Text TextTemperatureEnable;
	public Text TextTemperatureAmbient;
	public Text TextTemperatureTarget;
	
	public GameObject PanelAccelerometer;
	public Text TextAccelerometerEnable;
	public Text TextAccelerometerX;
	public Text TextAccelerometerY;
	public Text TextAccelerometerZ;

	private string _temperatureServiceUUID = FullUUID ("AA00");
	private string _temperatureReadWriteUUID = FullUUID ("AA01");
	private string _temperatureConfigureUUID = FullUUID ("AA02");

	//private string _accelerometerServiceUUID = FullUUID ("AA10");
	//private string _accelerometerReadWriteUUID = FullUUID("AA11");
	//private string _accelerometerConfigureUUID = FullUUID ("AA12");

	private string _accelerometerServiceUUID = FullUUID ("FFF0");
	private string _accelerometerReadWriteUUID = FullUUID("FFF1");
	private string _accelerometerConfigureUUID = FullUUID ("FFF2");

	private bool _connecting = false;
	private string _connectedID = null;

	bool _connected = false;
	bool Connected
	{
		get { return _connected; }
		set
		{
			if (_connected != value)
			{
				_connected = value;
				
				if (_connected)
				{
					TextConnectButton.text = "Disconnect";
					TemperatureEnabled = false;
					AccelerometerEnabled = false;
					_connecting = false;
					
				}
				else
				{
					TextConnectButton.text = "Connect";
					PanelTemperature.SetActive (false);
					PanelAccelerometer.SetActive (false);
					_connectedID = null;
				}
			}
		}

	}



	public void Initialize (CentralPeripheralButtonScript centralPeripheralButtonScript)
	{
		Connected = false;

		Name.text = centralPeripheralButtonScript.TextName.text;
		Address.text = centralPeripheralButtonScript.TextAddress.text;
		TextTemperatureAmbient.text = "...";
		TextTemperatureTarget.text = "...";
		TextAccelerometerX.text = "...";
		TextAccelerometerY.text = "...";
		TextAccelerometerZ.text = "...";
	}
	
	void disconnect (Action<string> action)
	{	
		if (TemperatureEnabled || AccelerometerEnabled)
		{
			TemperatureEnabled = false;
			AccelerometerEnabled = false;
		

		}
		else
			BluetoothLEHardwareInterface.DisconnectPeripheral (Address.text, action);
	}
	
	public void OnBack ()
	{
		if (Connected)
		{
			disconnect ((Address) => {
				
				Connected = false;


				BLETestScript.Show (PanelCentral.transform);
			});
		}
		else
			BLETestScript.Show (PanelCentral.transform);
	}

	void OnCharacteristicNotification (string deviceAddress, string characteristicUUID, byte[] bytes)
	{





		if (deviceAddress.CompareTo (Address.text) == 0) {
			if (IsEqual (characteristicUUID, _accelerometerReadWriteUUID)) {
				if (bytes.Length >= 1) {
					//float x = CharSignedAtOffset (bytes, 10);
					//float y = CharSignedAtOffset (bytes, 11);
					//float z = CharSignedAtOffset (bytes, 12);
					Contorl_Example.test = bytes [4];
					Contorl_Example.test = (sbyte)bytes [4];

					if (CharSignedAtOffset (bytes, 4) == 74) {
						//updateLog("Left Trigger : Onclick");
						Contorl_Example.BLE_RL = true;

					} else if (CharSignedAtOffset (bytes, 4) == 138) {

						Contorl_Example.BLE_RL = false;
				

					}


					if (CharSignedAtOffset (bytes, 6) == 51) {
						//updateLog("Left Trigger : Onclick");
						Contorl_Example.BLE_LT = true;

					} else if (CharSignedAtOffset (bytes, 6) == 85) {

						Contorl_Example.BLE_LT = false;
						GameStaticData.canButton_LT = true;

					}

					//Right Trigget (sbyte)data[7]
					if (CharSignedAtOffset (bytes, 7) == 68) {
						//updateLog("Right Trigger : Onclick");
						Contorl_Example.BLE_RT = true;


					} else if (CharSignedAtOffset (bytes, 7) == 102) {
						Contorl_Example.BLE_RT = false;
						GameStaticData.canButton_RT = true;
					}


					//Right Trigget (sbyte)data[8]
					if (CharSignedAtOffset (bytes, 8) == 17) {
						//updateLog("Right Button : Onclick");
						Contorl_Example.BLE_RB = true;


					} else if (CharSignedAtOffset (bytes, 8) == 119) {
						Contorl_Example.BLE_RB = false;
						GameStaticData.canButton_RB = true;

					
					}

					//Left Trigget (sbyte)data[9]
					if (CharSignedAtOffset (bytes, 9) == 34) {
						//updateLog("Left Button : Onclick");
						Contorl_Example.BLE_LB = true;


					} else if (CharSignedAtOffset (bytes, 9) == 136) {
						Contorl_Example.BLE_LB = false;
						GameStaticData.canButton_LB = true;

					}

					float x = (sbyte)bytes [10] / 127.0f;
					float y = (sbyte)bytes [11] / 127.0f;
					float z = (sbyte)bytes [12] / 127.0f;
					//GameObject.Find ("Canvas").transform.FindChild ("1").GetComponent<Text> ().text ="1 : "+ y.ToString();
				
					if ((float)y < 0) {
						Contorl_Example.BLE_aY = (1 + (float)y);

					} else {
						Contorl_Example.BLE_aY = (float)y;
					
					}
					Contorl_Example.BLE_aX = Mathf.Clamp((float)x,0,1);
					Contorl_Example.BLE_aZ = (float)z;


					//	GameObject.Find ("Canvas").transform.FindChild ("2").GetComponent<Text> ().text = Contorl_Example.BLE_aY.ToString();
					if (GameStaticData.canMotor) {
						byte[] motor = new byte[8];
						motor [0] = 0x5a;
						motor [1] = 0xff;

						SendBytes (_accelerometerServiceUUID, _accelerometerConfigureUUID, motor, huhu);

					
					} else {
				
						byte[] motor = new byte[8];
						motor [0] = 0x5a;
						motor [1] = 0x00;

						SendBytes (_accelerometerServiceUUID, _accelerometerConfigureUUID, motor, huhu);
						GameStaticData.isCol = false;
					
					
					}
				
			

				}
			}

		} 
	}
	void huhu(string a){
	
	}
	void OnApplicationQuit(){
		byte[] motor = new byte[8];
		motor [0] = 0x5a;
		motor [1] = 0x00;

		SendBytes (_accelerometerServiceUUID, _accelerometerConfigureUUID, motor, huhu);


	}

	private bool _temperatureEnabled = false;
	private bool TemperatureEnabled
	{
		get { return _temperatureEnabled; }
		set
		{
			if (_temperatureEnabled != value)
			{
				if (_temperatureEnabled)
				{
					EnableFeature (_temperatureServiceUUID, _temperatureConfigureUUID, 0x00, (enableCharacteristicUUID) => {

						if (IsEqual (enableCharacteristicUUID, _temperatureConfigureUUID))
						{
							BluetoothLEHardwareInterface.UnSubscribeCharacteristic (_connectedID, _temperatureServiceUUID, _temperatureReadWriteUUID, (characteristicUUID) => {

								TextTemperatureEnable.text = "Enable";
								TextTemperatureAmbient.text = "...";
								TextTemperatureTarget.text = "...";
								_temperatureEnabled = value;
							});
						}
					});
				}
				else
				{


					EnableFeature (_temperatureServiceUUID, _temperatureConfigureUUID, 0x01, (enableCharacteristicUUID) => {
						
						if (IsEqual (enableCharacteristicUUID, _temperatureConfigureUUID))
						{
							BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress (_connectedID, _temperatureServiceUUID, _temperatureReadWriteUUID, (deviceAddress, characteristicUUID) => {
						
								TextTemperatureEnable.text = "Disable";
								_temperatureEnabled = value;

							}, OnCharacteristicNotification);
						}
					});


				}
			}
		}
	}

	public void OnTemperatureEnable ()
	{
		TemperatureEnabled = !TemperatureEnabled;
	}
	
	private bool _accelerometerEnabled = false;
	private bool AccelerometerEnabled
	{
		get { return _accelerometerEnabled; }
		set
		{
			if (_accelerometerEnabled != value)
			{
				if (_accelerometerEnabled)
				{
					EnableFeature (_accelerometerServiceUUID, _accelerometerConfigureUUID, 0x00, (enableCharacteristicUUID) => {
						
						if (IsEqual (enableCharacteristicUUID, _accelerometerConfigureUUID))
						{
							BluetoothLEHardwareInterface.UnSubscribeCharacteristic (_connectedID, _accelerometerServiceUUID, _accelerometerReadWriteUUID, (characteristicUUID) => {
								
								TextAccelerometerEnable.text = "Enable";
								TextAccelerometerX.text = "...";
								TextAccelerometerY.text = "...";
								TextAccelerometerZ.text = "...";
								_accelerometerEnabled = value;
							});
						}
					});
				}
				else
				{
					/*
					EnableFeature (_accelerometerServiceUUID, _accelerometerConfigureUUID, 0xC0, (enableCharacteristicUUID) => {
						
						if (IsEqual (enableCharacteristicUUID, _accelerometerConfigureUUID))
						{
							BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress (_connectedID, _accelerometerServiceUUID, _accelerometerReadWriteUUID, (deviceAddress, characteristicUUID) => {
								
								TextAccelerometerEnable.text = "Disable";
								_accelerometerEnabled = value;
								
							}, OnCharacteristicNotification);
						}
					});
					*/

						BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress (_connectedID, _accelerometerServiceUUID, _accelerometerReadWriteUUID, (deviceAddress, characteristicUUID) => {
						TextAccelerometerEnable.text = "Disable";

						_accelerometerEnabled = value;
					}, OnCharacteristicNotification);
				


				}
			}
		}
	}
	
	public void OnAccelerometerEnable ()
	{
		AccelerometerEnabled = !AccelerometerEnabled;
	}

	public void OnConnect ()
	{
		if (!GameStaticData.isConnect) {
			if (!_connecting) {
				if (Connected) {
					disconnect ((Address) => {
						// this callback is shared with the one below
						// if this disconnect method is called then both this callback
						// and the one below will get called.
						// if this method has not been called and the device automatically
						// disconnects, then the one below will be called and this one will not be
						Connected = false;
						GameStaticData.isConnect = false;
						GameStaticData.InReScan = false;
						GameStaticData.disconnectTimes++;

					});
				} else {
				
					BusyScript.IsBusy = true;

					BluetoothLEHardwareInterface.ConnectToPeripheral (Address.text, (address) => {
						GameStaticData.isConnect = true;
						GameStaticData.InReScan = false;
						PanelCentral.GetComponent<CentralScript>().Stop_Scan();
						#if UNITY_IPHONE
						if (GameStaticData.sceneName == "Game_Home" || GameStaticData.isStart) {

							if (GameStaticData.isGO)
							if (GameObject.FindWithTag ("UIUI").transform.FindChild ("ReScanBLE(Clone)").gameObject)
								Destroy (GameObject.FindWithTag ("UIUI").transform.FindChild ("ReScanBLE(Clone)").gameObject);
						

						}
				#elif UNITY_ANDROID
						if (GameStaticData.sceneName == "Game_Home" ) {
							if(GameObject.Find("ReScanBLE(Clone)"))
								Destroy (GameObject.Find("ReScanBLE(Clone)"));


						}

						if(GameStaticData.isStart){
							if (GameObject.FindWithTag ("UIUI").transform.FindChild ("ReScanBLE(Clone)").gameObject)
								Destroy (GameObject.FindWithTag ("UIUI").transform.FindChild ("ReScanBLE(Clone)").gameObject);
							
						}
						#endif
						if (!GameStaticData.isstop)
							Time.timeScale = 1;
				

						_connectedID = address;

						GameStaticData.CheckAdress.Add (address);

						Connected = true;
						//AccelerometerEnabled = true;

					//	BluetoothLEHardwareInterface.Log(string.Format ("Here is Connect"));


					},
						(address, serviceUUID) => {
						},
						(address, serviceUUID, characteristicUUID) => {

							// temperature service
							if (IsEqual (serviceUUID, _temperatureServiceUUID)) {
								if (IsEqual (characteristicUUID, _temperatureReadWriteUUID)) {
									PanelTemperature.SetActive (true);
									BusyScript.IsBusy = false;
								}
							}
					
					// accelerometer service
					else if (IsEqual (serviceUUID, _accelerometerServiceUUID)) {
								if (IsEqual (characteristicUUID, _accelerometerReadWriteUUID)) {
									PanelAccelerometer.SetActive (true);
									BusyScript.IsBusy = false;
								}
							}
						}, (address) => {
					
						// this will get called when the device disconnects
						// be aware that this will also get called when the disconnect
						// is called above. both methods get call for the same action
						// this is for backwards compatibility
					

						Connected = false;
						GameStaticData.isConnect = false;
						GameStaticData.InReScan = false;
						GameStaticData.disconnectTimes++;


					});

					_connecting = true;
				}
			}
		}
	}


	// Use this for initialization
	void Start ()
	{
		
	




	}
	
	// Update is called once per frame
	void Update ()
	{
//		GameObject.Find ("Canvas").transform.FindChild ("a").GetComponent<Text> ().text = GameStaticData.isConnect.ToString ();
	


		if(!AccelerometerEnabled)
		AccelerometerEnabled = true;

	
	}

	// this calculation comes from the TI web site for the sensortag
	float AmbientTemperature (byte[] bytes)
	{
		return ((float)ShortUnsignedAtOffset (bytes, 2)) / 128f;
	}

	// this calculation comes from the TI web site for the sensortag


	int CharSignedAtOffset (byte[] bytes, int offset)
	{
		return ((char)bytes[offset]);
	}

	int ShortSignedAtOffset (byte[] bytes, int offset)
	{
		int lowerByte = bytes[offset];
		int upperByte = (char)(bytes[offset + 1]);
		return ((upperByte << 8) + lowerByte);
	}

	int ShortUnsignedAtOffset (byte[] bytes, int offset)
	{
		int lowerByte = bytes[offset];
		int upperByte = bytes[offset + 1];
		return ((upperByte << 8) + lowerByte);
	}

	void EnableFeature (string serviceUUID, string configurationUUID, byte configValue, Action<string> action)
	{
		SendByte (serviceUUID, configurationUUID, configValue, action);
	}

	// this will create a full UUID from a 16 bit UUID specifically for the sensortag
	static string FullUUID (string uuid)
	{

			return "0000" + uuid + "-0000-1000-8000-00805F9B34FB";
	

	}

	bool IsEqual(string uuid1, string uuid2)
	{
		if (uuid1.Length == 4)
			uuid1 = FullUUID (uuid1);
		if (uuid2.Length == 4)
			uuid2 = FullUUID (uuid2);

		return (uuid1.ToUpper().CompareTo(uuid2.ToUpper()) == 0);
	}
	
	void SendByte (string serviceUUID, string characteristicUUID, byte value, Action<string> action)
	{
		BluetoothLEHardwareInterface.Log(string.Format ("Sending: {0}", value));
		byte[] data = new byte[] { value };
		BluetoothLEHardwareInterface.WriteCharacteristic (_connectedID, serviceUUID, characteristicUUID, data, data.Length, action != null, action);
	}
	
	void SendBytes (string serviceUUID, string characteristicUUID, byte[] data, Action<string> action)
	{
		BluetoothLEHardwareInterface.Log(string.Format ("Sending: {0}", data));
		//BluetoothLEHardwareInterface.WriteCharacteristic (_connectedID, serviceUUID, characteristicUUID, data, data.Length, action != null, action);
		BluetoothLEHardwareInterface.WriteCharacteristic (_connectedID, serviceUUID, characteristicUUID, data, data.Length, false, action);



	}

}
