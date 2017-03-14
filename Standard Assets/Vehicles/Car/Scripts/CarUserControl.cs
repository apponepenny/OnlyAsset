//using System;
//using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
//
//namespace UnityStandardAssets.Vehicles.Car
//{
//    [RequireComponent(typeof (CarController))]
//    public class CarUserControl : MonoBehaviour
//    {
//        private CarController m_Car; // the car controller we want to use
//
//
//        private void Awake()
//        {
//            // get the car controller
//            m_Car = GetComponent<CarController>();
//        }
//
//
//        private void FixedUpdate()
//        {
//            // pass the input to the car!
//            float h = CrossPlatformInputManager.GetAxis("Horizontal");
//            float v = CrossPlatformInputManager.GetAxis("Vertical");
//			if (Input.GetKey (KeyCode.Z)) {
//				m_Car.m_Topspeed = 250;	
//				m_Car.speed += Time.deltaTime;
//
//			}
//
//#if !MOBILE_INPUT
//            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
////			float s = CrossPlatformInputManager.GetAxis("Fire1");
//			m_Car.Move(h, v, v, handbrake);
//
//
//#else
//            m_Car.Move(h, v, v, 0f);
//#endif
//        }
//    }
//}

using System;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


namespace UnityStandardAssets.Vehicles.Car
{
	

	[RequireComponent(typeof (CarController))]


	public class CarUserControl : MonoBehaviour
	{
		bool isStart;

		private CarController m_Car; // the car controller we want to use
		public float add_speed = 0;
		public bool IsRespawn = false;
		public float cooldownRespawn;
		public Transform target;
		float distance;
		public bool IsAddSpeed;
		public Image boost;
		public float h;
		public float handbrake;


	

		private void Awake()
		{
			
			// get the car controller
			m_Car = GetComponent<CarController>();
		
		}

		void Start(){
			target = this.transform.FindChild ("Helpers").FindChild ("WaypointTargetObject");
			IsAddSpeed = false;
			isStart = false;

		}

	
		void Update(){
			



		


		}


		private void FixedUpdate()
		{
			// pass the input to the car!
			//float h = Input.GetAxis("Horizontal");

		//	float v = Input.GetAxis("Vertical");s


		
		

//			if (Input.GetKeyDown (KeyCode.Z)) 
//			{
//				m_Car.m_Topspeed = 150;	
//				add_speed = 5f;
//			}
//			else if(Input.GetKeyUp (KeyCode.Z))
//			{
//				add_speed = 0;
//			}


			//float handbrake = CrossPlatformInputManager.GetAxis("Jump");


			if (m_Car.CurrentSpeed > 80) {
				h *= 0.5f;
			} else if (m_Car.CurrentSpeed > 70) {
				h *= 0.6f;
			} else if (m_Car.CurrentSpeed > 60) {
				h *= 0.7f;
			} else if (m_Car.CurrentSpeed > 50) {
				h *= 0.8f;
			} 

			#if !MOBILE_INPUT
			//float s = CrossPlatformInputManager.GetAxis("Fire1");
//			m_Car.Move(h, v, v, handbrake,add_speed);
			if(isStart){
				

			}

			#else
		float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, 1, 1, handbrake,add_speed);

//			float s = CrossPlatformInputManager.GetAxis("Fire1");
			//m_Car.Move(h, v, v,handbrake,add_speed);
			#endif
		}
	}
}

