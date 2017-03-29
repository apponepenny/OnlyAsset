using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSet : MonoBehaviour {
	private string Name;
	public Text ButtonText;
	public ScrollViewSet ScrollView;

	public void SetName(string name)
	{
		Name = name;
		ButtonText.text = name;
	}
	public void Button_Click()
	{
		ScrollView.ButtonClicked(Name);

	}
}
