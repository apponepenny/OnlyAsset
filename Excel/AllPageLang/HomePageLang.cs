using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HomePageLang : MonoBehaviour {
	public Dropdown SelectLang;
	public Text ConnectTosteer;
	public Text Go;
	public Text Scan;
	public Text Help;
	public Text VR;
	public Text VRgogg;
	public Text NonVR;
	public Text NonVRgogg;

	// Use this for initialization
	void Start () {
		ChangeLang ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeLang(){
		MutliLang.SelectLangNum = SelectLang.value;
		MutliLang.XLSX ();

		ConnectTosteer.text = MutliLang.LangString [3];
		Go.text = MutliLang.LangString [5];
		Scan.text = MutliLang.LangString [4];
		Help.text = MutliLang.LangString [6];
		VR.text = MutliLang.LangString [8];
		NonVR.text = MutliLang.LangString [9];
		VRgogg.text = MutliLang.LangString [10];
		NonVRgogg.text = MutliLang.LangString [11];

	}
}
