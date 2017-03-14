using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseYourViewLang : MonoBehaviour {
	public Text Title;
	public Text PRESSTOCHANGEVIEWString;
	public Text PRESSTHISWHENREADY;
	public Text HARDER;
	public Text EASIER;
	public Text View0;
	public Text View1;
	public Text View2;
	public Text View3;

	// Use this for initialization
	void Start () {
		Title.text = MutliLang.LangString[58];
		PRESSTOCHANGEVIEWString.text = MutliLang.LangString[59];
		PRESSTHISWHENREADY.text = MutliLang.LangString[60];
		//HARDER.text = MutliLang.LangString[];
		//EASIER.text = MutliLang.LangString[];
		View0.text = MutliLang.LangString[62];
		View1.text = MutliLang.LangString[63];
		View2.text = MutliLang.LangString[64];
		View3.text = MutliLang.LangString[61];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
