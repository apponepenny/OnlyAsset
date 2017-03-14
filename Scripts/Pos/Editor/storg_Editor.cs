using UnityEngine;
using System.Collections;
using UnityEditor;
namespace UnityStandardAssets.Vehicles.Car
{
[CustomEditor(typeof(Storag))]
public class storg_Editor : Editor {

	void OnInspectorGUI () {

		Storag storag = (Storag)target;

		GUILayout.Label("Position package:");
		GUILayout.Label("storage script");
		GUILayout.Label("");

		GUILayout.Label("");
		GUILayout.Label("Player car game object:");
		//storag.playercar = EditorGUILayout.ObjectField("",storag.playercar, GameObject, true);
		GUILayout.Label("Player car script:");
		//storag.playercarscript = EditorGUILayout.ObjectField("",storag.playercarscript, player_pos_gui, true);
		GUILayout.Label("");
		GUILayout.Label("");
		GUILayout.Label("This is important, please check it carefully:");
		storag.allcomputercars_ElementsExpand = EditorGUILayout.Foldout(storag.allcomputercars_ElementsExpand, "Computer cars");
		if(storag.allcomputercars_ElementsExpand) {
			int y = 0;    
			storag.allcomputercars_ElementsSize = EditorGUILayout.IntField("Size", storag.allcomputercars_ElementsSize);    
			if(storag.allcomputercars.Length != storag.allcomputercars_ElementsSize) {        
				Computer_Script[] newArrayy  = new Computer_Script[storag.allcomputercars_ElementsSize];       
				for(y = 0; y < storag.allcomputercars_ElementsSize; y++) {            
					if(storag.allcomputercars.Length > y) {                
						newArrayy[y] = storag.allcomputercars[y];            
					}        
				}        
				storag.allcomputercars = newArrayy;    
			}    
			for(y = 0; y < storag.allcomputercars.Length; y++) {        
//				storag.allcomputercars[y] = EditorGUILayout.ObjectField("car "+y, storag.allcomputercars[y], typeof(Computer_Car_Script));    
			}
		}
		GUILayout.Label("");
		GUILayout.Label("");
		GUILayout.Label("If the editor crashes, try changing this,");
		GUILayout.Label("otherwise DO NOT TOUCH IT:");
		storag.part = (int)EditorGUILayout.FloatField("", storag.part);
		GUILayout.Label("");
		GUILayout.Label("");
		GUILayout.Label("Look at the demo or pdf if you don't know");
		GUILayout.Label("what to fill in, or send a contact form");
		GUILayout.Label("on our website.");

		if (GUI.changed)
			EditorUtility.SetDirty (storag);

	}


}
}