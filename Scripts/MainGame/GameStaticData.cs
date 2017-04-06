using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameStaticData : MonoBehaviour {

	public static int SelectedCar = 0;
	public static int PlayerUsedCar = 0;
	public static int SelectedMap = 0;
	public static int SelectedTrack = 0;
	public static Transform Cartranstam;
	public static int NowUnlockMap = 1;

	public static int MaxMap = 3;
	public static int MaxTrack = 4;
	public static bool isFinish = false;
	public static int currentLap = 1;
	public static float MusicValue = 1f;
	public static float SoundValue = 1f;
	public static float speed = 0;
	public static bool canButton_RB = true;
	public static bool canButton_LB = true;
	public static bool canButton_RT = true;
	public static bool canButton_LT = true;
	public static bool canButton_aY = true;
	public static bool canButton_RL = true;

	public static string sceneName = "Start";
	public static bool isContorl;
	public static bool InReScan = false;
	public static bool canMotor = false;
	public static bool isstop = false;
	public static bool checkPos = false;
	public static int ViewAngle = 0;
	public static int disconnectTimes = 0;
	public static int PlayLap = 2;
	public static bool inputFire = false;
	public static LoadCarProperty loadCarProperty = new LoadCarProperty ();
	public static LoadTrackData loadTrackData = new LoadTrackData ();

	public static Dictionary<string,int> MapTrackLap = new Dictionary<string,int>();
	public static Dictionary<string,int> BestTime = new Dictionary<string,int>();
	public static Dictionary<string,int> BestStar = new Dictionary<string,int>();
	public static Dictionary<string,int> TrackUnlock = new Dictionary<string,int>();

	public static bool isAddSpeed = false;



	public static List<string> CheckAdress = new List<string>();

	public static bool isConnect = false;
	public static string test = "hi";
	public static string SSS = "hi";
	public static string TTT = "hi";
	public static string PPP = "hi";

	public static string idid = "hi";
	public static bool isGO = false;
	public static bool isGameBack = false;

	public static float a = 2f;
	public static string b = "q";
	public static string c = "q";
	public static string d = "q";
	public static string e = "q";
	public static string f = "q";
	public static string g = "q";
	public static string h = "q";
	public static string i = "q";
	public static bool testbool = false;
	public static int j = 0;
	public static int num = 0;

	public static AssetBundle bundle;
	public static bool isCol = false;

	public static bool isVR = false;
	public static bool CanFinishInput = false;

	public static GameObject[] AICar = new GameObject[3];

	public static bool isStart = false;
	public static bool IsRespawn = false;
	public static int HaveStar;
	public static GameObject MidLine;
	public static GameObject SaveMidLine;
	public static GameObject ChooseView;
	public GameObject Line;
	public static bool checkFly = false;
	public static float steerAngles;

	//MotoX
	public static int GameAddNum = 0;
	public static GameMode PlayMode;
	public enum GameMode
	{
		MotoX,
		GP,
	}
	IEnumerator checkPosWait(){
		GameStaticData.checkPos = true;
		yield return new WaitForSeconds (1f);
		GameStaticData.checkPos = false;
//		print ("ss");
	}
	public void CheckPosD(){
		StopCoroutine (checkPosWait());
		StartCoroutine (checkPosWait());
//		print ("CheckPos");
	}


	IEnumerator Start(){
		MidLine = Line;
		loadTrackData.LoadDataFromXML ();
		yield return new WaitForSeconds (0.05f);

		loadCarProperty.LoadDataFromXML();
	


		/*
		MapTrackLap.Add ("1_1",2);
		MapTrackLap.Add ("1_2",3);
		MapTrackLap.Add ("1_3",3);
		MapTrackLap.Add ("1_4",2);

		MapTrackLap.Add ("2_1",2);
		MapTrackLap.Add ("2_2",3);
		MapTrackLap.Add ("2_3",3);
		MapTrackLap.Add ("2_4",2);

		MapTrackLap.Add ("3_1",2);
		MapTrackLap.Add ("3_2",3);
		MapTrackLap.Add ("3_3",3);
		MapTrackLap.Add ("3_4",2);

		MapTrackLap.Add ("4_1",2);
		MapTrackLap.Add ("4_2",3);
		MapTrackLap.Add ("4_3",3);
		MapTrackLap.Add ("4_4",2);
		*/
		yield return new WaitForSeconds (0.05f);
		PlayerPrefsUtility.SaveDict<string,int> ("MapTrackLap",MapTrackLap);

		MapTrackLap = PlayerPrefsUtility.LoadDict<string,int> ("MapTrackLap");
		BestTime = PlayerPrefsUtility.LoadDict<string,int> ("TrackBestTime");
		BestStar = PlayerPrefsUtility.LoadDict<string,int> ("TrackStar");
		TrackUnlock = PlayerPrefsUtility.LoadDict<string,int> ("TrackUnlock");
		GameStaticData.NowUnlockMap = PlayerPrefs.GetInt ("unlockMapNum");
		GameStaticData.ViewAngle = PlayerPrefs.GetInt ("ViewNum");
		HaveStar = PlayerPrefs.GetInt ("HaveStar");

		print ("LOADED");


	



	}


}
