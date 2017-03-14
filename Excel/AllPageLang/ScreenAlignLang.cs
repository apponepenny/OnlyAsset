using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ScreenAlignLang : MonoBehaviour {
	public Text _text;
	// Use this for initialization
	void Start () {
		_text.text = MutliLang.LangString[12];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
