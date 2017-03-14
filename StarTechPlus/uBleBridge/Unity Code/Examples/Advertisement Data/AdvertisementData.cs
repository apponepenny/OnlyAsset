using UnityEngine;
using System.Collections;
using startechplus.ble;
using UnityEngine.UI;
using System;

namespace startechplus.ble.examples
{
	/**
	 * An example uBluetoothLe pluging application. In the Start() function the IBleBridge object is instantiated based on whether the Unity Player is running on Android or iOS.  
	 * Once started all interaction with the Bluetooth Device via the IBleBridge is handled via Action() callbacks.  These callbacks are set when the varioius IBleBridge functions are called.
	 * These callbacks are created by you, see the examples in this file.  For details about the Action() callbakcs see IBleBridge.cs.
	 * @see Start()
	 */ 
	public class AdvertisementData : MonoBehaviour {

		public Text logText;
		public ScrollRect scrollRect;

		public Text debugText;

		/*
		NOTES
		Action<string, string> localNameAction, 
		Action<string, byte[]> manufactureDataAction,
		Action<string, string, byte[]> serviceDataAction,
		Action<string, string> serviceAction,
		Action<string, string> overflowServiceAction,
		Action<string, string> txPowerLevelAction,
		Action<string, string> isConnectable,
		Action<string, string> solicitedServiceAction);
		*/

		public void AdvertiseLocalNameAction(string peripherialID, string localName)
		{
			updateLog("Bridge: AdvertiseLocalNameAction,  " + peripherialID + ", " + localName);
		}

		public void AdvertiseManufactureDataAction(string peripherialID, byte[]data)
		{
			updateLog("Bridge: AdvertiseManufactureDataAction, " + peripherialID + ", " + BitConverter.ToString(data));
		}

		public void AdvertiseServiceDataAction(string peripherialID, string serviceID, byte[] data)
		{
			updateLog("Bridge: AdvertiseServiceDataAction, " + peripherialID + ", " + serviceID + ", " + BitConverter.ToString(data));
		}

		public void AdvertiseServiceAction(string peripherialID, string serviceID)
		{
			updateLog("Bridge: AdvertiseServiceAction, " + peripherialID + ", " + serviceID);
		}

		public void AdvertiseOverflowServiceAction(string peripherialID, string serviceID)
		{
			updateLog("Bridge: AdvertiseOverflowServiceAction, " + peripherialID + ", " + serviceID);
		}

		public void AdvertiseTxPowerLevelActionAction(string peripherialID, string txPowerLevel)
		{
			updateLog("Bridge: AdvertiseTxPowerLevelActionAction, " + peripherialID + ", " + txPowerLevel);
		}

		public void AdvertiseIsConnectableAction(string peripherialID, string isConnectable)
		{
			updateLog("Bridge: AdvertiseIsConnectableAction, " + peripherialID + ", " + isConnectable);
		}

		public void AdvertiseSolicitedServiceAction(string peripherialID, string solicitedServiceID)
		{
			updateLog("Bridge: AdvertiseSolicitedServiceAction, " + peripherialID + ", " + solicitedServiceID);
		}


		/**
		 * Connected to the Scan button in the Unity Editor.
		 */
		public void Scan()
		{
			updateLog("Applicaton: Scanning for ble devices...");

			deviceId = null;


			bleBridge.AddAdvertisementDataListeners(this.AdvertiseLocalNameAction,
				this.AdvertiseManufactureDataAction,
				this.AdvertiseServiceDataAction,
				this.AdvertiseServiceAction,
				this.AdvertiseOverflowServiceAction,
				this.AdvertiseTxPowerLevelActionAction,
				this.AdvertiseIsConnectableAction,
				this.AdvertiseSolicitedServiceAction);

			bleBridge.ScanForPeripheralsWithServiceUUIDs(null, this.DiscoveredPeripheralAction);

		}

