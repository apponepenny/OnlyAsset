using UnityEngine;
using System.Collections;

public class ReNameStorage : MonoBehaviour 
{


	public void ReName()
	{
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).name = i.ToString();
			for (int j = 0; j < transform.GetChild(i).childCount; j++) {
				transform.GetChild (i).GetChild (j).GetComponent<position_sen> ().positionnumber = i;
				transform.GetChild (i).GetChild (j).name = "PositionSensor";

			}
		}
	}
}