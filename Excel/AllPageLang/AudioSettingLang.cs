using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class AudioSettingLang : MonoBehaviour {
	public TextMesh	SettingTitle;
	public TextMesh	SoundEffect;
	public TextMesh	Music;
	public TextMesh	VR;
	public TextMesh	On;
	public TextMesh	Off;

	// Use this for initialization
	void Start () {
		SettingTitle.text = MutliLang.LangString[15];
		SoundEffect.text = MutliLang.LangString[20];
		Music.text = MutliLang.LangString[21];
		VR.text = MutliLang.LangString[8];
		On.text = MutliLang.LangString[22];
		Off.text = MutliLang.LangString[23];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
