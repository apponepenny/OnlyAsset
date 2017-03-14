using UnityEngine;
using System.Collections;

public class view : MonoBehaviour {

    public GameObject car_group;
    private GameObject[] car_array;
    private int car_index;
	// Use this for initialization
	void Start () {
        car_array = new GameObject[car_group.transform.childCount];
        for (int i = 0; i < car_array.Length; i++) {
            car_array[i] = car_group.transform.GetChild(i).gameObject;
            car_array[i].SetActive(false);
        }
        car_array[0].SetActive(true);
    }

    void input() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (car_index < 3){
                car_index++;
            }else {
                car_index = 0;
            }
            for (int i = 0; i < car_array.Length; i++) {
                car_array[i].SetActive(false);
                if (i == car_index) {
                    car_array[car_index].SetActive(true);
                }
            }
        }
    }

    void car_group_rotate() {
        car_group.transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }

    // Update is called once per frame
    void Update () {
        input();
        car_group_rotate();
    }
}
