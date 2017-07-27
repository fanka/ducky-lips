using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchScript : MonoBehaviour {

	public bool colorsMatch;



	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update() {
		


		if (GameObject.FindGameObjectsWithTag("blue").Length == 2 || GameObject.FindGameObjectsWithTag("rose").Length == 2 || GameObject.FindGameObjectsWithTag("green").Length == 2) {
			colorsMatch = true;

		}
	}
}
