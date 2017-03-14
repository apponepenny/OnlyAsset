using UnityEngine;
using System.Collections;

public class miniMapController : MonoBehaviour {
	public GUIStyle miniMap;
	public Transform player;
	public Transform[] enemy = new Transform[3];
	public GUIStyle playerIcon;
	public GUIStyle enemyIcon;
	public GUIStyle enemyIcon1;
	public GUIStyle enemyIcon2;

	public float mapOffSetX = 762;
	public float mapOffSetY = 510;
	public float mapWidth = 200;
	public float mapHeight = 200;
	public float sceneWidth = 200;
	public float sceneHeight = 200;
	public float iconSize = 10;


	public float iconHalfSize;



	// Use this for initialization
	void Start () {
	//	StartCoroutine (delaystart());
	}
	/*
	IEnumerator delaystart(){
		yield return new WaitForSeconds (0.3f);
		player = GameObject.Find ("CarStartPoint").transform.FindChild ("1").GetChild (0);
		enemy[0] = GameObject.Find ("CarStartPoint").transform.FindChild ("2").GetChild (0);
		enemy[1] = GameObject.Find ("CarStartPoint").transform.FindChild ("3").GetChild (0);
		enemy[2] = GameObject.Find ("CarStartPoint").transform.FindChild ("4").GetChild (0);

	}
	*/
	// Update is called once per frame
	void Update () {
		iconHalfSize = iconSize/2;


	}

	public float GetMapPos(float pos, float mapSize, float sceneSize){
		return pos * mapSize/sceneSize;
	}

	public void OnGUI(){
		
		GUI.BeginGroup(new Rect(mapOffSetX,mapOffSetY,mapWidth,mapHeight), miniMap);
		float pX = GetMapPos(transform.position.x, mapWidth, sceneWidth);
		float pZ = GetMapPos(transform.position.z, mapHeight, sceneHeight);
		float playerMapX = pX - iconHalfSize;
		float playerMapZ = ((pZ * -1) - iconHalfSize) + mapHeight;


		GUI.Box(new Rect(playerMapX, playerMapZ, iconSize, iconSize), "", playerIcon);
		float sX = GetMapPos(enemy[0].transform.position.x, mapWidth, sceneWidth);
		float sZ = GetMapPos(enemy[0].transform.position.z, mapHeight, sceneHeight);



		float sX1 = GetMapPos(enemy[1].transform.position.x, mapWidth, sceneWidth);
		float sZ1= GetMapPos(enemy[1].transform.position.z, mapHeight, sceneHeight);


		float sX2 = GetMapPos(enemy[2].transform.position.x, mapWidth, sceneWidth);
		float sZ2 = GetMapPos(enemy[2].transform.position.z, mapHeight, sceneHeight);

		float enemyMapX = sX - iconHalfSize;
		float enemyMapZ = ((sZ * -1) - iconHalfSize) + mapHeight;
		GUI.Box(new Rect(enemyMapX, enemyMapZ, iconSize, iconSize), "", enemyIcon);


		float enemyMapX1 = sX1 - iconHalfSize;
		float enemyMapZ1 = ((sZ1 * -1) - iconHalfSize) + mapHeight;
		GUI.Box(new Rect(enemyMapX1, enemyMapZ1, iconSize, iconSize), "", enemyIcon1);

		float enemyMapX2 = sX2 - iconHalfSize;
		float enemyMapZ2 = ((sZ2 * -1) - iconHalfSize) + mapHeight;
		GUI.Box(new Rect(enemyMapX2, enemyMapZ2, iconSize, iconSize), "", enemyIcon2);
		GUI.EndGroup();
	}
}
