using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
[RequireComponent(typeof (CarController))]
public class RayDetect : MonoBehaviour {
		public bool turn;
		public float t;
		LineRenderer line;

		LineRenderer lineL;
		LineRenderer lineR;
		LineRenderer line3;
		LineRenderer line4;

		public float cooldownRespawn;
		Vector3 RL ;

		bool RayhitL;
		bool RayhitR;
		bool ishit;
		int raylenght;
	// Use this for initialization
	void Start () {

			RayhitL = false;
			RayhitR = false;
			ishit = false;
			raylenght = 35;
//			GetComponent<CarAIControl> ().NeedTurn =true;
			line = transform.GetComponent<LineRenderer>();

			lineL = transform.FindChild("ray").FindChild("rayL").GetComponent<LineRenderer>();
			lineR = transform.FindChild("ray").FindChild("rayR").GetComponent<LineRenderer>();
			line3 = transform.FindChild("ray").FindChild("ray3").GetComponent<LineRenderer>();
			line4 = transform.FindChild("ray").FindChild("ray4").GetComponent<LineRenderer>();


			RL = transform.position;
//			line.enabled = false;
//
//			lineL.enabled = false;
//			lineR.enabled = false;
//			line3.enabled = false;
//
//			line4.enabled = false;


	}

		void CheckRayHit(RaycastHit hit){
			if (hit.transform.CompareTag("crashObject")) {
				Ray HitObjectRight = new Ray (hit.transform.position, hit.transform.right);
				Ray HitObjectLeft = new Ray (hit.transform.position, -hit.transform.right);

				RaycastHit HitObjRight;
				RaycastHit HitObjLeft;

				ishit = true;
				GetComponent<CarAIControl> ().m_AvoidOtherCarSlowdown = 0.3f;
				if (Physics.Raycast (HitObjectLeft, out HitObjLeft, 10)) {
//					line3.SetPosition (0, hit.transform.position);
//					line3.SetPosition (1, HitObjectLeft.GetPoint (10));

					if (HitObjLeft.transform.CompareTag ("Wall")) {
						RayhitL = true;
					//	print ("Left");

					}

				} else {
//					line3.SetPosition (0, hit.transform.position);

//					line3.SetPosition (1, HitObjectLeft.GetPoint (10));

					RayhitL = false;
				}

				if (Physics.Raycast (HitObjectRight, out HitObjRight, 10)) {

//					line4.SetPosition (0, hit.transform.position);
//					line4.SetPosition (1, HitObjectRight.GetPoint (10));
					if (HitObjRight.transform.CompareTag ("Wall")) {
						RayhitR = true;
					//	print ("Right");


					}

				} else {
//					line4.SetPosition (0, hit.transform.position);

//					line4.SetPosition (1, HitObjectRight.GetPoint (10));


					RayhitR = false;
				}




			

			} else {
				
			
			}


		}
	IEnumerator FireLaser()
	{
//			line.enabled = true;
//
//			lineL.enabled = true;
//			lineR.enabled = true;
//			line3.enabled = true;
//			line4.enabled = true;

		//while (Input.GetButton("Fire1")) {
			Ray ray = new Ray(transform.position,transform.forward);
			Ray ray1 = new Ray(transform.FindChild("ray").FindChild("ray1").position, transform.forward);
			Ray ray2 = new Ray(transform.FindChild("ray").FindChild("ray2").position, transform.forward);
			Ray ray3 = new Ray(transform.FindChild("ray").FindChild("ray3").position, transform.FindChild("ray").FindChild("ray3").forward);
			Ray ray4 = new Ray(transform.FindChild("ray").FindChild("ray4").position, transform.FindChild("ray").FindChild("ray4").forward);




			Ray rayL = new Ray(transform.FindChild("ray").FindChild("rayL").position,transform.FindChild("ray").FindChild("rayL").forward);
			Ray rayL20 = new Ray(transform.FindChild("ray").FindChild("rayL20").position,transform.FindChild("ray").FindChild("rayL20").forward);
			Ray rayL30 = new Ray(transform.FindChild("ray").FindChild("rayL30").position,transform.FindChild("ray").FindChild("rayL30").forward);
			Ray rayL40 = new Ray(transform.FindChild("ray").FindChild("rayL40").position,transform.FindChild("ray").FindChild("rayL40").forward);

			Ray rayR = new Ray(transform.FindChild("ray").FindChild("rayR").position, transform.FindChild("ray").FindChild("rayR").forward);
			Ray rayR20 = new Ray(transform.FindChild("ray").FindChild("rayR20").position, transform.FindChild("ray").FindChild("rayR20").forward);
			Ray rayR30 = new Ray(transform.FindChild("ray").FindChild("rayR30").position, transform.FindChild("ray").FindChild("rayR30").forward);
			Ray rayR40 = new Ray(transform.FindChild("ray").FindChild("rayR40").position, transform.FindChild("ray").FindChild("rayR40").forward);


			RaycastHit hit;		
			RaycastHit hit1;
			RaycastHit hit2;
			RaycastHit hit3;
			RaycastHit hit4;
			RaycastHit hitL;
			RaycastHit hitL20;
			RaycastHit hitL30;
			RaycastHit hitL40;

			RaycastHit hitR;
			RaycastHit hitR20;
			RaycastHit hitR30;
			RaycastHit hitR40;


//			line.SetPosition (0,ray.origin);
//
//			lineL.SetPosition (0,rayL.origin);
//			lineR.SetPosition (0,rayR.origin);
//			line3.SetPosition (0,ray3.origin);
//			line4.SetPosition (0,ray4.origin);

			if (Physics.Raycast (ray, out hit, raylenght)) {
//				line.SetPosition (1, hit.point);
				if (hit.transform.CompareTag("crashObject")) {
					
					if (ishit) {
						if (RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("Turning   RRRRRRRRRRRRRRRRRRRRRRRRRRRR");
						} else if (!RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("Turning   LLLLLLLLLLLLLLLLLLLLLLLLLL");
						} else if (RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("hit 2 wall");
						} else if (!RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("no hit");
						}
					}
				
				}

				CheckRayHit (hit);
			} else {
//				line.SetPosition (1,ray.GetPoint(raylenght));
			}



//		if (Physics.Raycast(ray1, out hit1, 40))
//		{
//			
//				if (hit1.transform.tag == "crashObject") {
//					
//					GetComponent<CarAIControl> ().NeedTurn = true;
//					GetComponent<CarAIControl> ().LR = 2;
//					print ("ray1 hit");
//				} 
//		}
//		
//			if (Physics.Raycast(ray2, out hit2, 40))
//			{
//
//				if (hit2.transform.tag == "crashObject") {
//
//					GetComponent<CarAIControl> ().NeedTurn = true;
//					GetComponent<CarAIControl> ().LR = 2;
//
//					print ("ray2 hit");
//				} 
//			}

			if (Physics.Raycast(ray3, out hit3, raylenght))
			{


//				lineL.SetPosition (1, hit3.point);
				if (hit3.transform.CompareTag("crashObject")) {

					GetComponent<CarAIControl> ().NeedTurn = false;
					GetComponent<CarAIControl> ().LR = 0;
					print ("HitLeft");

				}
			}
			else {
//				lineL.SetPosition (1,ray3.GetPoint(raylenght));

			}

			if (Physics.Raycast(ray4, out hit4, raylenght))
			{

//				lineR.SetPosition (1, hit4.point);
				if (hit4.transform.CompareTag("crashObject")) {

										GetComponent<CarAIControl> ().NeedTurn = false;
										GetComponent<CarAIControl> ().LR = 0;
					print ("HItRight");
		
				}
			}  else {
//				lineR.SetPosition (1,ray4.GetPoint(raylenght));
			
			}
//
//
//
			if (Physics.Raycast (rayL, out hitL, raylenght)) {

//				lineL.SetPosition (1, hitL.point);
				if (hitL.transform.CompareTag("crashObject")) {

					if (ishit) {
						if (RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("Turning   RRRRRRRRRRRRRRRRRRRRRRRRRRRR");
						} else if (!RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("Turning   LLLLLLLLLLLLLLLLLLLLLLLLLL");
						} else if (RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("hit 2 wall");
						} else if (!RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("no hit");
						}
					}

				}
				CheckRayHit (hitL);
			} else {
//				lineL.SetPosition (1,rayL.GetPoint(raylenght));

			}

		
			if (Physics.Raycast (rayL20, out hitL20, raylenght)) {
				CheckRayHit (hitL20);
			}
			if (Physics.Raycast (rayL30, out hitL30, raylenght)) {
				CheckRayHit (hitL30);
			}
			if (Physics.Raycast (rayL40, out hitL40, raylenght)) {
				CheckRayHit (hitL40);
			}
		


			if (Physics.Raycast (rayR, out hitR, raylenght)) {

//				lineR.SetPosition (1, hitR.point);
				if (hitR.transform.CompareTag("crashObject")) {

					if (ishit) {
						if (RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("Turning   RRRRRRRRRRRRRRRRRRRRRRRRRRRR");
						} else if (!RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("Turning   LLLLLLLLLLLLLLLLLLLLLLLLLL");
						} else if (RayhitL && RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 2;
							print ("hit 2 wall");
						} else if (!RayhitL && !RayhitR) {
							GetComponent<CarAIControl> ().NeedTurn = true;
							GetComponent<CarAIControl> ().LR = 1;
							print ("no hit");
						}
					}

				}
				CheckRayHit (hitR);
			} else {
//				lineR.SetPosition (1,rayR.GetPoint(raylenght));

			}

			if (Physics.Raycast (rayR20, out hitR20, raylenght)) {
				CheckRayHit (hitR20);
			}
			if (Physics.Raycast (rayR30, out hitR30, raylenght)) {
				CheckRayHit (hitR30);
			}
			if (Physics.Raycast (rayR40, out hitR40, raylenght)) {
				CheckRayHit (hitR40);
			}

	
		yield return null;
//			lineL.enabled = false;
//			lineR.enabled = false;
//			line3.enabled = false;
//			line4.enabled = false;

	}

