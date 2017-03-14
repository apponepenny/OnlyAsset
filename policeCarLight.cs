using UnityEngine;
using System.Collections;

public class policeCarLight : MonoBehaviour {
	public Light pl1;
	public Light pl2;
	bool checkpl1 = true;
	bool checkpl2 = false;

	// Use this for initialization
	void Start () {
		pl1 = transform.GetChild (0).GetComponent<Light> ();
		pl2 = transform.GetChild (1).GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (checkpl1) {
			pl1.intensity -= Time.deltaTime*3;
			if (pl1.intensity <= 0) {
				checkpl1 = false;
			}
		} else {
			pl1.intensity += Time.deltaTime*3;
			if (pl1.intensity >= 2) {
				checkpl1 = true;
			}
		}

		if (checkpl2) {
			pl2.intensity -= Time.deltaTime*3;
			if (pl2.intensity <= 0) {
				checkpl2 = false;
			}
		} else {
			pl2.intensity += Time.deltaTime*3;
			if (pl2.intensity >= 2) {
				checkpl2 = true;
			}
		}
	}

}
