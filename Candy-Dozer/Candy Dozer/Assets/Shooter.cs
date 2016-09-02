using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject candyPrefab;
	public float shotSpeed;
	public float shotTorque;

	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1"))
			Shot ();
	
	}

	public void Shot()
	{
		//プレファブからCandyオブジェクトを作成
		GameObject candy = (GameObject)Instantiate (
			                   candyPrefab,
			                   transform.position,
			                   Quaternion.identity);    //Quaternionは回転を表現する構造体で、Quaternion.identifyで回転なしという意味になる

		//CandyオブジェクトのRigidbodyを取得し力と回転を加える
		Rigidbody candyRigidBody = candy.GetComponent<Rigidbody> ();
		candyRigidBody.AddForce (transform.forward * shotSpeed);
		candyRigidBody.AddTorque (new Vector3 (0, shotTorque, 0));

	}
}
