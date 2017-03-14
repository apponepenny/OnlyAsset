using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ReNameStorage))]
public class ReNameStoragerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		ReNameStorage myScript = (ReNameStorage)target;
		if(GUILayout.Button("ReName And PositionNum"))
		{
			myScript.ReName();
		}
	}
}