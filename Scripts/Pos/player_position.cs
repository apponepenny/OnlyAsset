using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UnityStandardAssets.Vehicles.Car
{
public class player_position : MonoBehaviour {
	public bool showgui = true;
	public bool ElementsExpend = true;
	 int ElementsSize = 1;
	public int raceposition = 0;
	public int position_x = 0;
	public int position_y = 0;
	public int position_width = 0;
	public int position_height = 0;
	public Texture[] PosTextures;

	public bool computercars_ElementsExpand = true;
	 int computercars_ElementsSize = 1;
	public Computer_Script[] computercars ;

	public int positionn = 0;
	int lastposition = 0;
	//GameObject[] positionobjectarray;
	public List<GameObject> positionobjectarray = new List<GameObject>();

	GameObject closest;
	position_sen script;
	public int currentlap = 1;
	public int numbergoneback = 0;
	public int numberofpositions= 0;
	public float positionpercenage = 0.0f;
	int asd = 0;
	public Transform LabTime;
	public UIControl UI;
	public Text UIRaceText;
	public GameStaticData gameStaticData;
		public Transform storg;
		public gameManagerBehaviour gameManger;



	// Use this for initialization
	void Start () {
		/*	positionobjectarray = new GameObject[999];
		//object[] bob= GameObject.FindObjectsOfType(typeof (GameObject)) ;


		for (int i = 0; i < GameObject.Find ("Storage").transform.childCount; i++) {
			for (int j = 0; j < GameObject.Find ("Storage").transform.GetChild (i).childCount; j++) {
				
				positionobjectarray [asd] = GameObject.Find ("Storage").transform.GetChild (i).GetChild(j).gameObject;

					
				asd++;
			}
		
		}
		*/
			gameManger = GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ();
		gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();
			storg = gameManger.Storag.transform;
	/*
GameObject[] bob= GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		foreach(GameObject tom in bob){
			if (tom.gameObject.name == "PositionSensor") {

			

				//GameObject[] santa= new GameObject[0];
				List<GameObject> santa = new List<GameObject>();
				santa = positionobjectarray;
				//positionobjectarray = new li[(santa.Count + 1)];
				int  rudolf= 0;
				foreach(GameObject obj in santa) {
					positionobjectarray[rudolf] = santa[rudolf];
					rudolf = rudolf + 1;


				}
				//positionobjectarray[(positionobjectarray.Count-1)] = tom.gameObject;
				positionobjectarray.Add(tom.gameObject);
			
			}
		}
		*/

			for (int i = 0; i < storg.childCount; i++) {
				for (int j = 0; j<storg.GetChild (i).childCount; j++) {
					positionobjectarray.Add (storg.GetChild (i).GetChild(j).gameObject);
				}
			}


			LabTime = GameObject.FindWithTag("VRCam").transform.FindChild ("Head").FindChild ("Main Camera").FindChild ("UI").FindChild ("Speed").FindChild ("Canvas").FindChild ("LapTime");
			UI = GameObject.FindWithTag("VRCam").transform.FindChild ("Head").FindChild ("Main Camera").FindChild ("UI").GetComponent<UIControl> ();
		numberofpositions = GameObject.Find ("Map").transform.FindChild("Storage").transform.childCount - 1;

			UIRaceText = GameObject.FindWithTag("VRCam").transform.GetChild (0).GetChild (0).FindChild ("UI").FindChild ("Speed").FindChild ("Canvas").FindChild ("ranking").GetChild (0).GetComponent<Text> ();


		}

	IEnumerator LapEffect(int a){
		LabTime.GetChild (a).gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (true);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (true);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (true);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		LabTime.GetChild (a).gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	//	GameObject.Find("GvrMain").transform.GetChild(0).GetChild(0).FindChild("UI").FindChild("saveRank").GetChild(0).GetComponent<TextMesh>().text = (raceposition+1)+"";
			Ray L_Ray;
			Ray R_Ray;


			L_Ray = new Ray(transform.FindChild("ray").position,-transform.FindChild("ray").right);
			R_Ray = new Ray (transform.FindChild("ray").position,transform.FindChild("ray").right);

			RaycastHit HitObjRight;
			RaycastHit HitObjLeft;


				if (Physics.Raycast (L_Ray, out HitObjLeft, 200)) {
		
					if (HitObjLeft.transform.CompareTag ("Car")) {

						gameStaticData.CheckPosD ();
			
					print ("Left");
					}
				}

				if (Physics.Raycast (R_Ray, out HitObjRight, 200)) {

			
					if (HitObjRight.transform.CompareTag ("Car")) {
						gameStaticData.CheckPosD ();
					print ("Right");


					}
				}
			


//		print ("raceposition : " + raceposition);
		UIRaceText.text = (raceposition+1)+"/4";
		if (GameStaticData.isStart && GameStaticData.checkPos) {
			raceposition = 0;
			foreach (Computer_Script scripts in computercars) {
				if ((scripts.currentlap - scripts.numbergoneback) > (currentlap - numbergoneback)) {
					raceposition = raceposition + 1;
				} else {
					if ((scripts.currentlap - scripts.numbergoneback) == (currentlap - numbergoneback)) {
						if (scripts.positionn > positionn) {
							raceposition = raceposition + 1;
						} else {
							if (scripts.positionn == positionn) {
								if (scripts.positionpercenage > positionpercenage) {
									raceposition = raceposition + 1;
								}
							}
						}
					}
				}
			}


			if (closest == null) {
			} else {
			
				lastposition = positionn;
				script = closest.gameObject.GetComponent<position_sen> ();
				positionn = script.positionnumber;
				if ((lastposition == numberofpositions) && (positionn == 0)) {
					if (numbergoneback > 0) {
						numbergoneback = numbergoneback - 1;
					} else {
						LabTime.GetChild (currentlap - 1).GetChild (0).GetComponent<Text> ().text = UI.mm.ToString ("00") + ":" + UI.ss.ToString ("00") + ":" + UI.ms.ToString ("00");
						StartCoroutine (LapEffect (currentlap - 1));
						currentlap = currentlap + 1;
						GameStaticData.currentLap = currentlap;
							print ("current : "+currentlap);
							print ("GameStatic . current : "+GameStaticData.currentLap);
							gameManger.Lap.text = "Lap : "+ GameStaticData.currentLap +" / " + gameManger.PlayLap.ToString ();
				
					}
				}
				if ((lastposition == 0) && (positionn == numberofpositions)) {
					numbergoneback = numbergoneback + 1;
				}
			}


			float nearestDistanceSqr = Mathf.Infinity;

			/*
		foreach(GameObject obj in positionobjectarray) {
			print (obj.name);
			Vector3 objectPos= obj.transform.position;       
			float distanceSqr= (objectPos - transform.position).sqrMagnitude;         
			if (distanceSqr < nearestDistanceSqr) {           
				closest = obj.gameObject;     
				nearestDistanceSqr = distanceSqr;        
			}    
		}
		*/

			for (int i = 0; i < positionobjectarray.Count; i++) {
				Vector3 objectPos = positionobjectarray [i].transform.position;
				float distanceSqr = (objectPos - transform.position).sqrMagnitude;         
				if (distanceSqr < nearestDistanceSqr) {           
					closest = positionobjectarray [i];     
					nearestDistanceSqr = distanceSqr;        
				}    
		
			}


			position_sen closestscript = closest.gameObject.GetComponent<position_sen> ();
			int closestpositionnumber = closestscript.positionnumber;
			int infrontnumber = 0;
			int behindnumber = 0;
			if (closestpositionnumber == numberofpositions) {
				infrontnumber = 0;
				behindnumber = closestscript.positionnumber - 1;
			} else {
				if (closestpositionnumber == 0) {
					infrontnumber = 1;
					behindnumber = numberofpositions;
				} else {
					infrontnumber = closestscript.positionnumber + 1;
					behindnumber = closestscript.positionnumber - 1;
				}
			}



			GameObject closestinfrontobject = null;
			float neearestDistanceSqr = Mathf.Infinity;
			foreach (GameObject obbj in positionobjectarray) {
				int posnumberinobbj = obbj.gameObject.GetComponent<position_sen> ().positionnumber;
				if (posnumberinobbj == infrontnumber) {
					Vector3 obbjectPos = obbj.transform.position;       
					float diistanceSqr = (obbjectPos - transform.position).sqrMagnitude;         
					if (diistanceSqr < neearestDistanceSqr) {           
						closestinfrontobject = obbj.gameObject;
						neearestDistanceSqr = diistanceSqr;        
					}    
				}    
			}

			GameObject closestbehindobject = null;
			float neeearestDistanceSqr = Mathf.Infinity;
			foreach (GameObject obbbj in positionobjectarray) {
				int posnumberinobbbj = obbbj.gameObject.GetComponent<position_sen> ().positionnumber;
				if (posnumberinobbbj == behindnumber) {
					Vector3 obbbjectPos = obbbj.transform.position;       
					float diiistanceSqr = (obbbjectPos - transform.position).sqrMagnitude;         
					if (diiistanceSqr < neeearestDistanceSqr) {           
						closestbehindobject = obbbj.gameObject;
						neeearestDistanceSqr = diiistanceSqr;        
					}    
				}    
			}


			float distancebetweenposandinfront = Vector3.Distance (closestinfrontobject.transform.position, closestbehindobject.transform.position);
			float distancebetweenposandbehind = Vector3.Distance (closestbehindobject.transform.position, gameObject.transform.position);
			float distancepercentage;
			distancepercentage = distancebetweenposandbehind / distancebetweenposandinfront;
			positionpercenage = distancepercentage * 100;
	
		}
	}
}
}