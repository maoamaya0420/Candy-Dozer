using UnityEngine;
using System.Collections;

public class CandyHolder : MonoBehaviour {

	const int DefaultCandyAmount = 30;

	//現在のキャンディのストック数
	int candy = DefaultCandyAmount;

	public void ConsumeCandy()
	{
		if (candy > 0)
			candy--;
	}

	public int GetCandyAmount()
	{
		return candy;
	}

	public void AddCandy(int amount)
	{
		candy += amount;
	
	}

	void OnGUI()
	{
		GUI.color = Color.black;

		//キャンディのストック数を表示
		string label = "Candy : " + candy;

		GUI.Label(new Rect(0,0,100,30),label);

	}

}
