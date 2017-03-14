using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LaunchScreen : MonoBehaviour {
	bool Del = false;
	// Use this for initialization
	void Start () {
		StartCoroutine (Launch());
	}
	IEnumerator Launch(){
		yield return new WaitForSeconds (3);
		Del = true;


	}
	// Update is called once per frame
	void Update () {
		if (Del) {
			this.GetComponent<Image> ().color = new Color (1,1,1,Mathf.Lerp(this.GetComponent<Image> ().color.a,0,Time.deltaTime*10));
			if(this.GetComponent<Image> ().color.a<=2)
				Destroy (this.gameObject);

		}
	}
}
