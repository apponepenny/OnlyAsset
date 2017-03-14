using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

public class CarPropertyData{

	public int id{get; set;}
	public int TopSpeed{get; set;}
	public int Accel{get; set;}
	public int Steer{get; set;}
	public int Brake{get; set;}
	public int UnlockNum{get; set;}



}

public class LoadCarProperty : MonoBehaviour {

	public TextAsset xml;
	public List<CarPropertyData> CarProperties = new List<CarPropertyData>();

	public void Start(){
		LoadDataFromXML();
	}

	public void LoadDataFromXML(){
		CarProperties.Clear();
		xml = Resources.Load("Xml/CarProperty") as TextAsset;
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(xml.text);
		//print (xml.text);
		XmlNodeList dataList = xmlDoc.GetElementsByTagName("Data");
		foreach (XmlNode data in dataList)
		{
			XmlNodeList dataDetails = data.ChildNodes;
			CarPropertyData obj = new CarPropertyData();
			obj.id = int.Parse(dataDetails.Item(0).InnerText);
			obj.TopSpeed = int.Parse(dataDetails.Item(1).InnerText);
			obj.Accel = int.Parse(dataDetails.Item(2).InnerText);
			obj.Steer =int.Parse(dataDetails.Item(3).InnerText);
			obj.Brake =int.Parse(dataDetails.Item(4).InnerText);
			obj.UnlockNum =int.Parse(dataDetails.Item(5).InnerText);



			CarProperties.Add(obj);
		}

	}

}
