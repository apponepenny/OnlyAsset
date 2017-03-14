using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Slider soundSlider;
    public static float MusicValue;
	// Use this for initialization
	void Start ()
    {
		soundSlider.value = 0.5f;
    }

    // Update is called once per frame
    void Update () {
		GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = soundSlider.value;

        MusicValue = soundSlider.value;

		if (Input.GetKeyDown (KeyCode.S)) {
			GameObject.Find("Canvas").transform.FindChild("all").gameObject.SetActive (true);
			this.transform.gameObject.SetActive (false);
		}
    }

 
}
