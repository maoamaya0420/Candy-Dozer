using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	const int SphereCandyFrequency = 3;

	int sampleCandyCount;


	public GameObject[] candyPrefabs;    
	public GameObject[] candySquarePrefabs;
	public GameObject candyHolder;
	public float shotSpeed;
	public float shotTorque;
	public float baseWidth;

	void Update() {

		if (Input.GetButtonDown ("Fire1"))
			Shot ();
	
	}

	//キャンディのプレファブからランダムに一つ選ぶ
	GameObject SampleCandy()
	{
		GameObject prefab = null;

		//特定の回数に一回丸いキャンディを選択する
		if (sampleCandyCount % SphereCandyFrequency == 0) {
			int index = Random.Range (0, candyPrefabs.Length);
			prefab = candyPrefabs [index];
		} else {
			int index = Random.Range (0, candySquarePrefabs.Length);
			prefab = candySquarePrefabs [index];
		}

		sampleCandyCount++;

		return prefab;
	}

	Vector3 GetInstantiatePosition()
	{
		//画面のサイズとInputの割合からキャンディ生成のポジションを計算
		float x = baseWidth *
		          (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		return transform.position + new Vector3 (x, 0, 0);
	}



	public void Shot()
	{
		//プレファブからCandyオブジェクトを作成
		GameObject candy = (GameObject)Instantiate (
//			                   candyPrefab,
//			                   transform.position,
//			                   Quaternion.identity
		
			SampleCandy(),
			GetInstantiatePosition(),
			Quaternion.identity );    //Quaternionは回転を表現する構造体で、Quaternion.identifyで回転なしという意味になる

		//生成したCandyオブジェクトの親をCandyHolderに設定する
		candy.transform.parent = candyHolder.transform;

		//CandyオブジェクトのRigidbodyを取得し力と回転を加える
		Rigidbody candyRigidBody = candy.GetComponent<Rigidbody> ();
		candyRigidBody.AddForce (transform.forward * shotSpeed);
		candyRigidBody.AddTorque (new Vector3 (0, shotTorque, 0));

	}
}
