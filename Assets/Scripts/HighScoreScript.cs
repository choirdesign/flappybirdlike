//ハイスコアを保存したい
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	public GameObject highscore;
	private int point = 0;
	public int addHSPoint = 1;

	public ScoreScript scoreScript;
	public Text highScoreText;
	private int highScore;
	private string key = "HIGH SCORE";


	// Use this for initialization
	void Start () {

		highScore = PlayerPrefs.GetInt (key, 0);
		GetComponent<Text> ().text = "HIGHSCORE" + highScore.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreScript.point > highScore) {
			point += addHSPoint;
			GetComponent<Text> ().text = "SCORE: " + highScore.ToString ();
			PlayerPrefs.SetInt (key, point);
		}
	}
}
