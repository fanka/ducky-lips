using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class matchButton : MonoBehaviour {

	public Button matchingButton;

	public static int score;

	MatchScript matchInstance;

	void Start () {

		matchInstance = GetComponent<MatchScript>();
		
		if (matchingButton != null)
		{
			matchingButton.onClick.AddListener(TaskOnClick);
		}
	}

	void TaskOnClick(){
		if (matchInstance.colorsMatch == true) {
			score += 1;
			matchingButton.onClick.RemoveListener (TaskOnClick);
			Debug.Log ("You have clicked the button and got a score!");
		}
		else {
			score -= 1;
			matchingButton.onClick.RemoveListener (TaskOnClick);
			Debug.Log ("You have clicked the button, but the colors don't match!");
	}

	
	}

}
