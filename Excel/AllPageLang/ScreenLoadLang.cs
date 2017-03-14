using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ScreenLoadLang : MonoBehaviour {


	public Text ControlPause;
	public Text ControlRest;
	public Text ControlBrake;
	public Text ControlChangeView;
	public Text ControlGas;
	public Text ControlHold;
	// Use this for initialization
	void Start () {

		ControlPause.text = MutliLang.LangString[52];
		ControlRest.text = MutliLang.LangString[53];
		ControlBrake.text = MutliLang.LangString[55];
		ControlChangeView.text = MutliLang.LangString[54];
		ControlGas.text = MutliLang.LangString[56];
		ControlHold.text = MutliLang.LangString[57];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
