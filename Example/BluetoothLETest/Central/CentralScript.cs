using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CentralScript : MonoBehaviour
{
	public Transform PanelTypeSelection;
	public Transform PanelScrollContents;
	public CentralRFduinoScript PanelCentralRFduino;
	public CentralTISensorTagScript PanelCentralTISensorTag;
	public GameObject CentralPeripheralButtonPrefab;
	public Text TextScanButton;

	public 	 Dictionary<string, CentralPeripheralButtonScript> _peripheralList;
	private bool _scanning = false;
	public bool isEq = false;
	public void Initialize ()
	{
		BluetoothLEHardwareInterface.Initialize (true, false, () => {
			
		}, (error) => {
		});
	}

	public void OnBack ()
	{
		RemovePeripherals ();

		if (_scanning)
			OnScan (); // this will stop scanning

		BluetoothLEHardwareInterface.DeInitialize (() => {
			BLETestScript.Show (PanelTypeSelection);
		});
	}

	protected string BytesToString (byte[] bytes)
	{
		string result = "";

		foreach (var b in bytes)
			result += b.ToString ("X2");

		return result;
	}
	public void Stop_Scan(){
	
		BluetoothLEHardwareInterface.StopScan ();
	}

	public void OnScan ()
	{

		RemovePeripherals ();

		// the first callback will only get called the first time this device is seen
		// this is because it gets added to a list in the BluetoothDeviceScript
		// after that only the second callback will get called and only if there is
		// advertising data available
		BluetoothLEHardwareInterface.ScanForPeripheralsWithServices (null, (address, name) => {

			AddPeripheral (name, address);

		}, (address, name, rssi, advertisingInfo) => {

			if (advertisingInfo != null)
				BluetoothLEHardwareInterface.Log (string.Format ("Device: {0} RSSI: {1} Data Length: {2} Bytes: {3}", name, rssi, advertisingInfo.Length, BytesToString (advertisingInfo)));
		});

		TextScanButton.text = "Stop Scan";
		_scanning = true;


		/*
			if (_scanning) {
				BluetoothLEHardwareInterface.StopScan ();
				TextScanButton.text = "Start Scan";
				_scanning = false;


			} else {
				RemovePeripherals ();

				// the first callback will only get called the first time this device is seen
				// this is because it gets added to a list in the BluetoothDeviceScript
				// after that only the second callback will get called and only if there is
				// advertising data available
				BluetoothLEHardwareInterface.ScanForPeripheralsWithServices (null, (address, name) => {

					AddPeripheral (name, address);

				}, (address, name, rssi, advertisingInfo) => {

					if (advertisingInfo != null)
						BluetoothLEHardwareInterface.Log (string.Format ("Device: {0} RSSI: {1} Data Length: {2} Bytes: {3}", name, rssi, advertisingInfo.Length, BytesToString (advertisingInfo)));
				});

				TextScanButton.text = "Stop Scan";
				_scanning = true;
			}

		//BluetoothLEHardwareInterface.Log(string.Format ("Here is Scan"));
*/

	}

	public void RemovePeripherals ()
	{
		for (int i = 0; i < PanelScrollContents.childCount; ++i)
		{
			GameObject gameObject = PanelScrollContents.GetChild (i).gameObject;
			Destroy (gameObject);
		}
		
		if (_peripheralList != null)
			_peripheralList.Clear ();
		
	}

	void AddPeripheral (string name, string address)
	{
		if (_peripheralList == null)
			_peripheralList = new Dictionary<string, CentralPeripheralButtonScript> ();

		if (!_peripheralList.ContainsKey (address))
		{
			GameObject peripheralObject = (GameObject)Instantiate (CentralPeripheralButtonPrefab);
			CentralPeripheralButtonScript script = peripheralObject.GetComponent<CentralPeripheralButtonScript> ();
			script.TextName.text = name;
			script.TextAddress.text = address;

			script.PanelCentralRFduino = PanelCentralRFduino;
			script.PanelCentralTISensorTag = PanelCentralTISensorTag;
			peripheralObject.transform.SetParent (PanelScrollContents);
			peripheralObject.transform.localScale = new Vector3 (1f, 1f, 1f);

			_peripheralList[address] = script;
	#if UNITY_IPHONE
			if (name == "VR RF Moto" ) {
				if (GameStaticData.CheckAdress.Count > 0) {
					for (int i = 0; i < GameStaticData.CheckAdress.Count; i++) {
						if (address == GameStaticData.CheckAdress [i]) {
							isEq = true;
							break;
						} else {
							isEq = false;
						}

					}

				} else {
					isEq = false;
					}

				if (!isEq) {
				JoinBLE (script);
				}

			}
	#elif UNITY_ANDROID
			if (name == "GP-GSensor" || name == "VR RF Racing") {
				JoinBLE (script);
			}
	#endif
			 





		}
	}


	void JoinBLE(CentralPeripheralButtonScript script){
		PanelCentralTISensorTag.Initialize (script);
		BLETestScript.Show (PanelCentralTISensorTag.transform);
		PanelCentralTISensorTag.OnConnect ();
		GameStaticData.j++;
	}

	// Use this for initialization
	void Start ()
	{
//		PanelCentralTISensorTag = GameObject.Find ("BleCanvas").GetComponent<BLETestScript> ().CentT1.GetComponent<CentralTISensorTagScript>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
