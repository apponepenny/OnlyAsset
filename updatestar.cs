using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class updatestar : MonoBehaviour {
	int num;
	public Text Star;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.FindChild("Text").GetComponent<Text> ().text != "") {
			num = int.Parse (this.transform.FindChild("Text").GetComponent<Text> ().text);
			PlayerPrefs.SetInt ("HaveStar", num);
			Star.text = num.ToString ();

		}
	}
}
