using UnityEngine;
using UnityEditor;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
[CustomEditor(typeof(Computer_Script))]
public class Computer_Scripts_Editor : Editor {
	// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
	// Do test the code! You usually need to change a few small bits.



			void  OnInspectorGUI (){
				Computer_Script ComputerCar = (Computer_Script)target;

				GUILayout.Label("Position package:");
				GUILayout.Label("computer car script");
				GUILayout.Label("");
				GUILayout.Label("");
				GUILayout.Label("");
				GUILayout.Label("Number of position sensors:");
				GUILayout.Label("(look at the largest number in the");
				GUILayout.Label("children of the storage object)");
		ComputerCar.numberofpositions = (int)EditorGUILayout.FloatField("", ComputerCar.numberofpositions);
				GUILayout.Label("");
				GUILayout.Label("Lap to start on:");
		ComputerCar.currentlap = (int)EditorGUILayout.FloatField("", ComputerCar.currentlap);
				GUILayout.Label("");
				GUILayout.Label("");
				GUILayout.Label("This creates a texture above the car");
				GUILayout.Label("showing it's position to the player");
				ComputerCar.textureEnabled = EditorGUILayout.Toggle("Texture Enabled?",ComputerCar.textureEnabled);
				
				GUILayout.Label("");
				GUILayout.Label("");
				GUILayout.Label("Player's Car:");
			//	ComputerCar.playercar = EditorGUILayout.ObjectField("",ComputerCar.playercar, GameObject, true);
				GUILayout.Label("");
				GUILayout.Label("This is an important array of other");
				GUILayout.Label("computer cars, check it carefully.");
				GUILayout.Label("It should not contain this car.");

				ComputerCar.othercomputercars_ElementsExpand = EditorGUILayout.Foldout(ComputerCar.othercomputercars_ElementsExpand, "Other computer cars");
				if(ComputerCar.othercomputercars_ElementsExpand) {
					int y = 0;    
					ComputerCar.othercomputercars_ElementsSize = EditorGUILayout.IntField("Size", ComputerCar.othercomputercars_ElementsSize);    
					if(ComputerCar.othercomputercars.Length != ComputerCar.othercomputercars_ElementsSize) {        
						//Computer_Car_Script[] newArrayy = new Computer_Car_Script[ComputerCar.othercomputercars_ElementsSize];       
						for(y = 0; y < ComputerCar.othercomputercars_ElementsSize; y++) {            
							if(ComputerCar.othercomputercars.Length  > y) {                
						//		newArrayy[y] = ComputerCar.othercomputercars[y];            
							}        
						}        
					//	ComputerCar.othercomputercars = newArrayy;    
					}    
					for(y = 0; y < ComputerCar.othercomputercars.Length; y++) {        
				//		ComputerCar.othercomputercars[y] = EditorGUILayout.ObjectField("car "+y, ComputerCar.othercomputercars[y], typeof(Computer_Car_Script));    
					}
				}


				GUILayout.Label("");
				GUILayout.Label("");
				GUILayout.Label("Look at the demo or pdf if you don't know");
				GUILayout.Label("what to fill in, or send a contact form");
				GUILayout.Label("on our website.");

				if (GUI.changed)
					EditorUtility.SetDirty (ComputerCar);
			}

		}
	

}