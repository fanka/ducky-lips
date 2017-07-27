using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;

	public GameObject[] lips;
	public GameObject[] scarves;

	public Button matchingButton;

	public static int score;

	//public int lipsAppear;

	private float maxWidth;
	public float timeLeft = 20.0f;
	public float intervalAppearance = 1.0f;
	private GameObject currentLips;
	private GameObject currentScarf;
	public bool colorsMatch;




	// Use this for initialization
	void Start () {
		
		if (matchingButton != null)
		{
			matchingButton.onClick.AddListener(TaskOnClick);
		}

		if (cam == null) {
			cam = Camera.main;
		}
		//aims = new GameObject[6];
		//lipsAppear = UnityEngine.Random.Range (0, 6);

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		StartCoroutine (LipsAppear ());
		StartCoroutine (ScarvesAppear ());

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (timeLeft <= 0.0f)
			SceneManager.LoadScene ("RoundResults");

		timeLeft -= Time.deltaTime;


	}

	void TaskOnClick(){
		if (colorsMatch == true) {
			score += 1;
			Debug.Log ("You have clicked the button and got a score!");
		}
		else {
			score -= 1;
			Debug.Log ("You have clicked the button, but the colors don't match!");
		}


	}


	IEnumerator LipsAppear () {
		
		// yield return new WaitForSeconds (1.0f);
		yield return new WaitForSeconds (1.0F);
		while (timeLeft>0) {
			Vector3 lipsPosition = new Vector3 (0.06f,1.73f);

			currentLips = Instantiate (lips[UnityEngine.Random.Range(0,4)], lipsPosition, Quaternion.identity);
			yield return new WaitForSeconds (intervalAppearance);
			Destroy (currentLips);
		}

	}


	IEnumerator ScarvesAppear () {

		// yield return new WaitForSeconds (1.0f);

		while (timeLeft>0) {
			Vector3 scarvesPosition = new Vector3 (0.381f, -0.633f);
			currentScarf = Instantiate (scarves[UnityEngine.Random.Range(0,4)], scarvesPosition, Quaternion.identity);
			yield return new WaitForSeconds (intervalAppearance);


				if (currentScarf.tag == currentLips.tag) {
					colorsMatch = true;
					Debug.Log ("You have a match!");
					Destroy (currentScarf);

				} else {
					colorsMatch = false;
					Debug.Log ("No match");
					Destroy (currentScarf);
				}
				


			//Destroy (currentScarf);
		}

	}



}
