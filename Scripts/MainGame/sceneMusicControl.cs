using UnityEngine;
using System.Collections;

public class sceneMusicControl : MonoBehaviour {

    // Use this for initialization
    float musicControl;
	void Start () {
        musicControl = AudioManager.MusicValue;
        this.GetComponent<AudioSource>().volume = musicControl;


    }

    // Update is called once per frame
    void Update () {


    }
}
