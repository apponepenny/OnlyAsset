using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollViewSet : MonoBehaviour {


		public GameObject Button_Template;
		public 	GameObject ButtonParent;
		private List<string> NameList = new List<string>();
		private List<GameObject> DeviceTemp= new List<GameObject>();

		// Use this for initialization
		void Start () {

		BleShootingPlugin.onDeviceRceiveEvent += CreatButton;
		}

//	public void CreatTest(){
//		NameList.Add("Alan");
//		NameList.Add("Amy");
//
//
//		foreach(string str in NameList)
//		{
//			GameObject go = Instantiate(Button_Template) as GameObject;
//			go.SetActive(true);
//			ButtonSet TB = go.GetComponent<ButtonSet>();
//			TB.SetName(str);
//			//go.transform.SetParent(ButtonParent.transform.parent);
//			go.transform.parent=ButtonParent.transform;
//			DeviceTemp.Add(go);
//		}
//	}

		public void CreatButton(string name){
			if(NameList.Contains(name))
				return;
			NameList.Add(name);
			GameObject go = Instantiate(Button_Template) as GameObject;
			go.SetActive(true);
			ButtonSet TB = go.GetComponent<ButtonSet>();
			TB.SetName(name);
			//go.transform.SetParent(ButtonParent.transform.parent);
		go.transform.parent=ButtonParent.transform;
			DeviceTemp.Add(go);
			
		}


		public void CancelButton(){
	//	Debug.Log("CancelButton()"+NameList.Count);
			NameList.Clear();
			for(int i=0;i<DeviceTemp.Count;i++){
			Debug.Log("CancelButton()  i"+i);
			GameObject temp=DeviceTemp[i] as GameObject;
//			temp.SetActive(false);
			GameObject.Destroy( temp);
			}
			DeviceTemp.Clear();

		//Debug.Log("CancelButton()"+NameList.Count);

		}
		public void ButtonClicked(string str)
		{
			Debug.Log(str + " button clicked.");
		BleShootingPlugin. onChoseToConnectDevice(str);

		}

}
