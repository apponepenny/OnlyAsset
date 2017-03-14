using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
public class lap : MonoBehaviour {

	public player_position PlayerCar;
	private Computer_Script[] ComputerCars;
	public GUIText lapDisplay;
	public int numberOfLaps= 3;
	private int initialFontSize= 0;
	int finishedFontSize= 10;
	public int positionfinished= 1; //1=1st, 2=2nd, etc...
	public bool hasfinished= false;
	bool useCs= false;
	GameObject CsObject;
	private bool hasSentCsInfo= false;

	void  Start (){
		GameObject storageobject= GameObject.Find("Storage");
		Storag storagescript= storageobject.GetComponent<Storag>();
		ComputerCars = storagescript.allcomputercars;
		initialFontSize = lapDisplay.fontSize;
	}

	void  Update (){
		int lapsbeen= PlayerCar.currentlap;
		if (lapsbeen > numberOfLaps) {
			if (hasfinished == false) {
				positionfinished = positionfinished + 1;
			}
			lapDisplay.text = "Finished";
			lapDisplay.fontSize = finishedFontSize;
			hasfinished = true;
		} else {
			lapDisplay.fontSize = initialFontSize;
			lapDisplay.text = "" + lapsbeen + "/" + numberOfLaps;
		}
		if (hasfinished == false) {
			foreach(Computer_Script car in ComputerCars) {
				if (car.hasbeenaddedtofinishingposition == false) {
					if (car.currentlap > numberOfLaps) {
						car.hasbeenaddedtofinishingposition = true;
						positionfinished = positionfinished + 1;
					}
				}
			}
		} else {
			if (useCs == true) {
				if (hasSentCsInfo == false) {
					if (CsObject != null) {
						CsObject.BroadcastMessage("RaceFinished", positionfinished);
					}
					hasSentCsInfo = true;
				}
			}




		}
	}
}
}
