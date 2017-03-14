using UnityEngine;
using System.Collections;

public class position_sen : MonoBehaviour {
	public int positionnumber;
	// Use this for initialization
	void Start () {
		//positionnumber = int.Parse(this.transform.parent.name);

	}


	
	// Update is called once per frame
	void Update () {
	
	}


	void OnDrawGizmos () {
		
		// Draw a semitransparent blue cube at the transforms position
		Gizmos.color = new Color (1,0,0,0.5f);
		Gizmos.DrawCube (new Vector3(transform.position.x,transform.position.y+0.15f,transform.position.z), new Vector3 (0.3f,0.3f,0.3f));
	}
}
