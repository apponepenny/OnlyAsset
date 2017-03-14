using UnityEngine;
using System.Collections;

public class destoryMeshCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameStaticData.isStart) {
			GetComponent<MeshCollider> ().enabled = false;
			GetComponent<destoryMeshCol> ().enabled = false;
		}
	}
}
