using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour {
	AsyncOperation ao;
	public GameObject loadingScreenBG;
//	public Slider progBar;
	public Text loadingText;
	public Text loadingValue;
	public float loadingPrc;

	public bool isFakeLoadingBar = false;
	public float fakeIncrement = 0.3f;
	public float fakeTiming = 1f;
	// Use this for initialization
	void Start () {	
		LoadLevel ();
		Resources.UnloadUnusedAssets ();

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (loadingPrc);	
		loadingValue.text = loadingPrc.ToString("P1");
	}

	public void LoadLevel() {
		loadingScreenBG.SetActive (true);
		loadingValue.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text = "Loading...";




		if (!isFakeLoadingBar) {
			StartCoroutine (LoadLevelWithRealProgress ());
		} else {
			StartCoroutine (LoadLevelWithFakeProgress ());
		}
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds (2);

		ao = SceneManager.LoadSceneAsync (GameStaticData.sceneName);
		ao.allowSceneActivation = false;

		while (!ao.isDone) {
			loadingPrc = ao.progress;

			if (ao.progress == 0.9f) {
				loadingPrc = 1f;

				ao.allowSceneActivation = true;
			}

			yield return null;
		} 
	}

	IEnumerator LoadLevelWithFakeProgress()
	{
		yield return new WaitForSeconds (2);

		while (loadingPrc != 1f) {	
			loadingPrc += Time.deltaTime;
			yield return new WaitForSeconds (fakeTiming);
		}

		while (loadingPrc == 1f) {
			SceneManager.LoadScene (GameStaticData.sceneName);

		}

		yield return null;
	}
}
