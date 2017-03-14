using UnityEngine;
using System.Collections;

public class RockRoll : MonoBehaviour {
	public GameObject Rock;
	public float time;
	public int Size;
	float t;
	// Use this for initialization
	void Start () {

		
	}
	void RandRoll(){
		
		GameObject rock = Instantiate (Rock);
		rock.transform.parent = this.transform;
		rock.transform.localScale = new Vector3 (Size,Size*1.5f,Size);
		rock.transform.localPosition = new Vector3 (Random.Range(-30f,30f),0,0);
		Destroy (rock, 6);
	


	}
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t > time) {
			RandRoll ();
			t = 0;
		}



	}
}
