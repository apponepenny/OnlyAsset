using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

public class TrackDataData{

	public string name{get; set;}
	public int Require{get; set;}
	public int EnemyTopSpeed{get; set;}
	public int Lap{get; set;}




}

public class LoadTrackData : MonoBehaviour {

	public TextAsset xml;
	public List<TrackDataData> TrackDatas = new List<TrackDataData>();

	public void Start(){
		LoadDataFromXML();
	}

	public void LoadDataFromXML(){
		TrackDatas.Clear();
		xml = Resources.Load("Xml/TrackData") as TextAsset;
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(xml.text);
		//print (xml.text);
		XmlNodeList dataList = xmlDoc.GetElementsByTagName("Data");
		foreach (XmlNode data in dataList)
		{
			XmlNodeList dataDetails = data.ChildNodes;
			TrackDataData obj = new TrackDataData();
			obj.name = dataDetails.Item(0).InnerText;
			obj.Require = int.Parse(dataDetails.Item(1).InnerText);
			obj.EnemyTopSpeed = int.Parse(dataDetails.Item(2).InnerText);
			obj.Lap = int.Parse(dataDetails.Item(3).InnerText);

		


			TrackDatas.Add(obj);
		}

	}

}
