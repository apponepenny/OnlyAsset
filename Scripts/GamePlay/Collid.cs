using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class Collid : MonoBehaviour {
		bool canCol;
		float t;
		public Rigidbody PlayerRig;
		public Transform center;
	// Use this for initialization
	void Start () {
			canCol = false;

			PlayerRig = this.GetComponent<Rigidbody> ();
			PlayerRig.centerOfMass = new Vector3 (0, -0.4f, 0);
			//PlayerRig.inertiaTensor *= 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
			t += Time.deltaTime;
			if (t > 1.5f) {
				canCol = true;
			}


	
	}
	void OnCollisionEnter(Collision other){
		print ("col : "+ other);
			if(other.transform != transform)
			if (canCol) {
				if(GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ().SpeedLevel >1)
				//	GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ().SpeedLevel -= 1;
				canCol = false;
				//this.GetComponent<Rigidbody>().AddExplosionForce (-10000000, transform.position, 0.0f, 0.0f);
				StartCoroutine(DelayMotor());
				t = 0;

			}
	}


		IEnumerator DelayMotor(){
			GameStaticData.canMotor= true;
	

			yield return new WaitForSeconds (0.5f);
			GameStaticData.canMotor= false;


		}
}
}
