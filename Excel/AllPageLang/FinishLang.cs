using UnityEngine;
using System.Collections;

public class FinishLang : MonoBehaviour {
	public TextMesh Title;
	public TextMesh TotalTime_Text;
	public TextMesh BestLap_Text;
	public TextMesh StarEarned_Text;
	public TextMesh No1;
	public TextMesh No2;
	public TextMesh No3;
	public TextMesh No4;
	public TextMesh ContinueText;
	public TextMesh RetryText;

	// Use this for initialization
	void Start () {
		Title.text = MutliLang.LangString[40];
		TotalTime_Text.text = MutliLang.LangString[41];
		BestLap_Text.text = MutliLang.LangString[42];
		StarEarned_Text.text = MutliLang.LangString[43];
		//No1.text = MutliLang.LangString[];
		//No2.text = MutliLang.LangString[];
		//No3.text = MutliLang.LangString[];
		//No4.text = MutliLang.LangString[];
		ContinueText.text = MutliLang.LangString[44];
		RetryText.text = MutliLang.LangString[45];


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
