using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class makeMapObject : MonoBehaviour {
	public Image image;
	public Image PlayerImage;
	public int identity;
	public MiniMapController MiniControl;


	// Use this for initialization
	void Start () {

		MiniControl = GameObject.Find ("MiniCanvas").transform.GetChild (0).GetComponent<MiniMapController>();
	

		if (this.transform.parent.name == "1") {
			image = PlayerImage;
		}

		MiniControl.RegisterMapObject (this.gameObject,image);



	}

	void OnDestroy(){
		MiniControl.RemoveMapObject (this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
