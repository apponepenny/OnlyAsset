using UnityEngine;
using System.Collections;
using UnityEditor;
namespace UnityStandardAssets.Vehicles.Car
{
[CustomEditor(typeof(player_position))]
public class player_position_Editor : Editor {



		void OnInspectorGUI (){

		player_position playerpos = (player_position)target;

			GUILayout.Label("Position package:");
			GUILayout.Label("player car script");
			GUILayout.Label("");
			GUILayout.Label("");
			GUILayout.Label("");
			GUILayout.Label("Fill this in:");
			GUILayout.Label("");
			GUILayout.Label("Number of position sensors:");
			GUILayout.Label("(look at the largest number in the");
			GUILayout.Label("children of the storage object)");

		playerpos.numberofpositions = (int)EditorGUILayout.FloatField("", playerpos.numberofpositions);
			GUILayout.Label("");
			GUILayout.Label("Lap to start on:");
		playerpos.currentlap = (int)EditorGUILayout.FloatField("", playerpos.currentlap);
			GUILayout.Label("");
			GUILayout.Label("");
			GUILayout.Label("GUI Stuff:");
			GUILayout.Label("");
	


			GUILayout.Label("");
			GUILayout.Label("Check this carefully:");
			GUILayout.Label("List of computer cars:");
			playerpos.computercars_ElementsExpand = EditorGUILayout.Foldout(playerpos.computercars_ElementsExpand, "Computer cars");
			if(playerpos.computercars_ElementsExpand) {
				int y = 0;    
			    
				for(y = 0; y < playerpos.computercars.Length; y++) {        
				//	playerpos.computercars[y] = EditorGUILayout.ObjectField("car "+y, playerpos.computercars[y], typeof(Computer_Script));    
				}
			}
			GUILayout.Label("");
			GUILayout.Label("");
			GUILayout.Label("Look at the demo or pdf if you don't know");
			GUILayout.Label("what to fill in, or send a contact form");
			GUILayout.Label("on our website.");











			if (GUI.changed)
				EditorUtility.SetDirty (playerpos);

		}
	}

}