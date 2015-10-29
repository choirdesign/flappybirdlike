//1.5fごとにtreeを生成する。
//生成されたtreeが左に移動する。
//コルーチンを使用。

using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

	public GameObject treePrefab;
	public GameObject movingObj; //シーン上にある空のプレハブ
	private GameObject tree;

	public float treeInteval;	 //小さくすると生成速度が早くなる
	public float moveInteval;	 //大きくするとなんかかくかくしてCAVEっぽくなる あまりいじらないほうがよさげ
	public int moveSpeed;        //大きくするとスピードが早くなる


	void Start (){
		//コルーチン IEnumrator型を戻り値に設定
		StartCoroutine(MoveMap());
		StartCoroutine(SetTree());
	}

	//8秒たったらtreeを消す
	void Update (){
		Destroy (tree, 8f);
	}
		
	//tree生成
	IEnumerator SetTree (){
		while (true) {	//無限ループ
			//x=画面外 高さをランダム
			Vector3 pos = new Vector3 (12, Random.Range(3f, -1.5f), 0);
			tree = Instantiate (treePrefab, pos, transform.rotation) as GameObject;
			//movingObjを親として親の座標を取得?
			tree.transform.parent = movingObj.transform;
			yield return new WaitForSeconds (treeInteval);	//1.5f待ってまた繰り返す
		}
	}

	//movingObjの位置を取得してその位置を1秒かけて-4する、の繰り返し
	IEnumerator MoveMap (){
		while (true) {
			Vector3 pos = movingObj.transform.position;
			pos.x -= moveSpeed * Time.deltaTime; // * Time.deltaTimeで、１秒ずつ〜　という意味
			movingObj.transform.position = pos;
			yield return new WaitForSeconds (moveInteval);
			//yield return 0;	//待たない
		}
	}

}