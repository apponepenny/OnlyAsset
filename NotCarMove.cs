using UnityEngine;
using System.Collections;

public class NotCarMove : MonoBehaviour {
		public WheelCollider[] wheel = new WheelCollider[4];
	public float Torque ;
		public float HighSpeed = 100;
	public Rigidbody rigid;
	public double Nowspeed;
		void Start(){
		rigid = GetComponent<Rigidbody> ();
		rigid.centerOfMass = new Vector3(0,-0.9f,0);
		Torque = 1;
		}

		void FixedUpdate(){
		
		//wheel[0].motorTorque = maxTorque * Input.GetAxis("Vertical");
		//wheel[1].motorTorque = maxTorque * Input.GetAxis("Vertical");

		//wheel[2].steerAngle = 10 * Input.GetAxis("Horizontal");
		//wheel[3].steerAngle = 10 * Input.GetAxis("Horizontal");

		for (int i = 0; i < 4; i++) {
			wheel[i].motorTorque = Torque * Input.GetAxis("Vertical");

		}
		Nowspeed = rigid.velocity.magnitude*3.6;
		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.05f)
			transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal")*7,0)*Time.deltaTime*10);
		if( Input.GetAxis("Vertical") > 0)
			rigid.AddForce (transform.forward * 5 , ForceMode.Acceleration);
		
		/*
	
		
			if (Contorl_Example.BLE_aY > 0.2f ) {
				transform.Rotate (new Vector3 (0, (Contorl_Example.BLE_aY- 0.2f) * 10f  , 0) * Time.deltaTime * 10);
			}else if (Contorl_Example.BLE_aY < -0.2f ) {
				transform.Rotate (new Vector3 (0, (Contorl_Example.BLE_aY+ 0.2f) * 10f   , 0) * Time.deltaTime * 10);
			}
			
*/

		}

}