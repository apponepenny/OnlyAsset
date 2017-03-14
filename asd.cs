using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class asd : MonoBehaviour {
	public RCCCarControllerV2 Player;

	// Use this for initialization
	void Start () {

		Player = GameObject.Find ("CarStartPoint").transform.GetChild (0).GetChild (0).GetComponent<RCCCarControllerV2>();
		this.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min1 + ")";
		this.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max1 + ")";
		this.transform.GetChild (0).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an1 + ")";
		this.transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min2 + ")";
		this.transform.GetChild (1).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max2 + ")";
		this.transform.GetChild (1).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an2 + ")";
		this.transform.GetChild (2).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min3 + ")";
		this.transform.GetChild (2).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max3 + ")";
		this.transform.GetChild (2).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an3 + ")";
		this.transform.GetChild (3).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min4 + ")";
		this.transform.GetChild (3).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max4 + ")";
		this.transform.GetChild (3).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an4 + ")";
	}
	
	// Update is called once per frame
	void Update () {
		if ((Contorl_Example.BLE_RB && GameStaticData.canButton_RB) || Input.GetKeyDown (KeyCode.A)) {
			GameStaticData.canButton_RB = false;


			if(this.transform.GetChild (0).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.min1 = float.Parse (this.transform.GetChild (0).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (0).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.max1 = float.Parse (this.transform.GetChild (0).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (0).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.an1 = float.Parse (this.transform.GetChild (0).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (1).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.min2 = float.Parse (this.transform.GetChild (1).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (1).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.max2 = float.Parse (this.transform.GetChild (1).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (1).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.an2 = float.Parse (this.transform.GetChild (1).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (2).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.min3 = float.Parse (this.transform.GetChild (2).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (2).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.max3 = float.Parse (this.transform.GetChild (2).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (2).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.an3 = float.Parse (this.transform.GetChild (2).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (3).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.min4 = float.Parse (this.transform.GetChild (3).GetChild (0).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (3).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.max4 = float.Parse (this.transform.GetChild (3).GetChild (1).GetChild(0).FindChild("Text").GetComponent<Text> ().text);
			
			if(this.transform.GetChild (3).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text != "")
			Player.an4 = float.Parse (this.transform.GetChild (3).GetChild (2).GetChild(0).FindChild("Text").GetComponent<Text> ().text);



			this.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min1 + ")";
			this.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max1 + ")";
			this.transform.GetChild (0).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an1 + ")";
			this.transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min2 + ")";
			this.transform.GetChild (1).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max2 + ")";
			this.transform.GetChild (1).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an2 + ")";
			this.transform.GetChild (2).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min3 + ")";
			this.transform.GetChild (2).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max3 + ")";
			this.transform.GetChild (2).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an3 + ")";
			this.transform.GetChild (3).GetChild (0).GetComponent<Text> ().text = "Min(" + Player.min4 + ")";
			this.transform.GetChild (3).GetChild (1).GetComponent<Text> ().text = "Max(" + Player.max4 + ")";
			this.transform.GetChild (3).GetChild (2).GetComponent<Text> ().text = "Turn angle(" + Player.an4 + ")";
			Time.timeScale = 1;
			this.gameObject.SetActive (false);
		}
	}

}