		/**
		 * Connected to the Connect button in the Unity Editor.
		 */
		public void Connect()
		{
			if(deviceId != null)
			{
				bleBridge.ConnectToPeripheralWithIdentifier(deviceId, this.ConnectedPeripheralAction, this.DiscoveredServiceAction, 
					this.DiscoveredCharacteristicAction, this.DiscoveredDescriptorAction, this.DisconnectedPeripheralAction);

			}
			else
			{

			}

		}

		/**
		 * Connected to the Disconnect button in the Unity Editor.
		 */
		public void Disconnect()
		{
			if(deviceId != null)
				bleBridge.DisconnectFromPeripheralWithIdentifier(deviceId, this.DisconnectedPeripheralAction);

		}

		/**
		 * Connected to the various GUI elements in the Unity Editor
		 */ 
		public void onValueChanged()
		{

		}

		private string deviceId;

		private bool isConnected = false;

		private IBleBridge bleBridge;

		private void updateLog(string newline)
		{
			if(logText != null)
			{
				logText.text += newline + "\n\n";
				if(scrollRect != null)
				{
					if(logText.preferredHeight > scrollRect.gameObject.GetComponent<RectTransform>().rect.height)
					{
						logText.gameObject.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
						scrollRect.verticalNormalizedPosition = 0;
					}

				}
			}

		}

		/**
		 * Called when the Bluetooth adapter changes states, such as enabled by the user after the app has started.
		 */
		private void StateUpdateAction(string state)
		{
			updateLog("Adapter: State Update = " + state);
		}

		/**
		 * Called when the IBleBridge.Startup() function has finished creating all the native resources and is ready to start connecting to BLE devices.
		 */
		private void StartupAction()
		{
			updateLog("Bridge: Startup");
		}

		/**
		 * Called when the IBleBridge.Shutdown() function has finished and the native resources are ready to be released. 
		 */
		private void ShutdownAction()
		{
			updateLog("Bridge: Shutdown");
		}

		/**
		 * Called when there is an error on the native side of the code.
		 */
		private void ErrorAction(string error)
		{
			updateLog("Error: " + error);
		}

		/**
		 * Called when a Bluetooth device / peripheral is found via the IBleBridge.ScanForPeripheralsWithServiceUUIDs().
		 */
		private void DiscoveredPeripheralAction(string peripheralId, string name)
		{
			updateLog("Bridge: Discovered Device = " + name + ", " + peripheralId);

			if (name == "GP-GSensor")
				this.deviceId = peripheralId;
			GameObject.Find ("Canvas").transform.FindChild ("Text").GetComponent<Text> ().text = "Connected";
			updateLog("Bridge: Device Id, " + deviceId);
		}

		/**
		 * Called when a Bluetooth device / peripheral is found via the IBleBridge.RetrieveListOfPeripheralsWithServiceUUIDs().  
		 * On iOS this is faster then scanning. However,there is no diffrence between RetrieveListOfPeripheralsWithServiceUUIDs() and ScanForPeripheralsWithServiceUUIDs() on Android.
		 */
		private void RetrievedConnectedPeripheralAction(string peripheralId, string name)
		{
			updateLog("Bridge: Retrieved Device = " + name + ", " + peripheralId);
		}

		/**
		 * Called when a successful connection has been established with a Bluetooth device.  This is usually do to a call to IBleBridge.ConnectToPeripheralWithIdentifier()
		 */
		private void ConnectedPeripheralAction(string peripheralId, string name)
		{
			updateLog("Bridge: Connected to Device = " + name + ", " + peripheralId);
			Debug.Log("*** " + this.deviceId);
			bleBridge.ReadRssiWithIdentifier(this.deviceId);

		}

		/**
		 * Called when a Bluetooth device has been disconnected, either from a call to IBleBridge.DisconnectFromPeripheralWithIdentifier() or the device has been shut off or gone out of range.
		 */
		private void DisconnectedPeripheralAction(string peripheralId, string name)
		{
			updateLog("Bridge: Disconnected from device = " + name + ", " + peripheralId);
			this.deviceId = null;
			this.isConnected = false;
			updateLog("Application: Blue-Rx is disconnected...");
		}

