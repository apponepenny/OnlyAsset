using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Test : MonoBehaviour {

	public Text sss;


	void Update()
	{

	
		if (sss.text != "") {
			GameStaticData.a = float.Parse (sss.text);
		}

	}


}