	void LaserAim() {
		StopCoroutine("FireLaser");
		StartCoroutine("FireLaser");
	}
		/*
		IEnumerator respawnDelay(){
			float temptopspeed = this.GetComponent<CarController> ().m_Topspeed;
			this.transform.FindChild ("Colliders").gameObject.SetActive(false);
			this.GetComponent<CarController> ().m_Topspeed = 0;
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive(false);
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive (true);
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive(false);
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive(true);
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive(false);
			yield return new WaitForSeconds(0.25f);
			this.transform.FindChild ("Colliders").gameObject.SetActive(true);
			this.transform.FindChild ("Colliders").gameObject.SetActive(true);
			this.GetComponent<CarController> ().m_Topspeed = temptopspeed;
		}
*/
	// Update is called once per frame
	void Update () {
			
		LaserAim();
			if (GetComponent<CarAIControl> ().NeedTurn) {
//				GetComponent<CarController> ().Move (-1, 0, -1f, 1f, 0);
//				GetComponent<CarAIControl> ().addturn = 100;
				float turntime = 1.2f;
			
				t += Time.deltaTime;
				if (t >= turntime) {
//					GetComponent<CarAIControl> ().NeedTurn = false;
//					GetComponent<CarAIControl> ().LR = 0;
//					t = 0;
//					ishit = false;
				}
			} else {

			
			}
	}
}
}
