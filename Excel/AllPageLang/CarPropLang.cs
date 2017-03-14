using UnityEngine;
using System.Collections;

public class CarPropLang : MonoBehaviour {
	public TextMesh Speed;
	public TextMesh Accel;

	// Use this for initialization
	void Start () {
		Speed.text = MutliLang.LangString[18];
		Accel.text = MutliLang.LangString[19];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
