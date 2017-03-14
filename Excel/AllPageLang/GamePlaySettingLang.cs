using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlaySettingLang : MonoBehaviour {
	public Text Title;
	public Text Resume;
	public Text Restart;
	public Text exit;
	public Text ControlPause;
	public Text ControlRest;
	public Text ControlBrake;
	public Text ControlChangeView;
	public Text ControlGas;
	public Text ControlHold;

	// Use this for initialization
	void Start () {
		Title.text = MutliLang.LangString[68];
		Resume.text = MutliLang.LangString[65];
		Restart.text = MutliLang.LangString[66];
		exit.text = MutliLang.LangString[67];
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
