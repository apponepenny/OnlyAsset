using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene()
    {
        Application.LoadLevel("Level1");
    }
}
