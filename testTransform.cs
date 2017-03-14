using UnityEngine;
using System.Collections;

public class testTransform : MonoBehaviour {
	public Transform cam;
	public Vector3 cameraRelative;
	// Use this for initialization
	void Start () {
		cam = this.transform.parent.parent;


	}
	
	// Update is called once per frame
	void Update () {

		cameraRelative = cam.InverseTransformPoint(transform.position);

		if (cameraRelative.x > 0)
			print("Left");
		else
			print("Right");
	}
}
