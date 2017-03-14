using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BLETestScript : MonoBehaviour
{
	public Transform PanelActive;
	public Transform PanelInActive;
	public Transform PanelTypeSelection;
	public CentralScript PanelCentral;
	public GameObject BleCanvas;
	static private BLETestScript _bleTestSCript;
	public GameObject CentT1;
	static public void Show (Transform panel)
	{
		if (_bleTestSCript == null)
		{
			GameObject gameObject = GameObject.Find ("BLECanvas");
			if (gameObject != null)
				_bleTestSCript = gameObject.GetComponent<BLETestScript> ();
		}

		if (_bleTestSCript != null)
		{
			while (_bleTestSCript.PanelActive.childCount > 0)
				_bleTestSCript.PanelActive.GetChild (0).transform.SetParent (_bleTestSCript.PanelInActive);

			panel.SetParent (_bleTestSCript.PanelActive);
		}
	}

	// Use this for initialization
	void Start ()
	{
		BusyScript.IsBusy = false;
	//	Show (PanelTypeSelection);
	//	Instantiate(BleCanvas);
		StartDo();
	}

	public void StartDo(){
		PanelCentral.Initialize ();
		BLETestScript.Show (PanelCentral.gameObject.transform);
		DontDestroyOnLoad (GameObject.Find("BluetoothLEReceiver"));
		DontDestroyOnLoad (GameObject.Find ("BLECanvas"));

	}
	public void bleScan(){
		PanelCentral.OnScan ();

	}
	public void bleStopScan(){
		PanelCentral.Stop_Scan ();
	}
	// Update is called once per frame
	void Update ()
	{
	}
}
