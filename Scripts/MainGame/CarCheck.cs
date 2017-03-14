using UnityEngine;
using System.Collections;

public class CarCheck : MonoBehaviour {
	public Transform[] checkpointArray;
	public static int currentCheckpoint = 0;
	public static int currentLap = 0;
	public static Vector3 startPos;
	// Use this for initialization
	void Start () {
		
		startPos = transform.position;

	}

	// Update is called once per frame
	void Update () {
	
	}
}
