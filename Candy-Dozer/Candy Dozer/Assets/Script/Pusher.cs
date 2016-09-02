﻿using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

	Vector3 startPosition;

	public float amplitude;
	public float speed;

	void Start()
	{
		startPosition = transform.localPosition;

	}

	void Update()
	{
		//変異を計算
		float z = amplitude * Mathf.Sin (Time.time * speed);

		//Zを変異させたポジションに再設定
		transform.localPosition = startPosition + new Vector3 (0, 0, z);

	}
}
