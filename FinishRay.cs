using UnityEngine;
using System.Collections;

public class FinishRay : MonoBehaviour {
	public GameStaticData gameStaticData;
	public LineRenderer line;
	// Use this for initialization
	void Start () {
		if(GameObject.Find ("LoadBLE"))
		gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();
		#if UNITY_EDITOR
		this.gameObject.AddComponent<LineRenderer> ();
		line = GetComponent<LineRenderer>();
		#endif
	}
	
	// Update is called once per frame
	void Update () {

		Ray Ray = new Ray(transform.position,transform.right);
	
		RaycastHit HitObjRight;
		RaycastHit HitObjLeft;

		Vector3 forward = transform.TransformDirection(transform.right) * 10;
		Debug.DrawRay(transform.position, forward, Color.green);
		if (Physics.Raycast (Ray, out HitObjLeft,100)) {
			//				line.SetPosition (1, hit.point);
			if (HitObjLeft.transform.CompareTag ("Car")) {
				gameStaticData.CheckPosD ();
//				print ("@@@@@@@@@@@@@@@@@@@");
			}



		}
		#if UNITY_EDITOR

		//line.SetPosition (0, this.transform.position);
		//line.SetPosition (1, Ray.GetPoint (100));
		#endif

	}
}
