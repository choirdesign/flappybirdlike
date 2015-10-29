//1マウスクリックでひよこが飛ぶ
//2木に接触でゲームオーバー
//3死んだらスコアの加点をとめなきゃ
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//1
	private Rigidbody2D rb2D;
	public	float jumpForce = 10.0f; 

	//2
	public GameObject gameOverGUI;
	private Animator anim;	//Animator変数
	public bool gameover = false;

	//3scoreにアクセスする用
	public ScoreScript scoreScript;
	public HighScoreScript highScoreScript;

	//GetComponent
	void Start () {
		//PlayerScript内でRigidBody2Dを使いたい時になんどもGetComponent呼ぶ必要がなくなる
		rb2D = GetComponent<Rigidbody2D> ();

		//2AnimatorをGetComponentしておく
		anim = GetComponent ("Animator") as Animator;
		//animator = GetComponent<Animator>();
	}
	
	//1クリックでJump()よぶ
	//2障害物に接触時のゲームオーバー処理 ここに画面切り替えの命令は書かない
	void Update () {
		if (Input.GetMouseButtonDown (0) && !gameover) {
			//Updateじゃなくて別の場所にかくのか 見通しがよくなるからかな
			Jump();
		}

		if (gameover == true) {
			//アニメーション切り替え animatorのフラグgameoverがtrueになると負けアニメーションに切り替わる
			anim.SetBool ("gameover", true);
			//UIテキストを表示させるメッセージ
			gameOverGUI.SendMessage ("Lose");
		}
	}

	void Jump () {
		//Velocityは速度 rb2D.velocity.xは今のx軸=特に力を加えない y軸へはjumpForceぶん力を加えている
		rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
	}

	//2何かに接触した場合 ここではgameoverフラグをたてない
	void OnCollisionEnter2D(Collision2D col){
		StartCoroutine (Busted());

		//3加点をゼロにする
		scoreScript.addPoint = 0;
		highScoreScript.addHSPoint = 0;
	}

	//2ここでgameoverフラグを立てる ここで画面クリックでタイトルにもどす
	IEnumerator Busted(){
		gameover = true;
		//2マウス連打してたらスコアを見る暇もなくタイトルへ戻ってしまう対策 1秒待機
		yield return new WaitForSeconds (1f);
		//2！マークがない場合クリックしなくてもタイトルにとぶ
		while (!Input.GetMouseButtonDown (0)) { yield return 0; }
		Application.LoadLevel ("Title");
		}

}



