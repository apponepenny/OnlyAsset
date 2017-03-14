using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
public class Storag : MonoBehaviour {


	public int part = 5;
	public int nexttouse = 0;
	public float halfheight = 1.000f;

	public GameObject playercar ;
	public player_position playercarscript;

	public GameObject enemycar;
	public Computer_Script enemycarscript ;

	public Computer_Script[] allcomputercars ;
	public bool allcomputercars_ElementsExpand  = true;
	public int allcomputercars_ElementsSize  = 1;

	public GameObject lapsystemobject;
	public lap lapscript;
	public int menucamefrom = 0;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

}
}