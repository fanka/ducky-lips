using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class matchButton : MonoBehaviour {

	public Button matchingButton;

	public static int score;

	GameController roundInstance;

	void Start () {

		roundInstance = GetComponent<GameController>();
		
		if (matchingButton != null)
		{
			matchingButton.onClick.AddListener(TaskOnClick);
		}
	}

	void TaskOnClick(){
		if (roundInstance.colorsMatch == true) {
			score += 1;
			Debug.Log ("You have clicked the button and got a score!");
		}
		else {
			score -= 1;
			Debug.Log ("You have clicked the button, but the colors don't match!");
	}

	
	}

}
