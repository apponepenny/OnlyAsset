using UnityEngine;
using System.Collections;

public class displayRoad : MonoBehaviour {
	public GameObject Show;
	public GameObject Lost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.parent.name == "1") {
			if(Show != null)
				Show.SetActive (true);
			if(Show != null)
				Lost.SetActive (false);
		}
	}
}
