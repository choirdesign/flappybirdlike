using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public GameObject score;
	public int point = 0;
	public int addPoint = 1;

	void Start () {
	
		GetComponent<Text>().text = "SCORE: " + point.ToString();

	}

	void Update () {

		point +=  addPoint;
		GetComponent<Text> ().text = "SCORE: " + point.ToString ();
	}
}