		/**
		 * Called when a Service has been discovered.  Services are automatically scanned for with a call to IBleBridge.ScanForPeripheralsWithServiceUUIDs() or IBleBridge.RetrieveListOfPeripheralsWithServiceUUIDs().
		 */
		private void DiscoveredServiceAction(string peripheralId, string service)
		{
			updateLog("Bridge: Discovered Service = " + service + ", " + peripheralId);
		}

		/**
		 * Called when a Characteristic has been discovered.  Characteristic are automatically scanned for with a call to IBleBridge.ScanForPeripheralsWithServiceUUIDs() or IBleBridge.RetrieveListOfPeripheralsWithServiceUUIDs().
		 */
		private void DiscoveredCharacteristicAction(string peripheralId, string service, string characteristic)
		{
			updateLog("Bridge: Discovered Characteristic = " + characteristic + ", " + service + ", " + peripheralId);

			//subscribe to notifications
			updateLog("Application: Subscribing to accelerometer notifications...");
			bleBridge.SubscribeToCharacteristicWithIdentifiers(peripheralId, service, characteristic,
				this.DidUpdateNotifiationStateForCharacteristicAction,
				this.DidUpdateCharacteristicValueAction, false);

		}

		/**
		 * Called when a Characterisic has been successully written to, after a call to IBleBridge.WriteCharacteristicWithIdentifiers() and withResponse it true.
		 */
		private void DidWriteCharacteristicAction(string peripheralId, string service, string characteristic)
		{
			updateLog("Bridge: Did Write Characteristic = " + characteristic + ", " + service + ", " + peripheralId);
		}

		/**
		 * Called when the notification state has changed on a Characteristic, after a call to IBleBridge.SubscribeToCharacteristicWithIdentifiers() or IBleBridge.UnSubscribeFromCharacteristicWithIdentifiers()
		 */
		private void DidUpdateNotifiationStateForCharacteristicAction(string peripheralId, string uuid)
		{
			updateLog("Bridge: Did Update Notification State = " + uuid + ", " + peripheralId);
		}

		/**
		 * Called when a Characteristic value has been updated, either in reponse to a Notification / Indication or a call to IBleBridge.ReadCharacteristicWithIdentifiers()
		 */ 
		private void DidUpdateCharacteristicValueAction(string peripheralId, string characteristic, byte[] data)
		{

		}

		/**
		 * Called when a Descriptor has been writen to either from a call to IBleBridge.SubscribeToCharacteristicWithIdentifiers() or IBleBridge.UnSubscribeFromCharacteristicWithIdentifiers() or IBleBridge.WriteDescriptorWithIdentifiers()
		 */
		private void DidWriteDescriptorAction(string peripheralId, string characteristic, string descriptor)
		{
			updateLog("Bridge: Did Write Descriptor = " + descriptor + ", " + characteristic + ", " + peripheralId);
		}

		/**
		 * Called when a Descriptor has been read after a call to IBleBridge.ReadDescriptorWithIdentifiers()
		 */ 
		private void DidReadDescriptorAction(string peripheralId, string characteristic, string descriptor,  byte[] data)
		{
			updateLog("Bridge: Did Read Descriptor = " + descriptor + ", " + characteristic + ", " + peripheralId);
		}

		/**
		 * Called when a Descriptor has been discovered.  Descriptor are automatically scanned for with a call to IBleBridge.ScanForPeripheralsWithServiceUUIDs() or IBleBridge.RetrieveListOfPeripheralsWithServiceUUIDs().
		 */
		private void DiscoveredDescriptorAction(string peripheralId, string service, string characteristic, string descriptor)
		{
			updateLog("Bridge: Discovered Descriptor = " + peripheralId + ", " + characteristic + ", " + peripheralId);
		}

