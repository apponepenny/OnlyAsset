using UnityEngine;
using System.Collections;

public class speedShake : MonoBehaviour {
	public static speedShake Instance;

	private float _amplitude = 0.1f;
	private Vector3 initialPosition;
	private bool isShaking = false;

	void Start()
	{
		Instance = this;
		initialPosition = transform.position;
	}

	public void Shake(float amplitude, float duration)
	{
		_amplitude = amplitude;
		isShaking = true;
		CancelInvoke ();
		Invoke ("StopShaking", duration);
	}
	public void StopShaking()
	{
		isShaking = false;
	}

	void Update()
	{
		if (isShaking) {
			transform.localPosition = new Vector3 (transform.localPosition.x , initialPosition.y + Random.insideUnitSphere.y * _amplitude , initialPosition.z + Random.insideUnitSphere.z * _amplitude);

		}
	}
}


