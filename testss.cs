using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class testss : MonoBehaviour {
	public Text b;
	public Text c;
	public Text d;
	public Text e;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		b.text = GameStaticData.b;
		c.text = GameStaticData.c;
		d.text = GameStaticData.d;


	}
}