		/**
		 * Called when the RSSI or Received Signal Strength Indicator and changed, either during a scan or after a call to IBleBridge.ReadRssiWithIdentifier()
		 */ 
		private void DidUpdateRssiAction(string peripheralId, string rssi)
		{
			updateLog("Bridge: RSSI Update = " + rssi + ", " + peripheralId);
		}

		//on iOS the ble stack is limited to updates every 1/50th of a second, so we use a coroutine to govern sending updates...
		IEnumerator UpdateValue()
		{

			while(true)
			{
				//send a packet every 1/25th of a second 
				yield return new WaitForSeconds(0.04f);

				if(isConnected)
				{
					bleBridge.ConnectToPeripheralWithIdentifier(this.deviceId, this.ConnectedPeripheralAction, this.DiscoveredServiceAction,
						this.DiscoveredCharacteristicAction, this.DiscoveredDescriptorAction, this.DisconnectedPeripheralAction);
				}
			}

		}

		//My Codeing (Cat )
		private void DidUpdateCharacteristicValueAction(string peripheralId, string service, string characteristic, byte[] data)
		{
			//updateLog("Bridge: Did Update Characteristic = " + characteristic + ", " + peripheralId);

			//Left Trigger (sbyte)data[6]
			if ((sbyte)data[6] == (sbyte)((byte)51)) {
				//updateLog("Left Trigger : Onclick");
				//this.GetComponent<Contorl_Example>().change_color("LT");
			}

			//Right Trigget (sbyte)data[7]
			if ((sbyte)data[7] == (sbyte)((byte)68) )
			{
				//updateLog("Right Trigger : Onclick");
				//this.GetComponent<Contorl_Example>().change_color("RT");
			}

			//Right Trigget (sbyte)data[8]
			if ((sbyte)data[8] == (sbyte)((byte)17) )
			{
				//updateLog("Right Button : Onclick");
				//this.GetComponent<Contorl_Example>().change_color("RB");
			}

			//Left Trigget (sbyte)data[9]
			if ((sbyte)data[9] == (sbyte)((byte)34))
			{
				//updateLog("Left Button : Onclick");
				//this.GetComponent<Contorl_Example>().change_color("LB");
			}

			float aX = (sbyte)data[10] / 64.0f;
			float aY = (sbyte)data[11] / 64.0f;
			float aZ = (sbyte)data[12] / 64.0f;
			//updateLog(" Y:" + aY.ToString("F3"));
//			this.GetComponent<Contorl_Example>().rotate_Object((float)aY);

		}


		/**
		 * Called when the notification state has changed on a Characteristic, after a call to IBleBridge.SubscribeToCharacteristicWithIdentifiers() or IBleBridge.UnSubscribeFromCharacteristicWithIdentifiers()
		 */
		private void DidUpdateNotifiationStateForCharacteristicAction(string peripheralId, string service, string characteristic)
		{
			updateLog("Bridge: Did Update Notification State = " + characteristic + ", " + service + ", " + peripheralId);
		}

		// Use this for initialization
		void Start () {

			if(logText != null)
				logText.text = "";

			//Determine which native IBleBridge to use based on the runtime platform; Android or iOS
			switch(Application.platform)
			{
			case RuntimePlatform.Android:
				bleBridge = new AndroidBleBridge();
				break;
			case RuntimePlatform.IPhonePlayer:
				bleBridge = new iOSBleBridge();
				break;
			default:
				bleBridge = new DummyBleBridge(); //modify this class if you want to emulate ble interaction in the editor...
				break;
			}

			//Startup the native side of the code and include our callbacks...
			bleBridge.Startup(true, this.StartupAction, this.ErrorAction, this.StateUpdateAction, this.DidUpdateRssiAction);

			//Start the packet updates...
			StartCoroutine("UpdateValue");
		}

		// Update is called once per frame
		void Update () {

		}
	}
}
