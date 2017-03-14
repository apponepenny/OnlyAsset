using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Excel;
using System.Data;

public class MutliLang : MonoBehaviour 
{

	public static String[] LangString= new string[75];
	public static int SelectLangNum = 0;
	void Start () 
	{		
		XLSX();
	}

	void Update(){

		print ( this.transform.localEulerAngles.z);

	}

	public static void XLSX()
	{
		//FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/AllLanguage.xlsx", FileMode.Open, FileAccess.Read);

		#if UNITY_EDITOR
		FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/Real Feel Racing App Script, all (2017-2-15).xlsx", FileMode.Open, FileAccess.Read);
		#elif UNITY_ANDROID

		#elif UNITY_IPHONE
		FileStream stream = File.Open(Application.dataPath + "/Raw/Real Feel Racing App Script, all (2017-2-15).xlsx", FileMode.Open, FileAccess.Read);

		#endif
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

		DataSet result = excelReader.AsDataSet();

		int columns = result.Tables[0].Columns.Count;
		int rows = result.Tables[0].Rows.Count;


		for(int i = 1;  i< rows; i++)
		{
			
			string  nvalue  = result.Tables[0].Rows[i][SelectLangNum+1].ToString();
			LangString [i+1] = nvalue.ToUpper();
				//Debug.Log(nvalue);

		}	
	}

}
