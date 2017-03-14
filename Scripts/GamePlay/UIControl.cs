using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using System;

public class UIControl : MonoBehaviour {
	float timer;
	public  float mm;
	public  float ss;
	public  float ms;

	public char[] time = new char[6];
	public bool KeyA;
	public bool KeyS;

		float t;
	public Text Time_Text;
	public Text mm1_Text;
	public Text mm2_Text;
	public Text ms1_Text;
	public Text ms2_Text;
	public Text ss1_Text;
	public Text ss2_Text;
	public Transform Position;
	public Transform MiniMap;
	public Transform Speed;
	public Transform Lap;
	float Le;
	// Use this for initialization
	void Start () {
		/*
		if (Screen.width == 640 && Screen.height == 1136)
			this.transform.localScale = new Vector3 (1,1,1.2f);
		
		if (Screen.width == 1136 && Screen.height == 640)
			this.transform.localScale = new Vector3 (1,1,1.2f);
*/
		KeyA = false;
		KeyS = false;

		Time_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").GetChild (0).GetComponent<Text> ();
		ms1_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("ms1").GetComponent<Text> ();
		ms2_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("ms2").GetComponent<Text> ();
		ss1_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("ss1").GetComponent<Text> ();
		ss2_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("ss2").GetComponent<Text> ();
		mm1_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("mm1").GetComponent<Text> ();
		mm2_Text = this.transform.FindChild ("Speed").FindChild ("Canvas").FindChild ("Time").FindChild ("mm2").GetComponent<Text> ();

		if (!GameStaticData.isVR) {
			Position.localPosition = new Vector3 (-700,Position.localPosition.y,Position.localPosition.z);
			MiniMap.localPosition = new Vector3 (-700,MiniMap.localPosition.y,MiniMap.localPosition.z);
			Lap.localPosition = new Vector3 (-700,Lap.localPosition.y,Lap.localPosition.z);
			Speed.localPosition = new Vector3 (200,Speed.localPosition.y,Speed.localPosition.z);

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			



		if (GameStaticData.isStart) {
			timer += Time.deltaTime;
			ms = (float)System.Math.Round (timer, 2);

	

			ms = int.Parse (ms.ToString ().Remove (0, ms.ToString ().IndexOf (".") + 1));
//		print (ms);
//		ms += timer;
			ss = (int)timer;
			if (ss >= 60) {
				mm++;
				timer = 0;
		
			}
			if (ms.ToString ().Length == 1 && ms > 0) {
				time [0] = ms.ToString () [0];
				time [1] = '0';

			} else if (ms.ToString ().Length == 2 && ms > 0) {
				time [0] = ms.ToString () [1];
				time [1] = ms.ToString () [0];

			} else {
				time [0] = '0';
				time [1] = '0';
			
			}

			if (((int)ss).ToString ().Length == 1 && ss >0) {
				time [2] = ((int)ss).ToString () [0];
				time [3] = '0';

			}else  if ((int)ss.ToString ().Length == 2 && ss >0) {
				time [2] = ((int)ss).ToString () [1];
				time [3] = ((int)ss).ToString () [0];

			}else {
				time [2] = '0';
				time [3] = '0';

			}

			if (mm.ToString ().Length == 1 && mm >0) {
				time [4] = mm.ToString () [0];
				time [5] = '0';

			}else  if (mm.ToString ().Length == 2 && mm >0) {
				time [4] = mm.ToString () [1];
				time [5] = mm.ToString () [0];

			}else {
				time [4] = '0';
				time [5] = '0';

			}

			Time_Text.text = mm.ToString ("00") + ":" + ss.ToString ("00") + ":" + ms.ToString ("00");
			ms1_Text.text = time [0].ToString();
			ms2_Text.text = time [1].ToString();
			ss1_Text.text = time [2].ToString();
			ss2_Text.text = time [3].ToString();
			mm1_Text.text = time [4].ToString();
			mm2_Text.text = time [5].ToString();






		}
	
	
	}


}



