using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using startechplus.ble;
namespace startechplus.ble.examples
{
public class rescan : MonoBehaviour {

		public bool reconnecting = false;
		public Button button;
		public float PauseTime;
		public bool scaned = false;
		public float NowTime;
		public GameObject BLECanvas;
		public Text Text_Num;
		public GameObject ScanButton;

	// Use this for initialization
	void Start () {
	
		//	GameObject.Find ("ButtonControl").GetComponent<HelpButton> ().startaction ();
			//			button.onClick.AddListener(this); GameObject.Find("BLECanvas").GetComponent<BLETestScript>().PanelCentral.OnScan();
		
			GameObject a = Instantiate (BLECanvas) as GameObject;

			a.name = "BLECanvas";
			scaned = false;
			reconnecting = false;

			DontDestroyOnLoad (a);
			//this.transform.FindChild("Button").GetComponent<Button> ().onClick.RemoveAllListeners ();
			//this.transform.FindChild("Button").GetComponent<Button> ().onClick.AddListener( delegate{ GameObject.Find("BLECanvas").GetComponent<BLETestScript>().PanelCentral.OnScan();} );
			PauseTime = Time.realtimeSinceStartup;

			Time.timeScale = 0;
	

	}
	
	
	// Update is called once per frame
	void Update () {
			
			NowTime = Time.realtimeSinceStartup - PauseTime;


			if (NowTime >= 3 ) {
				reconnecting = true;
			} 

			if (reconnecting) {
				if ((int)(NowTime % 4) == 0) {
					Text_Num.text = "Rescanning";

				
				}else if ((int)(NowTime % 4) == 1) {
					Text_Num.text = "Rescanning.";

				}else if ((int)(NowTime % 4) == 2) {
					Text_Num.text = "Rescanning..";
				

				}else if ((int)(NowTime % 4) == 3) {
					Text_Num.text = "Rescanning...";
				}
				if (!scaned) {
					//GameObject.Find ("BLECanvas").GetComponent<BLETestScript> ().PanelCentral.OnScan ();

					scaned = true;
				}

			}else{
				Text_Num.text = "Reconnecting after \n"+((int)(4-NowTime)).ToString()+" Second";
			}
	}




}
}
