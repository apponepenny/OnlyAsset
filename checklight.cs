using UnityEngine;
using System.Collections;

public class checklight : MonoBehaviour {
	public GameObject[] light = new GameObject[2];
	// Use this for initialization
	void Start () {
		if (GameStaticData.sceneName == "1_2" || GameStaticData.sceneName == "1_4") {
			for (int i = 0; i < 2; i++) {
				light [i].SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
