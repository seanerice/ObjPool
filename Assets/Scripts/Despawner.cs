using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {
	public float MaxTime = 10f;

	private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > MaxTime) {
			GameObject.Destroy(gameObject);
		}
	}

	public void SetTime(float t) {
		MaxTime = t;
	}
}
