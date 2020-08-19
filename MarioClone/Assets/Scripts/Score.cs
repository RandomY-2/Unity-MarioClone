using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	public void ScoreUp()
    {
		score++;
		GetComponent<Text>().text = score.ToString();
    }

}
