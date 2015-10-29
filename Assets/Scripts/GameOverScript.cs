//ゲームオーバー文字を表示する
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	public void Lose () {
		gameObject.GetComponent<Text> ().enabled = true;
	}
}
