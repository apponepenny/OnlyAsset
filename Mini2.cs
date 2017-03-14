using UnityEngine;
using System.Collections;

public class Mini2 : MonoBehaviour {
	public Transform p1;
	public Vector3 p1Vec;
	// Use this for initialization
	void Start () {
		if (GameStaticData.isVR) {
			p1Vec = p1.transform.localPosition;
			p1Vec.x = (Screen.width / 2 + p1.transform.localPosition.x) - 10;
			this.transform.localPosition = p1Vec;
		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
}
