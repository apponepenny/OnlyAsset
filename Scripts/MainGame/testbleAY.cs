using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class testbleAY : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.FindChild("x").GetComponent<Text>().text = "x : "+Contorl_Example.BLE_aX.ToString ();
		this.transform.FindChild("y").GetComponent<Text>().text = "y : "+Contorl_Example.BLE_aY.ToString ();
		this.transform.FindChild("z").GetComponent<Text>().text = "z : "+Contorl_Example.BLE_aX.ToString ();

	}
}
