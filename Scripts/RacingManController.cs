using UnityEngine;
using System.Collections;

public class RacingManController : MonoBehaviour {
	private Animator RacAnim;
	private Rigidbody CarRigid;
	public float SteerInput = 0f;
	public float SteerInputTwo = 0f;
	public float DirectionInput = 0f;
	public bool reversing = false;

	public string driverSteeringParameter;
	// Use this for initialization
	void Start () {
		RacAnim = GetComponent<Animator> ();
		//CarRigid = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Contorl_Example.BLE_aY) > .05f )
			SteerInputTwo = Mathf.Lerp (SteerInputTwo, Contorl_Example.BLE_aY, Time.deltaTime * 40f);
		else
			SteerInputTwo = Mathf.Lerp (SteerInputTwo, Contorl_Example.BLE_aY, Time.deltaTime * 40f);
		#if UNITY_EDITOR
			if (Mathf.Abs (Input.GetAxis("Horizontal")) > .05f )
				SteerInputTwo = Mathf.Lerp (SteerInputTwo, Input.GetAxis("Horizontal"), Time.deltaTime * 40f);
			else
				SteerInputTwo = Mathf.Lerp (SteerInputTwo, Input.GetAxis("Horizontal"), Time.deltaTime * 40f);
		#endif
	
		SteerInput = Mathf.Lerp(SteerInput, SteerInputTwo, Time.deltaTime * 10f);
//		DirectionInput = CarRigid.transform.InverseTransformDirection(CarRigid.velocity).z;

		if(DirectionInput <= -2f)
			reversing = true;
		else if(DirectionInput > -1f)
			reversing = false;


		if(!reversing){
			RacAnim.SetBool("driverReversingParameter", false);
		}else{
			RacAnim.SetBool("driverReversingParameter", true);
		}

		RacAnim.SetFloat("RacingSteer", SteerInput);

	}
}
