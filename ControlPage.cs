using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPage : MonoBehaviour {
	public Text Control;
	public Text PressGas;


	public GameObject ChooseYourView;
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
	// Use this for initialization
	void Start () {
		Control.text = MutliLang.LangString[50];
		PressGas.text = MutliLang.LangString[51];
	}
	
	// Update is called once per frame
	void Update () {
		reset_All_Button ();

		if ((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) {
			GameStaticData.canButton_RB = false;
			GameStaticData.ChooseView.SetActive (true);
			Destroy (this.gameObject);
		
	}
}
}
