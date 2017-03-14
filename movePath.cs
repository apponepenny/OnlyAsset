using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movePath : MonoBehaviour {

	public enum Moveing
	{
		POINT1,
		POINT2,
		POINT3,
		POINT4
	}
	public Moveing robotMove;
	public string moveType;
	public List<Vector3> movelist = new List<Vector3> ();
	public List<Vector3> movelist2 = new List<Vector3>();
	// Use this for initialization
	void Awake () {
		robotMove = Moveing.POINT1;
		movelist.Add(new Vector3 ((this.transform.position.x) + 20, this.transform.position.y, this.transform.position.z));
		movelist.Add(new Vector3 ((this.transform.position.x) + 20, this.transform.position.y, (this.transform.position.z)+20));
		movelist.Add(new Vector3 ((this.transform.position.x), this.transform.position.y, (this.transform.position.z)+20));
		movelist.Add(this.transform.position);

			
	}
	
	// Update is called once per frame
	void Update () {
		if (moveType == "loop") {
			switch (robotMove) {
			case(Moveing.POINT1):
				this.transform.position = Vector3.MoveTowards (this.transform.position, movelist [0], Time.deltaTime * 3);
				if (this.transform.position == movelist [0]) {
					transform.Rotate (0, -Time.deltaTime * 100, 0);
					if (transform.localRotation.eulerAngles.y <= 180) {
						transform.localRotation = Quaternion.Euler (0,180,0);

						robotMove = Moveing.POINT2;
					}
				}
				Debug.Log (movelist [0]);
				break;
			case(Moveing.POINT2):
			
				this.transform.position = Vector3.MoveTowards (this.transform.position, movelist [1], Time.deltaTime * 3);
				if (this.transform.position == movelist [1]) {

					transform.Rotate (0, -Time.deltaTime * 100, 0);
					if (transform.localRotation.eulerAngles.y <= 90) {
						transform.localRotation = Quaternion.Euler (0,90,0);

						robotMove = Moveing.POINT3;

					}
				}
				Debug.Log ("test2");

				break;
			case(Moveing.POINT3):
			
				this.transform.position = Vector3.MoveTowards (this.transform.position, movelist [2], Time.deltaTime * 3);
				if (this.transform.position == movelist [2]) {
					transform.Rotate (0, -Time.deltaTime * 100, 0);
					if (transform.localRotation.eulerAngles.y <= 360 && transform.localRotation.eulerAngles.y >= 300) {
						transform.localRotation = Quaternion.Euler (0,360,0);

						robotMove = Moveing.POINT4;
					

					}
				}
				Debug.Log ("test3");

				break;
			case(Moveing.POINT4):
			
				this.transform.position = Vector3.MoveTowards (this.transform.position, movelist [3], Time.deltaTime * 3);
				if (this.transform.position == movelist [3]) {
					transform.Rotate (0, -Time.deltaTime * 100, 0);
					if (transform.localRotation.eulerAngles.y <= 270) {
						transform.localRotation = Quaternion.Euler (0, 270, 0);

						robotMove = Moveing.POINT1;
					}
				}
				Debug.Log ("test4");

				break;

			}
		} else if (moveType == "simple") 
		{
			switch (robotMove) {
			case(Moveing.POINT1):
				break;
				

			}
		}
	}
}
