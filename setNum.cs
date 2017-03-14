using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class setNum : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		
		if (((Contorl_Example.BLE_LB && GameStaticData.canButton_LB) && (Contorl_Example.BLE_RB && GameStaticData.canButton_RB)) || Input.GetKeyDown (KeyCode.B)) {
			GameStaticData.canButton_LB = false;
			GameStaticData.canButton_RB = false;
			Time.timeScale = 0;

			this.transform.FindChild ("Set").gameObject.SetActive (true);
		}

	}
}
