using UnityEngine;
using System.Collections;

public class CarProperty : MonoBehaviour {

	public class CarPro
	{
		public int id;
		public float TopSpeed;
		public float Acceleration;
		public bool IsLock;


		public CarPro(int _id, float _TopSpeed, float _Acceleration,bool _IsLock)
		{
			id = _id;
			TopSpeed = _TopSpeed;
			Acceleration = _Acceleration;
			IsLock = _IsLock;

		}
	}









}
