using UnityEngine;
using UnityEngine.UI;

using startechplus.ble;
using System.Collections;
using System.Collections.Generic;
using System;


namespace startechplus.ble.examples
{
public class ScanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
			GameObject.Find ("ButtonControl").GetComponent<HelpButton> ().startaction ();
			DontDestroyOnLoad (this);

	}
	
	// Update is called once per frame
	void Update () {

			GameObject.Find ("ButtonControl").GetComponent<HelpButton> ().Scan ();


			//	GameObject.Find ("Canvas").transform.FindChild ("check").GetComponent<Text> ().text = "Connect : "+GameObject.Find ("ButtonControl").GetComponent<HelpButton> ().isConnected.ToString();
			//GameObject.Find ("Canvas").transform.FindChild ("Text").GetComponent<Text> ().text = "aY : "+Contorl_Example.BLE_aY.ToString();
			//GameObject.Find ("Canvas").transform.FindChild ("hi").GetComponent<Text> ().text = "Move : "+GameStaticData.canButton_aY.ToString();
	
	}
	}
}
