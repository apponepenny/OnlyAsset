using UnityEngine;
using UnityEngine.UI;

using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class checkLap : MonoBehaviour {
//	public Transform nextCheckpoint;
	public Transform checkpoint; 
		private CarCheck carChecklap;
//		public Transform[] checkPoints;
//	public int checkPointIndex;
//	public gameManagerBehaviour gameManager;
//	public int checkPointPassed;
	// Use this for initialization
		float t;
		public Transform LabTime;
		public UIControl UI;

	void Start () {
	

//			checkPointPassed = 0;
//			checkPointIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
			t += Time.deltaTime;
			if (t > 0.1f) {
				checkpoint = GameObject.Find ("CarStartPoint").transform.GetChild(0).GetChild(0).transform;
				GameStaticData.Cartranstam = checkpoint;
			}
	}

	void OnTriggerEnter(Collider other){
		if (!other.CompareTag ("Checkpoint")) {
			return;
		}
		if (transform == checkpoint.GetComponent<CarCheck> ().checkpointArray [CarCheck.currentCheckpoint].transform) {
				if (CarCheck.currentCheckpoint + 1 < checkpoint.GetComponent<CarCheck> ().checkpointArray.Length) {
					if (CarCheck.currentCheckpoint == 0) {
						print ("currentCheckpoint");
						CarCheck.currentLap++;
						if (other.transform.parent.parent.name == "1") {
							


							GameStaticData.currentLap++;

						}
					
					}
					CarCheck.currentCheckpoint++;
			} else {
					CarCheck.currentCheckpoint = 0;
			}
			

		}





//			if(other.CompareTag("Checkpoint"))
//			{
//
//				if(nextCheckpoint == other.transform)
//				{
//
//					if (checkPointIndex < checkPoints.Length - 1) {
//						checkPointIndex++;
//					} else {
//						checkPointIndex = 0;
//					}
//
//					nextCheckpoint = checkPoints [checkPointIndex];
//					checkPointPassed++;
//
//					gameManager.RankRacers();
//				}
//				else
//				{
//					Debug.Log ("off track");
//				}
//			}

	}
	}
}
