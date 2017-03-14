using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;
namespace UnityStandardAssets.Vehicles.Car
{
public class Computer_Script : MonoBehaviour {



	public bool hasbeenaddedtofinishingposition = false;

	//gui
	public bool textureEnabled = true;
	public GameObject objecttochangetexture;
	public bool ElementsExpand  = true;

	public Material[] positionTextures ;


	//race position stuff
	public int raceposition = 0;
	public GameObject playercar;
	public bool othercomputercars_ElementsExpand  = true;
	public int othercomputercars_ElementsSize = 1;
	public Computer_Script[] othercomputercars  ;




	//detector stuff
	public int positionn = 0;
	public float positionpercenage = 0.0f;
	int lastposition = 0;
	//GameObject[] positionobjectarray;
	List<GameObject> positionobjectarray = new List<GameObject>();

	GameObject closest;
	position_sen script;
	public int currentlap = 1;
	public int numbergoneback = 0;
	public int numberofpositions = 0;
	public player_position playerscript;
	public GameStaticData gameStaticData;
		public Transform storg;
		public gameManagerBehaviour gameManger;
		Ray L_Ray;
		Ray R_Ray;

		RaycastHit HitObjRight;
		RaycastHit HitObjLeft;

	// Use this for initialization
	void Start () {

			gameManger = GameObject.Find ("gameManager").GetComponent<gameManagerBehaviour> ();
			gameStaticData = GameObject.Find ("LoadBLE").GetComponent<GameStaticData> ();
			storg = gameManger.Storag.transform;
			/*
		Object[] bob= GameObject.FindObjectsOfType(typeof (GameObject));
		foreach(GameObject tom in bob) {
			if (tom.gameObject.name == "PositionSensor") {



				//GameObject[] santa= new GameObject[0];
				List<GameObject> santa = new List<GameObject>();
				santa = positionobjectarray;
				//positionobjectarray = new li[(santa.Count + 1)];
				int  rudolf= 0;
				foreach(GameObject obj in santa) {
					//positionobjectarray[rudolf] = santa[rudolf];
					//rudolf = rudolf + 1;
					//positionobjectarray.Add()

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


		numberofpositions = GameObject.Find ("Map").transform.FindChild("Storage").transform.childCount - 1;
		playerscript = playercar.gameObject.GetComponent<player_position> ();
			L_Ray = new Ray(transform.FindChild("ray").position,-transform.FindChild("ray").right);
			Ray R_Ray = new Ray (transform.FindChild("ray").position,transform.FindChild("ray").right);

	}

	// Update is called once per frame
	void Update () {
	//	GameObject.Find("GvrMain").transform.GetChild(0).GetChild(0).FindChild("UI").FindChild("saveRank").GetChild(int.Parse(this.transform.parent.name)-1).GetComponent<TextMesh>().text = (raceposition+1)+"";


	
		if (GameStaticData.isStart && GameStaticData.checkPos) {
			//raceposition stuff
			raceposition = 0;
			if (othercomputercars.Length > 0) {
				foreach (Computer_Script scripts in othercomputercars) {
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
			}

			if ((playerscript.currentlap - playerscript.numbergoneback) > (currentlap - numbergoneback)) {
				raceposition = raceposition + 1;
			} else {
				if ((playerscript.currentlap - playerscript.numbergoneback) == (currentlap - numbergoneback)) {
					if (playerscript.positionn > positionn) {
						raceposition = raceposition + 1;
					} else {
						if (playerscript.positionn == positionn) {
							if (playerscript.positionpercenage > positionpercenage) {
								raceposition = raceposition + 1;
							}
						}
					}
				}
			}
			/*
			if (textureEnabled == false) {
				objecttochangetexture.gameObject.GetComponent<Renderer> ().enabled = false;
			} else {
				objecttochangetexture.gameObject.GetComponent<Renderer> ().enabled = true;
				objecttochangetexture.gameObject.GetComponent<Renderer> ().material = positionTextures [raceposition];
			}
*/
			if (closest == null) {
			} else {
				lastposition = positionn;
				script = closest.gameObject.GetComponent<position_sen> ();
				positionn = script.positionnumber;
				if ((lastposition == numberofpositions) && (positionn == 0)) {
					if (numbergoneback > 0) {
						numbergoneback = numbergoneback - 1;
					} else {
						currentlap = currentlap + 1;
					}
				}
				if ((lastposition == 0) && (positionn == numberofpositions)) {
					//	numbergoneback = numbergoneback + 1;
				}
			}

			float nearestDistanceSqr = Mathf.Infinity;

			foreach (GameObject obj in positionobjectarray) {
				Vector3 objectPos = obj.transform.position;       
				float distanceSqr = (objectPos - transform.position).sqrMagnitude;         
				if (distanceSqr < nearestDistanceSqr) {           
					closest = obj.gameObject;
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
			//find closest between behind objects
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
