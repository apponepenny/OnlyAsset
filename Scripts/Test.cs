using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Test : MonoBehaviour {

	public Text a1;
	public Text a2;
	public Text a3;
	public Text a4;
	public Text a5;
	public Text a6;
	public Text a7;
	public Text a8;
	public Text a9;





	void Update()
	{
		a1.text = Contorl_Example.BLE_aX + " | \n" + Contorl_Example.BLE_aY + " | \n" + Contorl_Example.BLE_aZ;
		a2.text = Contorl_Example.BLE_LB.ToString();
		a3.text = Contorl_Example.BLE_RB.ToString();
		a4.text = Contorl_Example.BLE_RT.ToString();
		a5.text = Contorl_Example.BLE_LT.ToString();
		a6.text = Contorl_Example.BLE_RL.ToString();
		a7.text = "X : "+ BleShootingPlugin.GetXDegree();
		a8.text = "Y : "+ BleShootingPlugin.GetYDegree();
		a9.text = "Z : "+ BleShootingPlugin.GetZDegree();



	

	}


}
