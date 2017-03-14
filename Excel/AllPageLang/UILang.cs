using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class UILang : MonoBehaviour {
	public Text position;
	public Text Time;



	// Use this for initialization
	void Start () {
		position.text = MutliLang.LangString [37];
		Time.text = MutliLang.LangString [38];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
