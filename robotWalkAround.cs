using UnityEngine;
using System.Collections;

public class robotWalkAround : MonoBehaviour {
	public Vector3 pt1;
	public Transform pt2;
	public bool tL;
	public bool tR;
	public bool R;
	public float rrr;
	public Vector3 pt22;

	// Use this for initialization
	void Start () {
		tL = true;
		tR = false;
		R = true;
		pt1 = this.transform.position;
		pt22 = pt2.position;

	}


	// Update is called once per frame
	void Update () {

		rrr += Time.deltaTime;
	
			if (R) {
				transform.position = Vector3.MoveTowards (transform.position, pt22, Time.deltaTime * 3);
				if (transform.position == pt22) {
					transform.localRotation = Quaternion.Euler (transform.localRotation.x, transform.localEulerAngles.y - 180, transform.localRotation.z);
					R = !R;

				}
			} else {
				transform.position = Vector3.MoveTowards (transform.position, pt1, Time.deltaTime * 3);
				if (transform.position == pt1) {
					transform.localRotation = Quaternion.Euler (transform.localRotation.x,transform.localEulerAngles.y - 180, transform.localRotation.z);

					R = !R;
				}
			}

		

	}
}
